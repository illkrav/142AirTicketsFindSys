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
    public partial class DialogForm : Form
    {
        private MainForm _cll;
        public MainForm cll
        {
            get { return _cll; }
            set
            {
                _cll = value;
                recomplList();
            }
        }
        public DialogForm()
        {
            //cll = (MainForm)Parent;

            InitializeComponent();
        }
        private void recomplList()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("New");
            comboBox1.SelectedIndex = 0;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            foreach (var el in _cll.oprt.FlyWays)
            {
                var ret = el.Id.ToString() + "|" + el.Route.Last() + "|";

                string middle = "";
                for (int i = 0; i < el.Route.Length - 1; i++)
                {
                    middle += el.Route[i] + "---";
                }
                if (middle.Length > 0) middle = middle.Remove(middle.Length - 3, 3);

                ret += middle + "|";
                ret += el.Places[0].ToString() + "/" + el.Places[1].ToString() + "|" + el.StartTime.ToString() + "|" + ((int)((el.EndTime - el.StartTime).TotalHours)).ToString() + "h";


                comboBox1.Items.Add(ret);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //var ow = (MainForm)cll;
            if (comboBox1.SelectedItem == "New")
            {
                if (textBox2.Text.Length == 0 || textBox1.Text.Length == 0 || textBox3.Text.Split(',').Length != 2)
                {
                    var er = new Error();
                    er.ShowDialog();
                    return;
                }
                cll.oprt.AddRoute(int.Parse(textBox1.Text), textBox2.Text.Split(','), [int.Parse(textBox3.Text.Split(',')[0]), int.Parse(textBox3.Text.Split(',')[1])], dateTimePicker1.Value, dateTimePicker2.Value);


            }
            else
            {
                Flyway selectedItm = cll.oprt.FlyWays[comboBox1.SelectedIndex - 1];
                selectedItm.Id = int.Parse(textBox1.Text);
                selectedItm.Route = textBox2.Text.Split(',');
                selectedItm.Places = [int.Parse(textBox3.Text.Split(',')[0]), int.Parse(textBox3.Text.Split(',')[1])];
                selectedItm.StartTime = dateTimePicker1.Value;
                selectedItm.EndTime = dateTimePicker2.Value;
            }
                recomplList();
            //textBox1
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > 0) {
                var dl = new onetimeDialog();
                var res = dl.ShowDialog();
                if (res == DialogResult.OK) cll.oprt.DelRoute(comboBox1.SelectedIndex - 1);

                recomplList();
            }
            else
            {
                var er = new Error();
                er.ShowDialog(this);
            }
            
        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            cll.cityUpd();
            base.OnFormClosed(e);
        }

        private void DialogForm_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var dl = new onetimeDialog();
            var res = dl.ShowDialog();
            if (res == DialogResult.OK) cll.oprt.GenRandData();

            recomplList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var dl = new onetimeDialog();
            var res = dl.ShowDialog();
            if (res == DialogResult.OK) cll.oprt.ClearWays();
            recomplList();

        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                dateTimePicker1.Value = DateTime.Now;
                dateTimePicker2.Value = DateTime.Now;
                return;
            }
            Flyway selectedItm = cll.oprt.FlyWays[comboBox1.SelectedIndex-1];
            textBox1.Text = selectedItm.Id.ToString();
            string rout = "";
            foreach(var el in selectedItm.Route)
            {
                rout += el + ",";
            }
            rout = rout.Remove(rout.Length -1, 1);
            textBox2.Text = rout;
            textBox3.Text = selectedItm.Places[0].ToString()+","+selectedItm.Places[1].ToString();
            dateTimePicker1.Value = selectedItm.StartTime;
            dateTimePicker2.Value = selectedItm.EndTime;

        }
    }
}
