using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace TaskPerformance1
{
    public partial class CashierWindowQueueForm : Form
    {

        public CashierWindowQueueForm()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            DisplayCashierQueue(CashierClass.CashierQueue);
        }
        public void DisplayCashierQueue(IEnumerable CashierList)
        {
            listCashierQueue.Items.Clear();
            foreach (Object obj in CashierList)
            {
                listCashierQueue.Items.Add(obj.ToString());
            }
        }
        private void CashierWindowQueueForm_Load(object sender, EventArgs e)
        {

        }

        private void Next_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;

            if (CashierClass.CashierQueue.Count == 0)
            {
                MessageBox.Show("Number in Queue List is 0");
            }
            try
            {

                lblQueueNowServing.Text = CashierClass.CashierQueue.Peek();

            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Number in Queue List is 0");
                Console.WriteLine(ex);
                timer1.Stop();

            }
            finally
            {
                CashierClass.CashierQueue.Dequeue();
            }


        }


    }
}
        
    

