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
    public partial class ReserveUC : UserControl
    {
        public ReserveUC()
        {
            InitializeComponent();
            this.Load += new EventHandler(this.ReserveUC_Load);
            this.VisibleChanged += new EventHandler(ReserveUC_VisibleChanged);
            isBookUnclaimed();
            LoadBorrowedBooks();
        }
        private void ReserveUC_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                isBookUnclaimed();
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
                    MySqlDataAdapter da = new MySqlDataAdapter("SELECT bTitle, bIsbn, bAuthor, First_Name, Last_Name, reserved_date, claim_date, College, user_type FROM reservation_info", con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];

                    dataGridView1.Columns["bTitle"].HeaderText = "Title";
                    dataGridView1.Columns["bISBN"].HeaderText = "ISBN";
                    dataGridView1.Columns["bAuthor"].HeaderText = "Author";
                    dataGridView1.Columns["First_Name"].HeaderText = "First Name";
                    dataGridView1.Columns["Last_Name"].HeaderText = "Last Name";
                    dataGridView1.Columns["reserved_date"].HeaderText = "Reserved Date";
                    dataGridView1.Columns["claim_date"].HeaderText = "Claim Date";
                    dataGridView1.Columns["college"].Visible = false;
                    dataGridView1.Columns["user_type"].Visible = false;

                    // Resize columns automatically
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a reservation to move.");
                    return;
                }

             
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string isbn = selectedRow.Cells["bIsbn"].Value.ToString();
                string firstName = selectedRow.Cells["First_Name"].Value.ToString();
                string lastName = selectedRow.Cells["Last_Name"].Value.ToString();
                string author = selectedRow.Cells["bAuthor"].Value.ToString();
                string title = selectedRow.Cells["bTitle"].Value.ToString();
                

             
                string college = selectedRow.Cells["college"].Value.ToString();
                string userType = selectedRow.Cells["user_type"].Value.ToString();

                MoveToBorrowedInfo(isbn, firstName, lastName, author, title, college, userType);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

        }
        private void MoveToBorrowedInfo(string isbn, string firstName, string lastName, string author, string title, string college, string userType)
        {
            try
            {
                string connectionString = "SERVER=localhost; DATABASE=libbyloop; UID=root; PASSWORD=;";

                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();
                    MySqlTransaction transaction = con.BeginTransaction();
                    DateTime borrowDate = DateTime.Now;
                    DateTime dueDate = borrowDate.AddDays(5);

                    try
                    {
                        string insertQuery = "INSERT INTO borrowed_info (bIsbn, bTitle, bAuthor, First_Name, Last_Name, date_borrowed, date_due, College, user_type) " +
                                             "VALUES (@isbn, @title, @author, @firstName, @lastName, @dateBorrowed, @dueDate, @college, @userType)";
                        using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, con, transaction))
                        {
                            insertCmd.Parameters.AddWithValue("@isbn", isbn);
                            insertCmd.Parameters.AddWithValue("@firstName", firstName);
                            insertCmd.Parameters.AddWithValue("@title", title);
                            insertCmd.Parameters.AddWithValue("@author", author);
                            insertCmd.Parameters.AddWithValue("@lastName", lastName);
                            insertCmd.Parameters.AddWithValue("@dateBorrowed", borrowDate);
                            insertCmd.Parameters.AddWithValue("@dueDate", dueDate );
                            insertCmd.Parameters.AddWithValue("@college", college); 
                            insertCmd.Parameters.AddWithValue("@userType", userType); 
                            insertCmd.ExecuteNonQuery();
                        }

                        
                        string deleteQuery = "DELETE FROM reservation_info WHERE bIsbn = @isbn";
                        using (MySqlCommand deleteCmd = new MySqlCommand(deleteQuery, con, transaction))
                        {
                            deleteCmd.Parameters.AddWithValue("@isbn", isbn);
                            deleteCmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show("Reservation successfully claimed and moved to borrow.");
                        LoadBorrowedBooks(); 
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("An error occurred while moving the reservation: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void isBookUnclaimed()
        {
            try
            {
                string connectionString = "SERVER=localhost; DATABASE=libbyloop; UID=root; PASSWORD=;";
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();
                    string selectQuery = @"SELECT bIsbn FROM reservation_info WHERE claim_date < CURDATE()";

                    using (MySqlCommand selectCmd = new MySqlCommand(selectQuery, con))
                    using (MySqlDataReader reader = selectCmd.ExecuteReader())
                    {
                        List<string> unclaimedBooks = new List<string>();

                        while (reader.Read())
                        {
                            unclaimedBooks.Add(reader["bIsbn"].ToString());
                        }

                        reader.Close();

                        if (unclaimedBooks.Count > 0)
                        {
                            foreach (string isbn in unclaimedBooks)
                            {

                                string updateQuery = "UPDATE newbook SET bAvailability = 1 WHERE bIsbn = @isbn";
                                using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, con))
                                {
                                    updateCmd.Parameters.AddWithValue("@isbn", isbn);
                                    updateCmd.ExecuteNonQuery();
                                }


                                string deleteQuery = "DELETE FROM reservation_info WHERE bIsbn = @isbn";
                                using (MySqlCommand deleteCmd = new MySqlCommand(deleteQuery, con))
                                {
                                    deleteCmd.Parameters.AddWithValue("@isbn", isbn);
                                    deleteCmd.ExecuteNonQuery();
                                }
                            }

                            MessageBox.Show("Unclaimed reservations have been returned to the book list.", "Unclaimed Reservations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while processing unclaimed reservations: " + ex.Message);
            }
        }
        private void ReserveUC_Load(object sender, EventArgs e)
        {
            isBookUnclaimed();
            LoadBorrowedBooks();
               
        }
    }
}
