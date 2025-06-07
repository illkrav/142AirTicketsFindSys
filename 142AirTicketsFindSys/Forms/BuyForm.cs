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

            var el = cll.oprt.FlyWays[cll.selectedWay];
            var ret = el.Id.ToString() + "|" + el.Route.Last() + "|";

            string middle = "";
            for (int i = 0; i < el.Route.Length - 1; i++)
            {
                middle += el.Route[i] + "---";
            }
            middle = middle.Remove(middle.Length - 3, 3);
            ret += middle + "|";
            ret += el.Places[0].ToString() + "/" + el.Places[1].ToString() + "|" + el.StartTime.ToString() + "|" + ((int)((el.EndTime - el.StartTime).TotalHours)).ToString() + "h";

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
