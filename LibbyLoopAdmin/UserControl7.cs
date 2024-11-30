using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace LibbyLoopAdmin
{
    public partial class AccountUC : UserControl
    {

        private int selectedUserId; //ganto rin sa edit section e, para ma store selected id from datagrid

        public AccountUC()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void AddAccBtn_Click(object sender, EventArgs e)
        {
            string addUsername = newUsername.Text;
            string addIdnumber = newIdnumber.Text;
            string addPassword = newPasssword.Text;

            if (string.IsNullOrEmpty(addUsername) || string.IsNullOrEmpty(addIdnumber) || string.IsNullOrEmpty(addPassword))
            {
                MessageBox.Show("All fields must be filled before adding the book.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string mysqlCon = "server=127.0.0.1; user=root; database=libbyloop; password=";

            using (MySqlConnection mySqlConnection = new MySqlConnection(mysqlCon))
            {
                try
                {
                    mySqlConnection.Open();

                    string query = "INSERT INTO users (username, AccountID, password) VALUES (@addUsername, @addIdnumber, @addPassword)";
                    using (MySqlCommand cmd = new MySqlCommand(query, mySqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@addUsername", addUsername);
                        cmd.Parameters.AddWithValue("@addIdnumber", addIdnumber);
                        cmd.Parameters.AddWithValue("@addPassword", addPassword);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Account added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    newUsername.Clear();
                    newIdnumber.Clear();
                    newPasssword.Clear();

                    listContent();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

                    string query = "SELECT id, AccountID, username, password FROM users";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, mySqlConnection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    userList.DataSource = dt;

                    // Remove left padding and set alignment
                    userList.DefaultCellStyle.Padding = new Padding(0);
                    userList.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                    userList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//para ma full yung space automatically

                    userList.Columns["id"].Visible = false; // Hide the ID column
                    userList.Columns["AccountID"].HeaderText = "Account ID";
                    userList.Columns["username"].HeaderText = "Username";
                    userList.Columns["password"].HeaderText = "Password";

                    userList.RowHeadersWidth = 30; // yung default selector sa left banda

                    mySqlConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error");
                }
            }
        }

        private void userList_CellContentClick(object sender, DataGridViewCellEventArgs e) //events nun datagrid tas para ma lagay sa textbox content na kinlickhttps://www.youtube.com/watch?v=SqQAbzDs3jo
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.userList.Rows[e.RowIndex];
                editIdnumber.Text = row.Cells["AccountID"].Value.ToString();
                editUsername.Text = row.Cells["Username"].Value.ToString();
                editPassword.Text = row.Cells["Password"].Value.ToString();
            }
        }

        private void AccountUC_Load(object sender, EventArgs e)
        {
            listContent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void userList_SelectionChanged(object sender, EventArgs e)
        {
            if (userList.SelectedRows.Count > 0)
            {
                DataGridViewRow row = userList.SelectedRows[0];
                selectedUserId = int.Parse(row.Cells["id"].Value.ToString());
            }

        }

        private void EditAccBtn_Click(object sender, EventArgs e) //edit na
        {
            string edittUsername = editUsername.Text;
            string edittIdnumber = editIdnumber.Text;
            string edittPassword = editPassword.Text;

            if (string.IsNullOrEmpty(edittUsername) || string.IsNullOrEmpty(edittIdnumber) || string.IsNullOrEmpty(edittPassword)) //validation from edit pero hindi ko minethod
            {
                MessageBox.Show("All fields must be filled before applying changes.", "Validation Error");
                return;
            }

            UpdateAccountData(selectedUserId, edittUsername, edittIdnumber, edittPassword); //methods rin ginamit from edit section

        }

        private void UpdateAccountData(int Userid, string username, string Idnumber, string password)
        {
            string mysqlCon = "server=127.0.0.1; user=root; database=libbyloop; password="; // from edit rin
            using (MySqlConnection mySqlConnection = new MySqlConnection(mysqlCon))
            {
                try
                {
                    mySqlConnection.Open();

                    string query = "UPDATE users SET username=@editUsername, AccountID=@editIdnumber, password=@editPassword WHERE id = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, mySqlConnection))
                    {

                        cmd.Parameters.AddWithValue("@editUsername", username);
                        cmd.Parameters.AddWithValue("@editIdnumber", Idnumber);
                        cmd.Parameters.AddWithValue("@editPassword", password);
                        cmd.Parameters.AddWithValue("@id", Userid);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Account information updated successfully.", "Success");
                            listContent();
                        }
                        else
                        {
                            MessageBox.Show("No rows were updated. Please check if the record exists.", "Error");
                        }

                        listContent();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while updating the book data: " + ex.Message, "Error");
                }
            }
        }


        private void userList_CellClick(object sender, DataGridViewCellEventArgs e) // same sa isa, kinuha lang from properties bolt, para ma reflect sa textbox pag kinlick sa left
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.userList.Rows[e.RowIndex];
                editIdnumber.Text = row.Cells["AccountID"].Value.ToString();
                editUsername.Text = row.Cells["Username"].Value.ToString();
                editPassword.Text = row.Cells["Password"].Value.ToString();

                selectedUserId = int.Parse(row.Cells["id"].Value.ToString());
            }
        }

        private void delAcc_Click(object sender, EventArgs e)
        {
            DeleteAccountData(selectedUserId);
        }

        private void DeleteAccountData(int selectedUserId)
        {
            string mysqlCon = "server=127.0.0.1; user=root; database=libbyloop; password=";
            using (MySqlConnection mySqlConnection = new MySqlConnection(mysqlCon))
            {
                try
                {
                    mySqlConnection.Open();

                    if(selectedUserId == 1) // ginanto ko nalang yoko na mag pasa dito ng valuye HAHHWH 
                    {
                        MessageBox.Show("You can't delete the main admin account!");
                    }
                    else
                    {
                        string query = "DELETE FROM users WHERE id = @id";

                        using (MySqlCommand cmd = new MySqlCommand(query, mySqlConnection))
                        {
                            cmd.Parameters.AddWithValue("@id", selectedUserId);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("User Deleted successfully.", "Success");
                            }
                            else
                            {
                                MessageBox.Show("Can't delete user data. Please check if the record exists.", "Error");
                            }

                            listContent();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while deleting the user data: " + ex.Message, "Error");
                }
            }
        }

    }
}
