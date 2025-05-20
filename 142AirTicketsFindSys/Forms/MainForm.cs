using Microsoft.VisualBasic;
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
    public partial class MainForm : Form
    {
        public TicketOperator oprt = new("NNN");
        public int selectedWay = -1;
        private Size org_size;
        
        public MainForm()
        {
            oprt.load("db");
            //oprt.addRoute(99, ["Абу-Дабе", "ЛБС", "Анкара"], 999, DateTime.Now.AddDays(5), DateTime.Now.AddDays(8));
            //oprt.save("db");
            
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
            foreach (var el in oprt.flyWays)
            {
                foreach (var name in el.route)
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
            //var rts = oprt.getSortetPrettyRoutes(comboBox1.SelectedItem.ToString());
            var rts = oprt.getSortetRoutes(comboBox1.SelectedItem.ToString());
            tableLayoutPanel1.Controls.Clear();
            rts = rts.OrderBy(x => x.getPrettyWay()[4]).ToList();

            foreach (var el in rts)
            {
                for (int i = 0; i < el.getPrettyWay().Length; i++)
                {

                    var lbl = new Label();
                    //lbl.Width = 230;
                    lbl.AutoSize = true;
                    lbl.Name = oprt.flyWays.IndexOf(el).ToString();
                    lbl.Text = el.getPrettyWay()[i];

                    lbl.Click += slc_clc;
                    tableLayoutPanel1.Controls.Add(lbl);
                }
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
            //var frm2 = new Form(DialogForm);
            var dl = new DialogForm();
            dl.cll = this;
            dl.ShowDialog(this);
        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            oprt.save("db");
            base.OnFormClosed(e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var dl = new BuyForm();
            dl.cll = this;
            dl.initRoute();
            dl.ShowDialog(this);
        }
        private void slc_clc(object sender, EventArgs e)
        {

            Label lb = (Label)sender;
            //lb.Text = lb.Name;
            select_row(int.Parse(lb.Name));

        }
        private void select_row(int id)
        {
            //tableLayoutPanel1.RowStyles.//[BackColor] = Color.Aqua;//Add(BackColor Color.Aqua);
            selectedWay = id;
            foreach (var el in tableLayoutPanel1.Controls.Cast<Control>())
            {
                el.BackColor = el.Name == id.ToString() ? Color.Aqua : Color.Transparent;

            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            tableLayoutPanel1.Size=new Size( (int)(996f *( (float)(this.Size.Width) / (float)(org_size.Width))),373);
            tableLayoutPanel1.Location = new Point((int)(13f * ((float)(this.Size.Width) / (float)(org_size.Width))), 42);
            tableLayoutPanel2.Location = new Point((int)(13f * ((float)(this.Size.Width) / (float)(org_size.Width))), 8);
            tableLayoutPanel2.Size = new Size((int)(996f * ((float)(this.Size.Width) / (float)(org_size.Width))), 36);
            panel1.Size = new Size(183, this.Size.Height - (org_size.Height - 403));//Location = new Point((int)(1015f * ((float)(this.Size.Width) / (float)(org_size.Width))), 12); //new Size((int)(183f * ((float)(this.Size.Width) / (float)(org_size.Width))), 403);
            //panel1.Location = new Point(1015, (int)(12f * ((float)(this.Size.Height) / (float)(org_size.Height))));
            button3.Location = new Point(34, this.Size.Height-(org_size.Height - 377));
        }
    }
}
