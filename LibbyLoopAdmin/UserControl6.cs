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
    public partial class BorrowedListUC : UserControl
    {
        public BorrowedListUC()
        {
            InitializeComponent();
            LoadBorrowedBooks();
            this.VisibleChanged += new EventHandler(BorrowedListUC_VisibleChanged);
        }

        private void UserControl6_Load(object sender, EventArgs e)
        {
            LoadBorrowedBooks();
        }
   
        private void BorrowedListUC_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible) 
            {
                LoadBorrowedBooks();
            }

        }

    
        private void LoadBorrowedBooks()
        {
            try
            {
                string connectionString = "SERVER=localhost; DATABASE=libbyloop; UID=root; PASSWORD=;";
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter("SELECT bTitle, bIsbn, bAuthor, First_Name, Last_Name, date_borrowed, date_due FROM borrowed_info ORDER BY date_due", con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];

                    dataGridView1.Columns["bTitle"].HeaderText = "Title";
                    dataGridView1.Columns["bISBN"].HeaderText = "ISBN";
                    dataGridView1.Columns["bAuthor"].HeaderText = "Author";
                    dataGridView1.Columns["First_Name"].HeaderText = "First Name";
                    dataGridView1.Columns["Last_Name"].HeaderText = "Last Name";
                    dataGridView1.Columns["date_borrowed"].HeaderText = "Date Borrowed";
                    dataGridView1.Columns["date_due"].HeaderText = "Date Due";
           
                

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a book to return.");
                    return;
                }

           
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string isbn = selectedRow.Cells["bIsbn"].Value.ToString();
                DateTime dueDate = Convert.ToDateTime(selectedRow.Cells["date_due"].Value);
                DateTime returnDate = DateTime.Now;

              
                dueDate = dueDate.Date;  
                returnDate = returnDate.Date; 

                
                string userType = GetUserTypeForBook(isbn);
               
                int penalty = 0;
                bool isOverdue = returnDate > dueDate;
                bool isStudent = userType == "STUDENT";



                if (isOverdue && isStudent)
                {

                    TimeSpan overdueDays = returnDate - dueDate;
                    penalty = overdueDays.Days * 10;
                }
                else
                {
                    ProcessBookReturn(isbn);
                }

                if (penalty > 0 && isStudent)
                {
                    Form3 paymentForm = new Form3(penalty, isbn);
                    paymentForm.ShowDialog();

                    if (paymentForm.IsPaymentComplete)
                    {
                        ProcessBookReturn(isbn);
                    }
                    else
                    {
                        MessageBox.Show("Payment was not completed.");
                    }
                }
                else
                {
                    ProcessBookReturn(isbn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }



        private void ProcessBookReturn(string isbn)
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
                       
                        string deleteQuery = "DELETE FROM borrowed_info WHERE bISBN = @isbn";
                        using (MySqlCommand deleteCmd = new MySqlCommand(deleteQuery, con, transaction))
                        {
                            deleteCmd.Parameters.AddWithValue("@isbn", isbn);
                            deleteCmd.ExecuteNonQuery();
                        }

                  
                        string updateQuery = "UPDATE newbook SET bAvailability = TRUE WHERE bISBN = @isbn";
                        using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, con, transaction))
                        {
                            updateCmd.Parameters.AddWithValue("@isbn", isbn);
                            updateCmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show("Book returned successfully.");
                        LoadBorrowedBooks();
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
                MessageBox.Show("An error occurred while processing the return: " + ex.Message);
            }
        }
        private string GetUserTypeForBook(string isbn)
        {
            string userType = string.Empty;
            string connectionString = "SERVER=localhost; DATABASE=libbyloop; UID=root; PASSWORD=;";

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT user_type FROM borrowed_info WHERE bISBN = @isbn LIMIT 1";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@isbn", isbn);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            userType = result.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while retrieving user type: " + ex.Message);
                }
            }
            return userType;
        }

    }

}
