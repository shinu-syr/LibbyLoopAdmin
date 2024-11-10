namespace LibbyLoopAdmin
{
    partial class AddBookUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.addBook = new System.Windows.Forms.Button();
            this.txtBookTitle = new System.Windows.Forms.TextBox();
            this.txtBookAuthor = new System.Windows.Forms.TextBox();
            this.txtBookIsbn = new System.Windows.Forms.TextBox();
            this.txtBookCategory = new System.Windows.Forms.TextBox();
            this.addPic = new System.Windows.Forms.Button();
            this.mySqlConnection1 = new MySql.Data.MySqlClient.MySqlConnection();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BookList = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BookList)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.label1.Location = new System.Drawing.Point(71, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Book title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.label2.Location = new System.Drawing.Point(71, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Author";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.label3.Location = new System.Drawing.Point(71, 210);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "ISBN";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.label4.Location = new System.Drawing.Point(71, 277);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Category";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.label5.Location = new System.Drawing.Point(375, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Book list";
            // 
            // addBook
            // 
            this.addBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(187)))), ((int)(((byte)(131)))));
            this.addBook.FlatAppearance.BorderSize = 0;
            this.addBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addBook.Location = new System.Drawing.Point(210, 404);
            this.addBook.Name = "addBook";
            this.addBook.Size = new System.Drawing.Size(150, 104);
            this.addBook.TabIndex = 12;
            this.addBook.Text = "Add Book";
            this.addBook.UseVisualStyleBackColor = false;
            this.addBook.Click += new System.EventHandler(this.addBook_Click);
            // 
            // txtBookTitle
            // 
            this.txtBookTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(241)))), ((int)(((byte)(225)))));
            this.txtBookTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBookTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtBookTitle.Location = new System.Drawing.Point(81, 98);
            this.txtBookTitle.Name = "txtBookTitle";
            this.txtBookTitle.Size = new System.Drawing.Size(271, 16);
            this.txtBookTitle.TabIndex = 13;
            this.txtBookTitle.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtBookAuthor
            // 
            this.txtBookAuthor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(241)))), ((int)(((byte)(225)))));
            this.txtBookAuthor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBookAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtBookAuthor.Location = new System.Drawing.Point(81, 168);
            this.txtBookAuthor.Name = "txtBookAuthor";
            this.txtBookAuthor.Size = new System.Drawing.Size(271, 16);
            this.txtBookAuthor.TabIndex = 15;
            // 
            // txtBookIsbn
            // 
            this.txtBookIsbn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(241)))), ((int)(((byte)(225)))));
            this.txtBookIsbn.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBookIsbn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtBookIsbn.Location = new System.Drawing.Point(81, 237);
            this.txtBookIsbn.Name = "txtBookIsbn";
            this.txtBookIsbn.Size = new System.Drawing.Size(271, 16);
            this.txtBookIsbn.TabIndex = 16;
            // 
            // txtBookCategory
            // 
            this.txtBookCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(241)))), ((int)(((byte)(225)))));
            this.txtBookCategory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBookCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtBookCategory.Location = new System.Drawing.Point(81, 304);
            this.txtBookCategory.Name = "txtBookCategory";
            this.txtBookCategory.Size = new System.Drawing.Size(271, 16);
            this.txtBookCategory.TabIndex = 17;
            // 
            // addPic
            // 
            this.addPic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(187)))), ((int)(((byte)(131)))));
            this.addPic.FlatAppearance.BorderSize = 0;
            this.addPic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addPic.Location = new System.Drawing.Point(210, 348);
            this.addPic.Name = "addPic";
            this.addPic.Size = new System.Drawing.Size(150, 44);
            this.addPic.TabIndex = 19;
            this.addPic.Text = "Choose Image";
            this.addPic.UseVisualStyleBackColor = false;
            this.addPic.Click += new System.EventHandler(this.addPic_Click);
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackgroundImage = global::LibbyLoopAdmin.Properties.Resources.displPic;
            this.pictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox6.Location = new System.Drawing.Point(74, 348);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(130, 160);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 18;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackgroundImage = global::LibbyLoopAdmin.Properties.Resources.BookList;
            this.pictureBox5.Location = new System.Drawing.Point(378, 91);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(352, 417);
            this.pictureBox5.TabIndex = 8;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = global::LibbyLoopAdmin.Properties.Resources.textBox;
            this.pictureBox4.Location = new System.Drawing.Point(74, 297);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(286, 30);
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::LibbyLoopAdmin.Properties.Resources.textBox;
            this.pictureBox3.Location = new System.Drawing.Point(74, 230);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(286, 30);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::LibbyLoopAdmin.Properties.Resources.textBox;
            this.pictureBox2.Location = new System.Drawing.Point(74, 161);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(286, 30);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::LibbyLoopAdmin.Properties.Resources.textBox;
            this.pictureBox1.Location = new System.Drawing.Point(74, 91);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(286, 30);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // BookList
            // 
            this.BookList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(241)))), ((int)(((byte)(225)))));
            this.BookList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.BookList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BookList.Location = new System.Drawing.Point(384, 96);
            this.BookList.Name = "BookList";
            this.BookList.Size = new System.Drawing.Size(339, 407);
            this.BookList.TabIndex = 20;
            this.BookList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.BookList_CellContentClick);
            // 
            // AddBookUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BookList);
            this.Controls.Add(this.addPic);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.txtBookCategory);
            this.Controls.Add(this.txtBookIsbn);
            this.Controls.Add(this.txtBookAuthor);
            this.Controls.Add(this.txtBookTitle);
            this.Controls.Add(this.addBook);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "AddBookUC";
            this.Size = new System.Drawing.Size(795, 565);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BookList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button addBook;
        private System.Windows.Forms.TextBox txtBookTitle;
        private System.Windows.Forms.TextBox txtBookAuthor;
        private System.Windows.Forms.TextBox txtBookIsbn;
        private System.Windows.Forms.TextBox txtBookCategory;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Button addPic;
        private MySql.Data.MySqlClient.MySqlConnection mySqlConnection1;
        private System.Windows.Forms.DataGridView BookList;
    }
}
