using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibbyLoopAdmin
{
    public partial class Form4 : Form
    {
        private string isbn;
        private string title;
        private string author;
        private Image bookImage;
        public Form4(string isbn, string title, string author, Image bookImage)
        {
            InitializeComponent();
            this.isbn = isbn;
            this.title = title;
            this.author = author;
            this.bookImage = bookImage;

            lblISBN.Text = isbn;
            lblTitle.Text = title;
            lblAuthor.Text = author;

            if (bookImage != null)
            {
                pictureBoxBook.Image = bookImage;
                pictureBoxBook.SizeMode = PictureBoxSizeMode.Zoom;
            }

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (string.IsNullOrEmpty(txtFname.Text) || string.IsNullOrEmpty(txtLname.Text) ||
                    string.IsNullOrEmpty(txtCollege.Text) || string.IsNullOrEmpty(cbType.Text))
                {
                    MessageBox.Show("Please fill in all fields.");
                    return;
                }

             
                DateTime claimDate = monthCalendarReservation.SelectionStart;
                DateTime reserveDate = DateTime.Now;

     
                if (claimDate < reserveDate)
                {
                    MessageBox.Show("The selected date cannot be in the past. Please select a valid date.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cbType.SelectedItem.ToString().ToUpper() == "STUDENT")
                {
                   
                    int penalty = 10;  
                    Form3 paymentForm = new Form3(penalty, isbn);
                    paymentForm.ShowDialog();

                 
                    if (paymentForm.IsPaymentComplete)
                    {
                        ProceedWithReservation(claimDate, reserveDate);
                    }
                    else
                    {
                        MessageBox.Show("Payment was not completed.");
                    }
                }
                else if (cbType.SelectedItem.ToString().ToUpper() == "TEACHER")
                {
                    
                    ProceedWithReservation(claimDate, reserveDate);
                }
                else
                {
                    MessageBox.Show("Please select a valid user type (STUDENT or TEACHER).");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void ProceedWithReservation(DateTime claimDate, DateTime reserveDate)
        {
            try
            {
                string connectionString = "SERVER=localhost; DATABASE=libbyloop; UID=root; PASSWORD=;";

                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();

                    MySqlTransaction transaction = con.BeginTransaction();

                    try
                    {
                        
                        string reservationQuery = @"
                    INSERT INTO reservation_info (bISBN, bTitle, bAuthor, First_Name, Last_Name, College, user_type, claim_date, reserved_date)
                    VALUES (@ISBN, @Title, @Author, @FirstName, @LastName, @College, @UserType, @ClaimDate, @ReservedDate)";

                        using (MySqlCommand cmd = new MySqlCommand(reservationQuery, con, transaction))
                        {
                            cmd.Parameters.AddWithValue("@ISBN", isbn);
                            cmd.Parameters.AddWithValue("@Title", title);
                            cmd.Parameters.AddWithValue("@Author", author);
                            cmd.Parameters.AddWithValue("@FirstName", txtFname.Text);
                            cmd.Parameters.AddWithValue("@LastName", txtLname.Text);
                            cmd.Parameters.AddWithValue("@College", txtCollege.Text);
                            cmd.Parameters.AddWithValue("@UserType", cbType.Text);
                            cmd.Parameters.AddWithValue("@ClaimDate", claimDate);
                            cmd.Parameters.AddWithValue("@ReservedDate", reserveDate);

                            cmd.ExecuteNonQuery();
                        }

                     
                        string updateBookQuery = "UPDATE newbook SET bAvailability = FALSE WHERE bISBN = @ISBN";
                        using (MySqlCommand updateCmd = new MySqlCommand(updateBookQuery, con, transaction))
                        {
                            updateCmd.Parameters.AddWithValue("@ISBN", isbn);
                            updateCmd.ExecuteNonQuery();
                        }

                   
                        transaction.Commit();

                        MessageBox.Show("Reservation successful and payment confirmed!");
                        this.Close();

                    }
                    catch (Exception ex)
                    {
                      
                        transaction.Rollback();
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while processing the reservation: " + ex.Message);
            }
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
