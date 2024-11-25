using System;
using System.Windows.Forms;

namespace LibbyLoopAdmin
{
    partial class EditBookUC
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BookList = new System.Windows.Forms.DataGridView();
            this.addPic = new System.Windows.Forms.Button();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.txtBookCategory = new System.Windows.Forms.TextBox();
            this.txtBookIsbn = new System.Windows.Forms.TextBox();
            this.txtBookAuthor = new System.Windows.Forms.TextBox();
            this.txtBookTitle = new System.Windows.Forms.TextBox();
            this.EditBook = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.BookList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.SuspendLayout();
            // 
            // BookList
            // 
            this.BookList.AllowUserToAddRows = false;
            this.BookList.AllowUserToDeleteRows = false;
            this.BookList.AllowUserToResizeColumns = false;
            this.BookList.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(241)))), ((int)(((byte)(225)))));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(166)))), ((int)(((byte)(117)))));
            this.BookList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.BookList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(241)))), ((int)(((byte)(225)))));
            this.BookList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.BookList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(241)))), ((int)(((byte)(225)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(166)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.BookList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.BookList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(241)))), ((int)(((byte)(225)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(166)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.BookList.DefaultCellStyle = dataGridViewCellStyle8;
            this.BookList.EnableHeadersVisualStyles = false;
            this.BookList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.BookList.Location = new System.Drawing.Point(337, 116);
            this.BookList.Name = "BookList";
            this.BookList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(241)))), ((int)(((byte)(225)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(166)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.BookList.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.BookList.RowHeadersWidth = 62;
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(166)))), ((int)(((byte)(117)))));
            this.BookList.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.BookList.Size = new System.Drawing.Size(422, 407);
            this.BookList.TabIndex = 38;
            this.BookList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.BookList_CellContentClick);
            // 
            // addPic
            // 
            this.addPic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(187)))), ((int)(((byte)(131)))));
            this.addPic.FlatAppearance.BorderSize = 0;
            this.addPic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addPic.ForeColor = System.Drawing.Color.White;
            this.addPic.Location = new System.Drawing.Point(168, 368);
            this.addPic.Name = "addPic";
            this.addPic.Size = new System.Drawing.Size(150, 44);
            this.addPic.TabIndex = 37;
            this.addPic.Text = "Update Image";
            this.addPic.UseVisualStyleBackColor = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackgroundImage = global::LibbyLoopAdmin.Properties.Resources.displPic;
            this.pictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox6.Location = new System.Drawing.Point(32, 368);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(120, 161);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 36;
            this.pictureBox6.TabStop = false;
            // 
            // txtBookCategory
            // 
            this.txtBookCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(241)))), ((int)(((byte)(225)))));
            this.txtBookCategory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBookCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtBookCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.txtBookCategory.Location = new System.Drawing.Point(39, 324);
            this.txtBookCategory.Name = "txtBookCategory";
            this.txtBookCategory.Size = new System.Drawing.Size(271, 16);
            this.txtBookCategory.TabIndex = 35;
            // 
            // txtBookIsbn
            // 
            this.txtBookIsbn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(241)))), ((int)(((byte)(225)))));
            this.txtBookIsbn.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBookIsbn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtBookIsbn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.txtBookIsbn.Location = new System.Drawing.Point(39, 257);
            this.txtBookIsbn.Name = "txtBookIsbn";
            this.txtBookIsbn.Size = new System.Drawing.Size(271, 16);
            this.txtBookIsbn.TabIndex = 34;
            // 
            // txtBookAuthor
            // 
            this.txtBookAuthor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(241)))), ((int)(((byte)(225)))));
            this.txtBookAuthor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBookAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtBookAuthor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.txtBookAuthor.Location = new System.Drawing.Point(39, 188);
            this.txtBookAuthor.Name = "txtBookAuthor";
            this.txtBookAuthor.Size = new System.Drawing.Size(271, 16);
            this.txtBookAuthor.TabIndex = 33;
            // 
            // txtBookTitle
            // 
            this.txtBookTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(241)))), ((int)(((byte)(225)))));
            this.txtBookTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBookTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtBookTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.txtBookTitle.Location = new System.Drawing.Point(39, 118);
            this.txtBookTitle.Name = "txtBookTitle";
            this.txtBookTitle.Size = new System.Drawing.Size(271, 16);
            this.txtBookTitle.TabIndex = 32;
            // 
            // EditBook
            // 
            this.EditBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(187)))), ((int)(((byte)(131)))));
            this.EditBook.FlatAppearance.BorderSize = 0;
            this.EditBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditBook.ForeColor = System.Drawing.Color.White;
            this.EditBook.Location = new System.Drawing.Point(168, 425);
            this.EditBook.Name = "EditBook";
            this.EditBook.Size = new System.Drawing.Size(150, 104);
            this.EditBook.TabIndex = 31;
            this.EditBook.Text = "Apply Changes";
            this.EditBook.UseVisualStyleBackColor = false;
            this.EditBook.Click += new System.EventHandler(this.EditBook_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.label5.Location = new System.Drawing.Point(328, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 17);
            this.label5.TabIndex = 30;
            this.label5.Text = "Book list";
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackgroundImage = global::LibbyLoopAdmin.Properties.Resources.BookList;
            this.pictureBox5.Location = new System.Drawing.Point(332, 111);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(352, 417);
            this.pictureBox5.TabIndex = 29;
            this.pictureBox5.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.label4.Location = new System.Drawing.Point(29, 297);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 17);
            this.label4.TabIndex = 28;
            this.label4.Text = "Category";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.label3.Location = new System.Drawing.Point(29, 230);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 17);
            this.label3.TabIndex = 27;
            this.label3.Text = "ISBN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.label2.Location = new System.Drawing.Point(29, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 17);
            this.label2.TabIndex = 26;
            this.label2.Text = "Author";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.label1.Location = new System.Drawing.Point(29, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 25;
            this.label1.Text = "Book title";
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = global::LibbyLoopAdmin.Properties.Resources.textBox;
            this.pictureBox4.Location = new System.Drawing.Point(32, 317);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(286, 30);
            this.pictureBox4.TabIndex = 24;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::LibbyLoopAdmin.Properties.Resources.textBox;
            this.pictureBox3.Location = new System.Drawing.Point(32, 250);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(286, 30);
            this.pictureBox3.TabIndex = 23;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::LibbyLoopAdmin.Properties.Resources.textBox;
            this.pictureBox2.Location = new System.Drawing.Point(32, 181);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(286, 30);
            this.pictureBox2.TabIndex = 22;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::LibbyLoopAdmin.Properties.Resources.textBox;
            this.pictureBox1.Location = new System.Drawing.Point(32, 111);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(286, 30);
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackgroundImage = global::LibbyLoopAdmin.Properties.Resources.BookList;
            this.pictureBox7.Location = new System.Drawing.Point(412, 111);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(352, 417);
            this.pictureBox7.TabIndex = 39;
            this.pictureBox7.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(26, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(164, 33);
            this.label6.TabIndex = 40;
            this.label6.Text = "EDIT BOOKS";
            // 
            // EditBookUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BookList);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.addPic);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.txtBookCategory);
            this.Controls.Add(this.txtBookIsbn);
            this.Controls.Add(this.txtBookAuthor);
            this.Controls.Add(this.txtBookTitle);
            this.Controls.Add(this.EditBook);
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
            this.Name = "EditBookUC";
            this.Size = new System.Drawing.Size(795, 565);
            this.Load += new System.EventHandler(this.EditBookUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BookList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void EditBookUC_Load(object sender, EventArgs e)
        {
 
        }

        private void BookList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        #endregion

        private System.Windows.Forms.DataGridView BookList;
        private System.Windows.Forms.Button addPic;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.TextBox txtBookCategory;
        private System.Windows.Forms.TextBox txtBookIsbn;
        private System.Windows.Forms.TextBox txtBookAuthor;
        private System.Windows.Forms.TextBox txtBookTitle;
        private System.Windows.Forms.Button EditBook;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private PictureBox pictureBox7;
        private Label label6;
    }
}
