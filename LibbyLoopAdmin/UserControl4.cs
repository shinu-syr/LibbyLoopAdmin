using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LibbyLoopAdmin
{
    public partial class BookListUC : UserControl
    {
        public BookListUC()
        {
            InitializeComponent();
            cbSearchCateg.Items.Insert(0, "All Categories");
            cbSearchCateg.SelectedIndex = 0;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            cbSearchCateg.SelectedIndexChanged += cbSearchCateg_SelectedIndexChanged;
            dataGridView1.CellClick += dataGridView1_CellClick;
            LoadBooksData();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchBooks(txtSearch.Text, cbSearchCateg.SelectedItem?.ToString());
        }

        private void LoadBooksData()
        {
            try
            {
                string connectionString = "SERVER=localhost; DATABASE=libbyloop; UID=root; PASSWORD=;";
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter("SELECT bTitle, bIsbn, bAuthor, bCategory, bAvailability, bImage FROM newbook ORDER BY bTitle ASC", con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];

                    dataGridView1.Columns["bTitle"].HeaderText = "Title";
                    dataGridView1.Columns["bIsbn"].HeaderText = "ISBN";
                    dataGridView1.Columns["bAuthor"].HeaderText = "Author";
                    dataGridView1.Columns["bCategory"].HeaderText = "Category";
                    dataGridView1.Columns["bAvailability"].HeaderText = "Available";
                    dataGridView1.Columns["bAvailability"].CellTemplate = new DataGridViewCheckBoxCell();
                    dataGridView1.Columns["bAvailability"].ValueType = typeof(bool);
                    dataGridView1.Columns["bImage"].Visible = false; 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void UserControl4_Load(object sender, EventArgs e)
        {
            LoadBooksData();
        }

        private void SearchBooks(string searchTerm, string selectedCategory)
        {
            try
            {
                string connectionString = "SERVER=localhost; DATABASE=libbyloop; UID=root; PASSWORD=;";
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();

                    string query = "SELECT bTitle, bIsbn, bAuthor, bCategory, bAvailability, bImage FROM newbook";
                    bool hasCategoryFilter = selectedCategory != "All Categories";
                    bool hasSearchFilter = !string.IsNullOrWhiteSpace(searchTerm);

                    if (hasCategoryFilter || hasSearchFilter)
                    {
                        query += " WHERE";
                        List<string> conditions = new List<string>();

                        if (hasCategoryFilter)
                        {
                            conditions.Add(" bCategory = @Category");
                        }

                        if (hasSearchFilter)
                        {
                            conditions.Add(" (bTitle LIKE @SearchTerm OR bIsbn LIKE @SearchTerm OR bAuthor LIKE @SearchTerm OR bCategory LIKE @SearchTerm)");
                        }

                        query += string.Join(" AND", conditions);
                    }

                    query += " ORDER BY bTitle ASC";

                    MySqlCommand cmd = new MySqlCommand(query, con);

                    if (hasCategoryFilter)
                    {
                        cmd.Parameters.AddWithValue("@Category", selectedCategory);
                    }

                    if (hasSearchFilter)
                    {
                        cmd.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");
                    }

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];

                    dataGridView1.Columns["bImage"].Visible = false; 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while searching for books: " + ex.Message);
            }
        }

        private void LoadImage(string isbn)
        {
            try
            {
                string connectionString = "SERVER=localhost; DATABASE=libbyloop; UID=root; PASSWORD=;";
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();

                    MySqlCommand cmd = new MySqlCommand("SELECT bImage FROM newbook WHERE bIsbn = @Isbn", con);
                    cmd.Parameters.AddWithValue("@Isbn", isbn);

                    byte[] imageBytes = (byte[])cmd.ExecuteScalar();

                    if (imageBytes != null)
                    {
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            bookImage.Image = Image.FromStream(ms);
                            bookImage.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No image found for this book.");
                        bookImage.Image = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading the image: " + ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string connectionString = "SERVER=localhost; DATABASE=libbyloop; UID=root; PASSWORD=;";
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();

                    if (e.RowIndex >= 0)
                    {
                        DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                        selectedIsbn = selectedRow.Cells["bIsbn"].Value?.ToString();
                        selectedTitle = selectedRow.Cells["bTitle"].Value?.ToString();
                        selectedAuthor = selectedRow.Cells["bAuthor"].Value?.ToString();
                        MySqlCommand cmd = new MySqlCommand("SELECT * FROM newbook WHERE bIsbn = @Isbn", con);
                        cmd.Parameters.AddWithValue("@Isbn", selectedIsbn);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                bool isAvailable = reader.GetBoolean(reader.GetOrdinal("bAvailability"));
                                btnBorrow.Visible = true;
                                if (isAvailable)
                                {
                                    btnBorrow.Enabled = true;
                                    btnBorrow.Text = "Borrow";
                                    btnReserve.Enabled = true;
                                    btnReserve.Text = "Reserve";
                                }
                                else
                                {
                                    btnBorrow.Enabled = false;
                                    btnBorrow.Text = "Unavailable";
                                    btnReserve.Enabled = false;
                                    btnReserve.Text = "Unavailable";
                                }
                            }
                        }

                        string isbn = selectedIsbn;
                        MySqlCommand imgCmd = new MySqlCommand("SELECT bImage FROM newbook WHERE bIsbn = @Isbn", con);
                        imgCmd.Parameters.AddWithValue("@Isbn", isbn);

                        byte[] imageBytes = (byte[])imgCmd.ExecuteScalar();
                        if (imageBytes != null)
                        {
                            using (MemoryStream ms = new MemoryStream(imageBytes))
                            {
                                selectedImage = Image.FromStream(ms); 
                                bookImage.Image = selectedImage; 
                                bookImage.SizeMode = PictureBoxSizeMode.Zoom;
                            }
                        }
                        else
                        {
                            selectedImage = null; 
                            bookImage.Image = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading the image: " + ex.Message);
            }
        }

        private void cbSearchCateg_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchBooks(txtSearch.Text, cbSearchCateg.SelectedItem?.ToString());
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
        }
        private string selectedIsbn;
        private string selectedTitle;
        private string selectedAuthor;
        private Image selectedImage;

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            try
               {
                if (!string.IsNullOrEmpty(selectedIsbn))
                {
                    using (Form2 borrowForm = new Form2(selectedIsbn, selectedTitle, selectedAuthor, selectedImage))
                    {
                        borrowForm.FormClosed += BorrowForm_FormClosed; 
                        borrowForm.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("No book is selected. Please select a book from the list.");
                }
                }
                catch (Exception ex)
                {
                MessageBox.Show("An error occurred while opening the Borrow form: " + ex.Message);
            }
        }

        private void BorrowForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadBooksData();
            if (!string.IsNullOrEmpty(selectedIsbn))
            {
                UpdateBookAvailability(selectedIsbn);
            }
        }

        private void UpdateBookAvailability(string isbn)
        {
            try
            {
                string connectionString = "SERVER=localhost; DATABASE=libbyloop; UID=root; PASSWORD=;";
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();

                    string query = "SELECT bAvailability FROM newbook WHERE bIsbn = @Isbn";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Isbn", isbn);

                    object result = cmd.ExecuteScalar();

                    if (result != null && result is bool)
                    {
                        bool isAvailable = (bool)result;

                        btnBorrow.Enabled = isAvailable;
                        btnBorrow.Text = isAvailable ? "Borrow" : "Unavailable";
                    }
                }
                LoadBooksData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while updating book availability: " + ex.Message);
            }
        }

        private void btnReserve_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(selectedIsbn))
                {
                    using (Form4 borrowForm = new Form4(selectedIsbn, selectedTitle, selectedAuthor, selectedImage))
                    {
                        borrowForm.FormClosed += BorrowForm_FormClosed;
                        borrowForm.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("No book is selected. Please select a book from the list.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while opening the Borrow form: " + ex.Message);
            }
        }
    }
}

