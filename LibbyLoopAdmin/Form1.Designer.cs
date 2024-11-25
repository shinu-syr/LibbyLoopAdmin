namespace LibbyLoopAdmin
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Homebtn = new System.Windows.Forms.Button();
            this.Addbtn = new System.Windows.Forms.Button();
            this.Editbtn = new System.Windows.Forms.Button();
            this.Booklistbtn = new System.Windows.Forms.Button();
            this.Borrowedlistbtn = new System.Windows.Forms.Button();
            this.ReservationBtn = new System.Windows.Forms.Button();
            this.Accountbtn = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.homeUC1 = new LibbyLoopAdmin.HomeUC();
            this.addBookUC1 = new LibbyLoopAdmin.AddBookUC();
            this.editBookUC1 = new LibbyLoopAdmin.EditBookUC();
            this.bookListUC1 = new LibbyLoopAdmin.BookListUC();
            this.borrowedListUC1 = new LibbyLoopAdmin.BorrowedListUC();
            this.reserveUC1 = new LibbyLoopAdmin.ReserveUC();
            this.accountUC1 = new LibbyLoopAdmin.AccountUC();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(166)))), ((int)(((byte)(117)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.Homebtn);
            this.panel1.Controls.Add(this.Addbtn);
            this.panel1.Controls.Add(this.Editbtn);
            this.panel1.Controls.Add(this.Booklistbtn);
            this.panel1.Controls.Add(this.Borrowedlistbtn);
            this.panel1.Controls.Add(this.ReservationBtn);
            this.panel1.Controls.Add(this.Accountbtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(205, 606);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::LibbyLoopAdmin.Properties.Resources.LogoPng;
            this.pictureBox1.Location = new System.Drawing.Point(15, 34);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(175, 115);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // Homebtn
            // 
            this.Homebtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Homebtn.Cursor = System.Windows.Forms.Cursors.Default;
            this.Homebtn.FlatAppearance.BorderSize = 0;
            this.Homebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Homebtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.Homebtn.Image = global::LibbyLoopAdmin.Properties.Resources.Homeicon;
            this.Homebtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Homebtn.Location = new System.Drawing.Point(5, 167);
            this.Homebtn.Name = "Homebtn";
            this.Homebtn.Padding = new System.Windows.Forms.Padding(23, 0, 0, 0);
            this.Homebtn.Size = new System.Drawing.Size(195, 54);
            this.Homebtn.TabIndex = 7;
            this.Homebtn.Text = "    Home";
            this.Homebtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Homebtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Homebtn.UseVisualStyleBackColor = true;
            this.Homebtn.Click += new System.EventHandler(this.Homebtn_Click);
            // 
            // Addbtn
            // 
            this.Addbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Addbtn.Cursor = System.Windows.Forms.Cursors.Default;
            this.Addbtn.FlatAppearance.BorderSize = 0;
            this.Addbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Addbtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.Addbtn.Image = global::LibbyLoopAdmin.Properties.Resources.Addbookicon;
            this.Addbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Addbtn.Location = new System.Drawing.Point(5, 227);
            this.Addbtn.Name = "Addbtn";
            this.Addbtn.Padding = new System.Windows.Forms.Padding(28, 0, 0, 0);
            this.Addbtn.Size = new System.Drawing.Size(195, 54);
            this.Addbtn.TabIndex = 6;
            this.Addbtn.Text = "    Add book";
            this.Addbtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Addbtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Addbtn.UseVisualStyleBackColor = true;
            this.Addbtn.Click += new System.EventHandler(this.Addbtn_Click);
            // 
            // Editbtn
            // 
            this.Editbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Editbtn.Cursor = System.Windows.Forms.Cursors.Default;
            this.Editbtn.FlatAppearance.BorderSize = 0;
            this.Editbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Editbtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.Editbtn.Image = global::LibbyLoopAdmin.Properties.Resources.editbookicon;
            this.Editbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Editbtn.Location = new System.Drawing.Point(5, 287);
            this.Editbtn.Name = "Editbtn";
            this.Editbtn.Padding = new System.Windows.Forms.Padding(28, 0, 0, 0);
            this.Editbtn.Size = new System.Drawing.Size(195, 54);
            this.Editbtn.TabIndex = 5;
            this.Editbtn.Text = "    Edit book";
            this.Editbtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Editbtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Editbtn.UseVisualStyleBackColor = true;
            this.Editbtn.Click += new System.EventHandler(this.Editbtn_Click);
            // 
            // Booklistbtn
            // 
            this.Booklistbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Booklistbtn.Cursor = System.Windows.Forms.Cursors.Default;
            this.Booklistbtn.FlatAppearance.BorderSize = 0;
            this.Booklistbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Booklistbtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.Booklistbtn.Image = global::LibbyLoopAdmin.Properties.Resources.booklisticon;
            this.Booklistbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Booklistbtn.Location = new System.Drawing.Point(5, 347);
            this.Booklistbtn.Name = "Booklistbtn";
            this.Booklistbtn.Padding = new System.Windows.Forms.Padding(28, 0, 0, 0);
            this.Booklistbtn.Size = new System.Drawing.Size(195, 54);
            this.Booklistbtn.TabIndex = 4;
            this.Booklistbtn.Text = "    Book list";
            this.Booklistbtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Booklistbtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Booklistbtn.UseVisualStyleBackColor = true;
            this.Booklistbtn.Click += new System.EventHandler(this.Booklistbtn_Click);
            // 
            // Borrowedlistbtn
            // 
            this.Borrowedlistbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Borrowedlistbtn.Cursor = System.Windows.Forms.Cursors.Default;
            this.Borrowedlistbtn.FlatAppearance.BorderSize = 0;
            this.Borrowedlistbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Borrowedlistbtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.Borrowedlistbtn.Image = global::LibbyLoopAdmin.Properties.Resources.borrowlisticon;
            this.Borrowedlistbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Borrowedlistbtn.Location = new System.Drawing.Point(5, 407);
            this.Borrowedlistbtn.Name = "Borrowedlistbtn";
            this.Borrowedlistbtn.Padding = new System.Windows.Forms.Padding(28, 0, 0, 0);
            this.Borrowedlistbtn.Size = new System.Drawing.Size(195, 54);
            this.Borrowedlistbtn.TabIndex = 3;
            this.Borrowedlistbtn.Text = "    Borrowed list";
            this.Borrowedlistbtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Borrowedlistbtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Borrowedlistbtn.UseVisualStyleBackColor = true;
            this.Borrowedlistbtn.Click += new System.EventHandler(this.Borrowedlistbtn_Click);
            // 
            // ReservationBtn
            // 
            this.ReservationBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ReservationBtn.Cursor = System.Windows.Forms.Cursors.Default;
            this.ReservationBtn.FlatAppearance.BorderSize = 0;
            this.ReservationBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReservationBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.ReservationBtn.Image = global::LibbyLoopAdmin.Properties.Resources.reserveationicon;
            this.ReservationBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ReservationBtn.Location = new System.Drawing.Point(5, 467);
            this.ReservationBtn.Name = "ReservationBtn";
            this.ReservationBtn.Padding = new System.Windows.Forms.Padding(28, 0, 0, 0);
            this.ReservationBtn.Size = new System.Drawing.Size(195, 54);
            this.ReservationBtn.TabIndex = 2;
            this.ReservationBtn.Text = "    Reservation";
            this.ReservationBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ReservationBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ReservationBtn.UseVisualStyleBackColor = true;
            this.ReservationBtn.Click += new System.EventHandler(this.ReservationBtn_Click);
            // 
            // Accountbtn
            // 
            this.Accountbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Accountbtn.Cursor = System.Windows.Forms.Cursors.Default;
            this.Accountbtn.FlatAppearance.BorderSize = 0;
            this.Accountbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Accountbtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.Accountbtn.Image = global::LibbyLoopAdmin.Properties.Resources.accounticon;
            this.Accountbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Accountbtn.Location = new System.Drawing.Point(5, 527);
            this.Accountbtn.Name = "Accountbtn";
            this.Accountbtn.Padding = new System.Windows.Forms.Padding(28, 0, 0, 0);
            this.Accountbtn.Size = new System.Drawing.Size(195, 54);
            this.Accountbtn.TabIndex = 1;
            this.Accountbtn.Text = "    Account";
            this.Accountbtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Accountbtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Accountbtn.UseVisualStyleBackColor = true;
            this.Accountbtn.Click += new System.EventHandler(this.Accountbtn_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = global::LibbyLoopAdmin.Properties.Resources.LogOut;
            this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox4.Location = new System.Drawing.Point(792, 5);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(92, 29);
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::LibbyLoopAdmin.Properties.Resources.Minimize;
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Location = new System.Drawing.Point(890, 5);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(49, 29);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::LibbyLoopAdmin.Properties.Resources.Close;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Location = new System.Drawing.Point(945, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(49, 29);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // homeUC1
            // 
            this.homeUC1.Location = new System.Drawing.Point(206, 35);
            this.homeUC1.Name = "homeUC1";
            this.homeUC1.Size = new System.Drawing.Size(795, 565);
            this.homeUC1.TabIndex = 10;
            this.homeUC1.Load += new System.EventHandler(this.homeUC1_Load);
            // 
            // addBookUC1
            // 
            this.addBookUC1.Location = new System.Drawing.Point(206, 35);
            this.addBookUC1.Name = "addBookUC1";
            this.addBookUC1.Size = new System.Drawing.Size(795, 565);
            this.addBookUC1.TabIndex = 9;
            // 
            // editBookUC1
            // 
            this.editBookUC1.Location = new System.Drawing.Point(206, 35);
            this.editBookUC1.Name = "editBookUC1";
            this.editBookUC1.Size = new System.Drawing.Size(795, 565);
            this.editBookUC1.TabIndex = 8;
            // 
            // bookListUC1
            // 
            this.bookListUC1.Location = new System.Drawing.Point(206, 35);
            this.bookListUC1.Name = "bookListUC1";
            this.bookListUC1.Size = new System.Drawing.Size(795, 565);
            this.bookListUC1.TabIndex = 7;
            // 
            // borrowedListUC1
            // 
            this.borrowedListUC1.Location = new System.Drawing.Point(206, 35);
            this.borrowedListUC1.Name = "borrowedListUC1";
            this.borrowedListUC1.Size = new System.Drawing.Size(795, 565);
            this.borrowedListUC1.TabIndex = 6;
            // 
            // reserveUC1
            // 
            this.reserveUC1.Location = new System.Drawing.Point(206, 35);
            this.reserveUC1.Name = "reserveUC1";
            this.reserveUC1.Size = new System.Drawing.Size(795, 565);
            this.reserveUC1.TabIndex = 5;
            // 
            // accountUC1
            // 
            this.accountUC1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.accountUC1.Location = new System.Drawing.Point(206, 35);
            this.accountUC1.Name = "accountUC1";
            this.accountUC1.Size = new System.Drawing.Size(795, 565);
            this.accountUC1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(225)))), ((int)(((byte)(201)))));
            this.ClientSize = new System.Drawing.Size(1000, 606);
            this.Controls.Add(this.homeUC1);
            this.Controls.Add(this.addBookUC1);
            this.Controls.Add(this.editBookUC1);
            this.Controls.Add(this.bookListUC1);
            this.Controls.Add(this.borrowedListUC1);
            this.Controls.Add(this.reserveUC1);
            this.Controls.Add(this.accountUC1);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Accountbtn;
        private System.Windows.Forms.Button Homebtn;
        private System.Windows.Forms.Button Addbtn;
        private System.Windows.Forms.Button Editbtn;
        private System.Windows.Forms.Button Booklistbtn;
        private System.Windows.Forms.Button Borrowedlistbtn;
        private System.Windows.Forms.Button ReservationBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private AccountUC accountUC1;
        private ReserveUC reserveUC1;
        private BorrowedListUC borrowedListUC1;
        private BookListUC bookListUC1;
        private EditBookUC editBookUC1;
        private AddBookUC addBookUC1;
        private HomeUC homeUC1;
    }
}

