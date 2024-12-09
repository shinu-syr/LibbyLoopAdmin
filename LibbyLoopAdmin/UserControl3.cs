using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace LibbyLoopAdmin
{
    public partial class EditBookUC : UserControl
    {
        private string mysqlCon = "server=127.0.0.1; user=root; database=libbyloop; password=";
        private int selectedBookId;

        private void EditBookUC_Load(object sender, EventArgs e)
        {

        }

        public EditBookUC()
        {
            InitializeComponent();
            LoadBookData();
            BookList.SelectionChanged += BookList_SelectionChanged;
            EditBook.Click += EditBook_Click;
            addPic.Click += addPic_Click;
            pictureBox6.Click += PictureBox6_Click;
        }

        public void LoadBookData()
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(mysqlCon))
            {
                try
                {
                    mySqlConnection.Open();
                    string query = "SELECT bLibid, bTitle, bAuthor, bIsbn, bCategory FROM newbook ORDER BY bTitle ASC";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, mySqlConnection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    BookList.DataSource = dt;

                    BookList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    foreach (DataGridViewColumn column in BookList.Columns)
                    {
                        column.ReadOnly = column.Name == "bLibid";
                    }

                    BookList.Columns["bLibid"].HeaderText = "ID";
                    BookList.Columns["bLibid"].Visible = false; 
                    BookList.Columns["bTitle"].HeaderText = "Book Title";
                    BookList.Columns["bAuthor"].HeaderText = "Author";
                    BookList.Columns["bIsbn"].HeaderText = "ISBN";
                    BookList.Columns["bCategory"].HeaderText = "Category";

                    BookList.RowHeadersWidth = 30; // yung default selector sa left banda
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while loading books: " + ex.Message, "Error");
                }
            }
        }

        private void BookList_SelectionChanged(object sender, EventArgs e) //basta andito mga identifier sa method calling na updatebookdata
        {
            if (BookList.SelectedRows.Count > 0)
            {
                DataGridViewRow row = BookList.SelectedRows[0];
                selectedBookId = int.Parse(row.Cells["bLibid"].Value.ToString());
                txtBookTitle.Text = row.Cells["bTitle"].Value?.ToString() ?? "";
                txtBookAuthor.Text = row.Cells["bAuthor"].Value?.ToString() ?? "";
                txtBookIsbn.Text = row.Cells["bIsbn"].Value?.ToString() ?? "";
                txtBookCategory.Text = row.Cells["bCategory"].Value?.ToString() ?? "";

                LoadBookImage(selectedBookId);
            }
        }

        private void LoadBookImage(int bookId)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(mysqlCon))
            {
                try
                {
                    mySqlConnection.Open();
                    string query = "SELECT bImage FROM newbook WHERE bLibid = @bLibid";
                    MySqlCommand cmd = new MySqlCommand(query, mySqlConnection);
                    cmd.Parameters.AddWithValue("@bLibid", bookId);

                    byte[] imgBytes = (byte[])cmd.ExecuteScalar();
                    if (imgBytes != null)
                    {
                        using (MemoryStream ms = new MemoryStream(imgBytes))
                        {
                            pictureBox6.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        pictureBox6.Image = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while loading the book image: " + ex.Message, "Error");
                }
            }
        }


        public event EventHandler DataSaved;//from form1 para ma reload datatable sa edit and viceversa
        private void EditBook_Click(object sender, EventArgs e)
        {
            if (IsValidBookInfo()) // validation whether may laman textbox
            {
             
                byte[] bImage = ConvertImageToBytes(pictureBox6.Image); 
                bool bAvailability = true; 
                UpdateBookData(selectedBookId, txtBookTitle.Text, txtBookAuthor.Text, txtBookIsbn.Text, txtBookCategory.Text, bImage, bAvailability); //update changes

                DataSaved?.Invoke(this, EventArgs.Empty); //from form1 para ma reload datatable sa edit and viceversa
                LoadBookData(); 
            }
        }

        private byte[] ConvertImageToBytes(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, img.RawFormat);
                return ms.ToArray();
            }
        }

        private bool IsValidBookInfo()
        {
            if (string.IsNullOrWhiteSpace(txtBookTitle.Text) || string.IsNullOrWhiteSpace(txtBookAuthor.Text) ||
                string.IsNullOrWhiteSpace(txtBookIsbn.Text) || string.IsNullOrWhiteSpace(txtBookCategory.Text))
            {
                MessageBox.Show("All fields must be filled before applying changes.", "Validation Error");
                return false;
            }
            return true;
        }

        private void UpdateBookData(int bookId, string bTitle, string bAuthor, string bIsbn, string bCategory, byte[] bImage, bool bAvailability)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(mysqlCon))
            {
                try
                {
                    mySqlConnection.Open();
                    string query = "UPDATE newbook SET bTitle=@bTitle, bAuthor=@bAuthor, bIsbn=@bIsbn, bCategory=@bCategory, bImage=@bImage, bAvailability=@bAvailability WHERE bLibid=@bLibid";
                    using (MySqlCommand cmd = new MySqlCommand(query, mySqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@bTitle", bTitle);
                        cmd.Parameters.AddWithValue("@bAuthor", bAuthor);
                        cmd.Parameters.AddWithValue("@bIsbn", bIsbn);
                        cmd.Parameters.AddWithValue("@bCategory", bCategory);
                        cmd.Parameters.AddWithValue("@bImage", bImage);
                        cmd.Parameters.AddWithValue("@bAvailability", bAvailability);
                        cmd.Parameters.AddWithValue("@bLibid", bookId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Book information updated successfully.", "Success");
                        }
                        else
                        {
                            MessageBox.Show("No rows were updated. Please check if the record exists.", "Error");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while updating the book data: " + ex.Message, "Error");
                }
            }
        }

        private void addPic_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image(*.JPG;*.PNG) | *.jpg;*.png";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox6.Image = Image.FromFile(opf.FileName);
            }
        }

        private void PictureBox6_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image(*.JPG;*.PNG) | *.jpg;*.png";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox6.Image = Image.FromFile(opf.FileName);
            }
        }

        public void RefreshGrid()//from form1 para ma reload datatable sa edit and viceversa
        {
            LoadBookData();
        }

        private void delBook_Click(object sender, EventArgs e) //para sa deletebook i2(rik)
        {
            DeleteBookData(selectedBookId);
        }

        private void DeleteBookData(int selectedBookId)
        {
            string mysqlCon = "server=127.0.0.1; user=root; database=libbyloop; password=";
            using (MySqlConnection mySqlConnection = new MySqlConnection(mysqlCon))
            {
                try
                {
                    mySqlConnection.Open();

                    string query = "DELETE FROM newbook WHERE bLibid = @bLibid";

                    using (MySqlCommand cmd = new MySqlCommand(query, mySqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@bLibid", selectedBookId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Book Deleted successfully.", "Success");
                        }
                        else
                        {
                            MessageBox.Show("Can't delete book data. Please check if the record exists.", "Error");
                        }

                        LoadBookData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while deleting the book data: " + ex.Message, "Error");
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) //para sa searvchh
        {
            SearchBooks(txtSearch.Text);
        }
        private void SearchBooks(string searchTerm)
        {
            try
            {
                string connectionString = "SERVER=localhost; DATABASE=libbyloop; UID=root; PASSWORD=;";
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();

                    string query = "SELECT bTitle, bIsbn, bAuthor, bCategory, bImage FROM newbook";
                    bool hasSearchFilter = !string.IsNullOrWhiteSpace(searchTerm);

                    if (hasSearchFilter)
                    {
                        query += " WHERE";
                        List<string> conditions = new List<string>();

                        if (hasSearchFilter)
                        {
                            conditions.Add(" (bTitle LIKE @SearchTerm OR bIsbn LIKE @SearchTerm OR bAuthor LIKE @SearchTerm OR bCategory LIKE @SearchTerm)");
                        }

                        query += string.Join(" AND", conditions);
                    }

                    query += " ORDER BY bTitle ASC";

                    MySqlCommand cmd = new MySqlCommand(query, con);

                    if (hasSearchFilter)
                    {
                        cmd.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");
                    }

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    BookList.DataSource = ds.Tables[0];

                    BookList.Columns["bImage"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while searching for books: " + ex.Message);
            }
        }

        
    }
}
