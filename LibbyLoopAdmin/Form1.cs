﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LibbyLoopAdmin
{
    public partial class Form1 : Form
    {
        
        //ka emehan lang, pang shadow sa frame tas para magalawgalaw----------------------------------------
        private bool Drag;
        private int MouseX;
        private int MouseY;

        private BookListUC categoryControl;
        private AddBookUC addBookControl;

        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;

        private bool m_aeroEnabled;

        private const int CS_DROPSHADOW = 0x00020000;
        private const int WM_NCPAINT = 0x0085;
        private const int WM_ACTIVATEAPP = 0x001C;

        [System.Runtime.InteropServices.DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);
        [System.Runtime.InteropServices.DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);
        [System.Runtime.InteropServices.DllImport("dwmapi.dll")]

        public static extern int DwmIsCompositionEnabled(ref int pfEnabled);
        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
            );

        public struct MARGINS
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }
        protected override CreateParams CreateParams
        {
            get
            {
                m_aeroEnabled = CheckAeroEnabled();
                CreateParams cp = base.CreateParams;
                if (!m_aeroEnabled)
                    cp.ClassStyle |= CS_DROPSHADOW; return cp;
            }
        }
        private bool CheckAeroEnabled()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int enabled = 0; DwmIsCompositionEnabled(ref enabled);
                return (enabled == 1) ? true : false;
            }
            return false;
        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCPAINT:
                    if (m_aeroEnabled)
                    {
                        var v = 2;
                        DwmSetWindowAttribute(this.Handle, 2, ref v, 4);
                        MARGINS margins = new MARGINS()
                        {
                            bottomHeight = 1,
                            leftWidth = 0,
                            rightWidth = 0,
                            topHeight = 0
                        }; DwmExtendFrameIntoClientArea(this.Handle, ref margins);
                    }
                    break;
                default: break;
            }
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST && (int)m.Result == HTCLIENT) m.Result = (IntPtr)HTCAPTION;
        }
        private void PanelMove_MouseDown(object sender, MouseEventArgs e)
        {
            Drag = true;
            MouseX = Cursor.Position.X - this.Left;
            MouseY = Cursor.Position.Y - this.Top;
        }
        private void PanelMove_MouseMove(object sender, MouseEventArgs e)
        {
            if (Drag)
            {
                this.Top = Cursor.Position.Y - MouseY;
                this.Left = Cursor.Position.X - MouseX;
            }
        }
        private void PanelMove_MouseUp(object sender, MouseEventArgs e) { Drag = false; }
        //ka emehan lang, pang shadow sa frame tas para magalawgalaw----------------------------------------




        private int UserId;//from login
        public Form1(int userId)
        {
            InitializeComponent();
            UserId = userId; // in-assign userId from login as UserId

            editBookUC1.DataSaved += (sender, e) => { addBookUC1.RefreshGrid(); }; //(rik)
            addBookUC1.DataSaved += (sender, e) => { editBookUC1.RefreshGrid(); }; //(rik) para to ma refresh yung tables sa edit if nag add and viceversa


            //DATABEST CONNECTION TEST--------------------------------------------------------------------------------------------
            string mysqlCon = "server=127.0.0.1; user=root; database=libbyloop; password=";
            MySqlConnection mySqlConnection = new MySqlConnection(mysqlCon);
            try
            {
                mySqlConnection.Open();
                //MessageBox.Show("connected successfully", "Database");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { mySqlConnection.Close(); }
            //DATABEST CONNECTION TEST--------------------------------------------------------------------------------------------


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string mysqlCon = "server=127.0.0.1; user=root; database=libbyloop; password=";
            using (MySqlConnection mySqlConnection = new MySqlConnection(mysqlCon))
            {
                try
                {
                    mySqlConnection.Open();

                    string query = "SELECT userType FROM users WHERE id = @userId";
                    using (MySqlCommand cmd = new MySqlCommand(query, mySqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@userId", UserId);
                        string userType = cmd.ExecuteScalar()?.ToString();

                        if (userType == "Admin")
                        {
                            Accountbtn.Enabled = true;
                            Accountbtn.Visible = true;
                        }
                        else
                        {
                            Accountbtn.Enabled = false;
                            Accountbtn.Visible = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Homebtn_Click(object sender, EventArgs e)
        {
            homeUC1.Show();
            homeUC1.BringToFront();

            addBookUC1.Hide();
            editBookUC1.Hide();
            bookListUC1.Hide();
            borrowedListUC1.Hide();
            reserveUC1.Hide();
            accountUC1.Hide();

            //btn pressed
            Homebtn.BackColor = Color.FromArgb(183, 149, 105); // may kulay

            //btn unpressed
            Addbtn.BackColor = Color.FromArgb(204, 166, 117); // walang kulay
            Editbtn.BackColor = Color.FromArgb(204, 166, 117); // walang kulay
            Booklistbtn.BackColor = Color.FromArgb(204, 166, 117); // walang kulay
            Borrowedlistbtn.BackColor = Color.FromArgb(204, 166, 117); // walang kulay
            ReservationBtn.BackColor = Color.FromArgb(204, 166, 117); // walang kulay
            Accountbtn.BackColor = Color.FromArgb(204, 166, 117); // walang kulay

        }


        private void Addbtn_Click(object sender, EventArgs e)
        {
            addBookUC1.Show();
            addBookUC1.BringToFront();

            homeUC1.Hide();
            editBookUC1.Hide();
            bookListUC1.Hide();
            borrowedListUC1.Hide();
            reserveUC1.Hide();
            accountUC1.Hide();

            //btn color
            Homebtn.BackColor = Color.FromArgb(204, 166, 117); // walang kulay
            Editbtn.BackColor = Color.FromArgb(204, 166, 117); // walang kulay
            Booklistbtn.BackColor = Color.FromArgb(204, 166, 117); // walang kulay
            Borrowedlistbtn.BackColor = Color.FromArgb(204, 166, 117); // walang kulay
            ReservationBtn.BackColor = Color.FromArgb(204, 166, 117); // walang kulay
            Accountbtn.BackColor = Color.FromArgb(204, 166, 117); // walang kulay

            Addbtn.BackColor = Color.FromArgb(183, 149, 105); // may kulay


        }

        private void Editbtn_Click(object sender, EventArgs e)
        {
            editBookUC1.Show();
            editBookUC1.BringToFront();

            addBookUC1.Hide();
            homeUC1.Hide();
            bookListUC1.Hide();
            borrowedListUC1.Hide();
            reserveUC1.Hide();
            accountUC1.Hide();

            //btn color
            Homebtn.BackColor = Color.FromArgb(204, 166, 117); // walang kulay
            Addbtn.BackColor = Color.FromArgb(204, 166, 117); // walang kulay
            Booklistbtn.BackColor = Color.FromArgb(204, 166, 117); // walang kulay
            Borrowedlistbtn.BackColor = Color.FromArgb(204, 166, 117); // walang kulay
            ReservationBtn.BackColor = Color.FromArgb(204, 166, 117); // walang kulay
            Accountbtn.BackColor = Color.FromArgb(204, 166, 117); // walang kulay

            Editbtn.BackColor = Color.FromArgb(183, 149, 105); // may kulay

        }

        private void addBookUC1_Load(object sender, EventArgs e)
        {

        }

        private void Booklistbtn_Click(object sender, EventArgs e)
        {
            bookListUC1.Show();
            bookListUC1.BringToFront();

            addBookUC1.Hide();
            homeUC1.Hide();
            editBookUC1.Hide();
            borrowedListUC1.Hide();
            reserveUC1.Hide();
            accountUC1.Hide();

            //btn color
            Homebtn.BackColor = Color.FromArgb(204, 166, 117); // walang kulay
            Addbtn.BackColor = Color.FromArgb(204, 166, 117); // walang kulay
            Borrowedlistbtn.BackColor = Color.FromArgb(204, 166, 117); // walang kulay
            ReservationBtn.BackColor = Color.FromArgb(204, 166, 117); // walang kulay
            Accountbtn.BackColor = Color.FromArgb(204, 166, 117); // walang kulay
            Editbtn.BackColor = Color.FromArgb(204, 166, 117); // walang kulay

            Booklistbtn.BackColor = Color.FromArgb(183, 149, 105); // may kulay


        }

        private void Borrowedlistbtn_Click(object sender, EventArgs e)
        {
            borrowedListUC1.Show();
            borrowedListUC1.BringToFront();

            addBookUC1.Hide();
            homeUC1.Hide();
            bookListUC1.Hide();
            reserveUC1.Hide();
            accountUC1.Hide();
            editBookUC1.Hide();

            //btn color
            Homebtn.BackColor = Color.FromArgb(204, 166, 117); // walang kulay
            Addbtn.BackColor = Color.FromArgb(204, 166, 117); // walang kulay
            Booklistbtn.BackColor = Color.FromArgb(204, 166, 117); // walang kulay
            ReservationBtn.BackColor = Color.FromArgb(204, 166, 117); // walang kulay
            Editbtn.BackColor = Color.FromArgb(204, 166, 117); // walang kulay
            Accountbtn.BackColor = Color.FromArgb(204, 166, 117); // walang kulay

            Borrowedlistbtn.BackColor = Color.FromArgb(183, 149, 105); // may kulay

        }

        private void ReservationBtn_Click(object sender, EventArgs e)
        {
            reserveUC1.Show();
            reserveUC1.BringToFront();

            addBookUC1.Hide();
            homeUC1.Hide();
            bookListUC1.Hide();
            borrowedListUC1.Hide();
            editBookUC1.Hide();
            accountUC1.Hide();

            //btn color
            Homebtn.BackColor = Color.FromArgb(204, 166, 117); // walang kulay
            Addbtn.BackColor = Color.FromArgb(204, 166, 117); // walang kulay
            Borrowedlistbtn.BackColor = Color.FromArgb(204, 166, 117); // walang kulay
            Booklistbtn.BackColor = Color.FromArgb(204, 166, 117); // walang kulay
            Editbtn.BackColor = Color.FromArgb(204, 166, 117); // walang kulay
            Accountbtn.BackColor = Color.FromArgb(204, 166, 117); // walang kulay

            ReservationBtn.BackColor = Color.FromArgb(183, 149, 105); // may kulay

        }

        private void Accountbtn_Click(object sender, EventArgs e)
        {
            string mysqlCon = "server=127.0.0.1; user=root; database=libbyloop; password=";
            using (MySqlConnection mySqlConnection = new MySqlConnection(mysqlCon))
            {
                try
                {
                    mySqlConnection.Open();

                    string query = "SELECT userType FROM users WHERE id = @userId";
                    using (MySqlCommand cmd = new MySqlCommand(query, mySqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@userId", UserId);
                        string userType = cmd.ExecuteScalar()?.ToString();

                        if (userType == "Admin")
                        {
                            accountUC1.Show();
                            accountUC1.BringToFront();

                            addBookUC1.Hide();
                            homeUC1.Hide();
                            bookListUC1.Hide();
                            borrowedListUC1.Hide();
                            reserveUC1.Hide();
                            editBookUC1.Hide();

                            //btn color
                            Homebtn.BackColor = Color.FromArgb(204, 166, 117); // walang kulay
                            Editbtn.BackColor = Color.FromArgb(204, 166, 117); // walang kulay
                            Addbtn.BackColor = Color.FromArgb(204, 166, 117); // walang kulay
                            Booklistbtn.BackColor = Color.FromArgb(204, 166, 117); // walang kulay
                            Borrowedlistbtn.BackColor = Color.FromArgb(204, 166, 117); // walang kulay
                            ReservationBtn.BackColor = Color.FromArgb(204, 166, 117); // walang kulay

                            Accountbtn.BackColor = Color.FromArgb(183, 149, 105); // may kulay
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void homeUC1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form5 mainForm = new Form5();
            mainForm.Show();
            this.Hide();
        }
    }
}
