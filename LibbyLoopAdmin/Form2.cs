using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibbyLoopAdmin
{
    public partial class Form2 : Form
    {
        public Form2(string isbn, string title, string author, Image bookImage)
        {
            InitializeComponent();
            lblISBN.Text = isbn;
            lblTitle.Text = title;
            lblAuthor.Text = author;

            if (bookImage != null)
            {
                pictureBoxBook.Image = bookImage;
                pictureBoxBook.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFname.Text) ||
                string.IsNullOrWhiteSpace(txtLname.Text) ||
                string.IsNullOrWhiteSpace(txtCollege.Text) ||
                string.IsNullOrWhiteSpace(cbType.Text))
            {
                MessageBox.Show("Please ensure all fields are filled before proceeding.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string connectionString = "SERVER=localhost; DATABASE=libbyloop; UID=root; PASSWORD=;";
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();
                    DateTime borrowDate = DateTime.Now;
                    DateTime dueDate = borrowDate.AddDays(5);


                    string query = "INSERT INTO borrowed_info (bISBN, bTitle, bAuthor, First_Name, Last_Name, College, user_type, date_borrowed, date_due, bImage) " +
                                   "VALUES (@Isbn, @Title, @Author, @Fname, @Lname, @College, @UserType, @BorrowDate, @DueDate, @Image)";

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Isbn", lblISBN.Text);
                        cmd.Parameters.AddWithValue("@Title", lblTitle.Text);
                        cmd.Parameters.AddWithValue("@Author", lblAuthor.Text);
                        cmd.Parameters.AddWithValue("@Fname", txtFname.Text);
                        cmd.Parameters.AddWithValue("@Lname", txtLname.Text);
                        cmd.Parameters.AddWithValue("@College", txtCollege.Text);
                        cmd.Parameters.AddWithValue("@UserType", cbType.Text);
                        cmd.Parameters.AddWithValue("@BorrowDate", borrowDate);
                        cmd.Parameters.AddWithValue("@DueDate", dueDate);

                        byte[] imageBytes = ImageToByteArray(pictureBoxBook.Image);
                        cmd.Parameters.AddWithValue("@Image", imageBytes);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {

                            string updateQuery = "UPDATE newbook SET bAvailability = @Availability WHERE bIsbn = @Isbn";
                            using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, con))
                            {
                                updateCmd.Parameters.AddWithValue("@Availability", false);
                                updateCmd.Parameters.AddWithValue("@Isbn", lblISBN.Text);
                                updateCmd.ExecuteNonQuery();
                            }

                            MessageBox.Show($"Book borrowed successfully! Due date: {dueDate.ToShortDateString()}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Failed to save book borrowing information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving the information: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private byte[] ImageToByteArray(Image image)
        {
            if (image == null)
            {
                return new byte[0];
            }

            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void pictureBoxBook_Click(object sender, EventArgs e)
        {

        }
    }
}
