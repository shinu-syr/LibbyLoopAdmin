using MySql.Data.MySqlClient;
using System;
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

        private void addBook_Click(object sender, EventArgs e)
        {
            // Get the text from the input fields
            string bTitle = txtBookTitle.Text.Trim();
            string bAuthor = txtBookAuthor.Text.Trim();
            string bIsbn = txtBookIsbn.Text.Trim();
            string bCategory = txtBookCategory.Text.Trim();

            // Validation: Check if any field is empty
            if (string.IsNullOrEmpty(bTitle) || string.IsNullOrEmpty(bAuthor) ||
                string.IsNullOrEmpty(bIsbn) || string.IsNullOrEmpty(bCategory))
            {
                MessageBox.Show("All fields must be filled before adding the book.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Stop execution if validation fails
            }

            // Check if an image is selected
            if (pictureBox6.Image == null)
            {
                MessageBox.Show("Please select an image for the book.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Convert the image to a byte array
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

                    MessageBox.Show("Book added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear the fields after successful insertion
                    txtBookTitle.Clear();
                    txtBookAuthor.Clear();
                    txtBookIsbn.Clear();
                    txtBookCategory.Clear();
                    pictureBox6.Image = null;

                    // Refresh the book list
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

            if (opf.ShowDialog() == DialogResult.OK)
            {
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

                    // Set the DataSource for the DataGridView
                    BookList.DataSource = dt;

                    // Remove left padding and set alignment
                    BookList.DefaultCellStyle.Padding = new Padding(0);
                    BookList.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                    // Resize columns automatically
                    BookList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    // Modify column headers (optional)
                    BookList.Columns["bLibid"].HeaderText = "ID";
                    BookList.Columns["bTitle"].HeaderText = "Book Title";
                    BookList.Columns["bAuthor"].HeaderText = "Author";
                    BookList.Columns["bIsbn"].HeaderText = "ISBN";
                    BookList.Columns["bCategory"].HeaderText = "Category";

                    // Close the connection
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
    }
}
