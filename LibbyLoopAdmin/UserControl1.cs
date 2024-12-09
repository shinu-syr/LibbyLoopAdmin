using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace LibbyLoopAdmin
{
    public partial class AddBookUC : UserControl
    {

     
        public AddBookUC()
        {
            InitializeComponent();
   
        }
        public event EventHandler BookAdded;
        private void UserControl1_Load(object sender, EventArgs e)
        {
            listContent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        public event EventHandler DataSaved;//from form1 para ma reload datatable sa edit and viceversa
        private void addBook_Click(object sender, EventArgs e)
        {
            string bTitle = txtBookTitle.Text.Trim();
            string bAuthor = txtBookAuthor.Text.Trim();
            string bIsbn = txtBookIsbn.Text.Trim();
            string bCategory = txtBookCategory.Text.Trim();

            //validations for both text and image
            if (string.IsNullOrEmpty(bTitle) || string.IsNullOrEmpty(bAuthor) || string.IsNullOrEmpty(bIsbn) || string.IsNullOrEmpty(bCategory))
            {
                MessageBox.Show("All fields must be filled before adding the book.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (pictureBox6.Image == null)
            {
                MessageBox.Show("Please select an image for the book.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //from stack overflow pag insert ng image sa db
            MemoryStream memoryStream = new MemoryStream();
            pictureBox6.Image.Save(memoryStream, ImageFormat.Png);
            byte[] bImage = new byte[memoryStream.Length];
            memoryStream.Position = 0;
            memoryStream.Read(bImage, 0, bImage.Length);

            string mysqlCon = "server=127.0.0.1; user=root; database=libbyloop; password=";

            using (MySqlConnection mySqlConnection = new MySqlConnection(mysqlCon))
            {
                try
                {
                    mySqlConnection.Open();

                    string query = "INSERT INTO newbook (bTitle, bAuthor, bIsbn, bCategory, bImage) VALUES (@bTitle, @bAuthor, @bIsbn, @bCategory, @bImage)";

                    using (MySqlCommand cmd = new MySqlCommand(query, mySqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@bTitle", bTitle);
                        cmd.Parameters.AddWithValue("@bAuthor", bAuthor);
                        cmd.Parameters.AddWithValue("@bIsbn", bIsbn);
                        cmd.Parameters.AddWithValue("@bCategory", bCategory);
                        cmd.Parameters.AddWithValue("@bImage", bImage);

                        cmd.ExecuteNonQuery();
                    }

                    BookAdded?.Invoke(this, EventArgs.Empty);

                    MessageBox.Show("Book added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtBookTitle.Clear(); //clear after added
                    txtBookAuthor.Clear();
                    txtBookIsbn.Clear();
                    txtBookCategory.Clear();
                    pictureBox6.Image = null;

                    DataSaved?.Invoke(this, EventArgs.Empty); //from form1 para ma reload datatable sa edit and viceversa

                    listContent();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void addPic_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image(*.JPG;*.PNG) | *.jpg;*.png";
            opf.Multiselect = false; // Ensure only one image is selected
            opf.RestoreDirectory = true; // Restore the directory to the last selected location

            if (opf.ShowDialog() == DialogResult.OK)
            {
                // Load the selected image
                pictureBox6.Image = Image.FromFile(opf.FileName);
            }
        }

        private void listContent()
        {
            string mysqlCon = "server=127.0.0.1; user=root; database=libbyloop; password=";

            using (MySqlConnection mySqlConnection = new MySqlConnection(mysqlCon))
            {
                try
                {
                    mySqlConnection.Open();

                    string query = "SELECT bLibid, bTitle, bAuthor, bIsbn, bCategory FROM newbook";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, mySqlConnection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    BookList.DataSource = dt;

                    // Remove left padding and set alignment
                    BookList.DefaultCellStyle.Padding = new Padding(0);
                    BookList.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                    BookList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//para ma full yung space automatically

                    BookList.Columns["bLibid"].HeaderText = "ID";
                    BookList.Columns["bLibid"].Visible = false; // Hide the ID column
                    BookList.Columns["bTitle"].HeaderText = "Book Title";
                    BookList.Columns["bAuthor"].HeaderText = "Author";
                    BookList.Columns["bIsbn"].HeaderText = "ISBN";
                    BookList.Columns["bCategory"].HeaderText = "Category";

                    BookList.RowHeadersWidth = 30; // yung default selector sa left banda

                    mySqlConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error");
                }
            }
        }

        private void BookList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        public void RefreshGrid()//from form1 para ma reload datatable sa edit and viceversa
        {
            listContent();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
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

                    string query = "SELECT bTitle, bIsbn, bAuthor, bCategory, bAvailability, bImage FROM newbook";
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
