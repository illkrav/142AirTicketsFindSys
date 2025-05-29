using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _142AirTicketsFindSys.Forms
{
    public partial class BuyForm : Form
    {
        public MainForm cll;
        public BuyForm()
        {

            InitializeComponent();
        }
        public void initRoute()
        {
            string ret = "";
            foreach (var st in cll.oprt.FlyWays[cll.selectedWay].GetPrettyWay())
            {
                ret += st + "|";
            }
            label2.Text = ret;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            cll.oprt.BuyTicket(cll.selectedWay, int.Parse(textBox1.Text), 0);
            cll.updTable();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
