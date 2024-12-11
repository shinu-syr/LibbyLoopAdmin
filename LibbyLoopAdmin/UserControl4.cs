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
            cbSearchCateg.Items.Add("All Categories");
            cbSearchCateg.SelectedIndex = 0;

            txtSearch.TextChanged += TxtSearch_TextChanged;
            cbSearchCateg.SelectedIndexChanged += cbSearchCateg_SelectedIndexChanged;
            dataGridView1.CellClick += dataGridView1_CellClick;
            this.VisibleChanged += new EventHandler(UserControl4_VisibleChanged);
            LoadBooksData();
            UpdateCategoryComboBox();

        }
        private void UpdateCategoryComboBox()
        {
            cbSearchCateg.Items.Clear();
            cbSearchCateg.Items.Add("All Categories");

            string mysqlCon = "server=127.0.0.1; user=root; database=libbyloop; password=";

            using (MySqlConnection mySqlConnection = new MySqlConnection(mysqlCon))
            {
                try
                {
                    mySqlConnection.Open();
                    string query = "SELECT DISTINCT bCategory FROM newbook";

                    using (MySqlCommand cmd = new MySqlCommand(query, mySqlConnection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string category = reader.GetString("bCategory");
                                cbSearchCateg.Items.Add(category);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while updating categories: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            cbSearchCateg.SelectedIndex = 0; 
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchBooks(txtSearch.Text, cbSearchCateg.SelectedItem?.ToString());
        }
        private List<DataRow> MergeSort(List<DataRow> rows)
        {
            if (rows.Count <= 1)
                return rows;

            int mid = rows.Count / 2;
            List<DataRow> left = rows.GetRange(0, mid);
            List<DataRow> right = rows.GetRange(mid, rows.Count - mid);

            left = MergeSort(left);
            right = MergeSort(right);

            return Merge(left, right);
        }

        private List<DataRow> Merge(List<DataRow> left, List<DataRow> right)
        {
            List<DataRow> result = new List<DataRow>();
            int i = 0, j = 0;

            while (i < left.Count && j < right.Count)
            {
                string titleLeft = left[i]["bTitle"].ToString();
                string titleRight = right[j]["bTitle"].ToString();

                if (string.Compare(titleLeft, titleRight, StringComparison.OrdinalIgnoreCase) <= 0)
                {
                    result.Add(left[i]);
                    i++;
                }
                else
                {
                    result.Add(right[j]);
                    j++;
                }
            }

            while (i < left.Count)
            {
                result.Add(left[i]);
                i++;
            }
            while (j < right.Count)
            {
                result.Add(right[j]);
                j++;
            }

            return result;
        }

        private void SortBooksByTitleUsingMergeSort(DataTable dataTable)
        {
          
            List<DataRow> rows = new List<DataRow>();
            foreach (DataRow row in dataTable.Rows)
            {
                rows.Add(row);
            }

            List<DataRow> sortedRows = MergeSort(rows);

            dataTable.Rows.Clear();
            foreach (DataRow row in sortedRows)
            {
                dataTable.ImportRow(row);
            }
        }

        private void LoadBooksData()
        {
            UpdateCategoryComboBox();

            try
            {
                string connectionString = "SERVER=localhost; DATABASE=libbyloop; UID=root; PASSWORD=;";
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter("SELECT bTitle, bIsbn, bAuthor, bCategory, bAvailability, bImage FROM newbook", con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    DataTable bookTable = ds.Tables[0];
         
                    SortBooksByTitleUsingMergeSort(bookTable);

                    dataGridView1.DataSource = bookTable;

                    dataGridView1.Columns["bTitle"].HeaderText = "Title";
                    dataGridView1.Columns["bIsbn"].HeaderText = "ISBN";
                    dataGridView1.Columns["bAuthor"].HeaderText = "Author";
                    dataGridView1.Columns["bCategory"].HeaderText = "Category";
                    dataGridView1.Columns["bAvailability"].HeaderText = "Stocks";
                    dataGridView1.Columns["bImage"].Visible = false;

                    dataGridView1.RowHeadersWidth = 21;
                    dataGridView1.Refresh();
                    SearchBooks(string.Empty, "All Categories");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }


        private void UserControl4_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                LoadBooksData();
            }

        }
        private void UserControl4_Load(object sender, EventArgs e)
        {
            cbSearchCateg.SelectedIndex = 0;
            LoadBooksData();
            dataGridView1.Refresh();
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
                    bool hasCategoryFilter = !string.IsNullOrEmpty(selectedCategory) && selectedCategory != "All Categories";
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

                    object result = cmd.ExecuteScalar();

                    if (result != null && result is byte[] imageBytes)
                    {
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            bookImage.Image = Image.FromStream(ms);
                            bookImage.SizeMode = PictureBoxSizeMode.StretchImage;
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

        private byte[] ConvertImageToBytes(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
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
                                btnReserve.Visible = true;
                                if (isAvailable)
                                {
                                    btnBorrow.Enabled = true;
                                    btnBorrow.Text = "Borrow now";
                                    btnBorrow.BackgroundImage = Properties.Resources.buttonBlistNew;

                                    btnReserve.Enabled = true;
                                    btnReserve.Text = "Reserve";
                                    btnReserve.BackgroundImage = Properties.Resources.buttonBlistNew;
                                }
                                else
                                {
                                    btnBorrow.Enabled = false;
                                    btnBorrow.Text = "Unavailable";
                                    btnBorrow.BackgroundImage = Image.FromFile("C:/Users/reyes/Downloads/LibbyLoopAdminPictureBox/UnavailableBtn.png");

                                    btnReserve.Enabled = false;
                                    btnReserve.Text = "Unavailable";
                                    btnReserve.BackgroundImage = Image.FromFile("C:/Users/reyes/Downloads/LibbyLoopAdminPictureBox/UnavailableBtn.png");

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
            if (!string.IsNullOrEmpty(selectedIsbn))
            {
                UpdateBookAvailability(selectedIsbn);
            }
            LoadBooksData();
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

                        btnReserve.Enabled = isAvailable;
                        btnReserve.Text = isAvailable ? "Borrow" : "Unavailable";
                    }
                    LoadBooksData();
                    dataGridView1.Refresh();
                }

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

        private void bookImage_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }
    }
}

