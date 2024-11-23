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
    public partial class Form3 : Form
    {
        private int penalty;
        private string isbn;
        public bool IsPaymentComplete { get; private set; } = false;
        public Form3(int penaltyAmount, string bookIsbn)
        {
            InitializeComponent();
            penalty = penaltyAmount;
            isbn = bookIsbn;

            lblTotalAmount.Text = penalty.ToString();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
             try
    {
       
        if (!decimal.TryParse(lblTotalAmount.Text, out decimal totalAmount) || totalAmount <= 0)
        {
            MessageBox.Show("Please enter a valid total amount.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }


        if (!decimal.TryParse(txtPayment.Text, out decimal amountPaid) || amountPaid <= 0)
        {
            MessageBox.Show("Please enter a valid amount paid.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

     
        if (amountPaid < totalAmount)
        {
            MessageBox.Show("Insufficient payment. Please collect the full amount.", "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        decimal change = amountPaid - totalAmount;


        IsPaymentComplete = true;
  
        MessageBox.Show($"Payment successful! Change: {change:C2}", "Payment Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);

 
        this.Close();
    }
    catch (Exception ex)
    {
        MessageBox.Show($"An error occurred while processing the payment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
