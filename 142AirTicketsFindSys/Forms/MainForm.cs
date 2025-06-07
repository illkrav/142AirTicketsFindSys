using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _142AirTicketsFindSys.Forms
{
    public partial class MainForm : Form
    {
        public TicketOperator oprt = new();
        public int selectedWay = -1;
        private Size org_size;

        public MainForm()
        {
            oprt.Load("db");
            

            InitializeComponent();
            org_size = this.Size;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            cityUpd();
        }
        public void cityUpd()
        {
            var lst = new List<string>();
            foreach (var el in oprt.FlyWays)
            {
                foreach (var name in el.Route)
                {
                    if (lst.IndexOf(name) == -1) lst.Add(name);

                }


            }
            lst = lst.OrderBy(x => x).ToList();
            comboBox1.Items.Clear();
            foreach (var el in lst)
            {
                comboBox1.Items.Add(el);
            }
        }

        public void updTable()
        {
            if (comboBox1.SelectedItem == null) return;
            
            var rts = oprt.GetSortetRoutes(comboBox1.SelectedItem.ToString());
            tableLayoutPanel1.Controls.Clear();
            

            foreach (var el in rts)
            {
                Label[] lbss = new Label[6];
                for (int i = 0; i < 6; i++)
                {

                    var lbl = new Label();
                    
                    lbl.AutoSize = true;
                    lbl.Name = oprt.FlyWays.IndexOf(el).ToString();

                    

                    lbl.Click += slc_clc;
                    lbss[i] = lbl;
                    tableLayoutPanel1.Controls.Add(lbl);
                }
                lbss[0].Text = el.Id.ToString();
                lbss[1].Text = el.Route.Last();
                string middle = "";
                for (int i = 0; i < el.Route.Length - 1; i++)
                {
                    middle += el.Route[i] + "---";
                }
                if (middle.Length > 0) middle = middle.Remove(middle.Length - 3, 3);
                lbss[2].Text = middle;
                lbss[3].Text = el.Places[0].ToString() + "|" + el.Places[1].ToString();
                lbss[4].Text = el.StartTime.ToString();
                lbss[5].Text = ((int)((el.EndTime - el.StartTime).TotalHours)).ToString() + "h";
                tableLayoutPanel1.RowCount += 1;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            selectedWay = -1;
            updTable();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            var dl = new DialogForm();
            dl.cll = this;
            dl.ShowDialog(this);
        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            oprt.Save("db");
            base.OnFormClosed(e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (selectedWay == -1)
            {
                var er = new Error();
                er.ShowDialog(this);
            }
            else
            {
                var dl = new BuyForm();
                dl.cll = this;
                dl.initRoute();
                dl.ShowDialog(this); 
            }
        }
        private void slc_clc(object sender, EventArgs e)
        {

            Label lb = (Label)sender;
            
            select_row(int.Parse(lb.Name));

        }
        private void select_row(int id)
        {
            
            selectedWay = id;
            foreach (var el in tableLayoutPanel1.Controls.Cast<Control>())
            {
                el.BackColor = el.Name == id.ToString() ? Color.Aqua : Color.Transparent;

            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            tableLayoutPanel1.Size = new Size((int)(996f * ((float)(this.Size.Width) / (float)(org_size.Width))), this.Size.Height - (org_size.Height - 373));
            tableLayoutPanel1.Location = new Point((int)(13f * ((float)(this.Size.Width) / (float)(org_size.Width))), 42);
            tableLayoutPanel2.Location = new Point((int)(12f * ((float)(this.Size.Width) / (float)(org_size.Width))), 21);
            tableLayoutPanel2.Size = new Size((int)(997f * ((float)(this.Size.Width) / (float)(org_size.Width))), 23);
            panel1.Size = new Size(183, this.Size.Height - (org_size.Height - 403));
            
        }

        private void label8_Click(object sender, EventArgs e)
        {
            if (selectedWay == -1)
            {
                var er = new Error();
                er.ShowDialog(this);
            }
            else 
            { 
                var dl = new FlyManifest();
                dl.cll = this;
                dl.SetTextPreview();
                dl.ShowDialog(this);
            }
        }
    }
}
