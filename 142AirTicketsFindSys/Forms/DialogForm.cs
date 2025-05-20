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
            foreach (var el in _cll.oprt.flyWays)
            {
                var ret = "";
                foreach (var st in el.getPrettyWay())
                {
                    ret += st + "|";
                }

                comboBox1.Items.Add(ret);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //var ow = (MainForm)cll;
            if (textBox2.Text.Length == 0 || textBox1.Text.Length == 0 || textBox3.Text.Length == 0) return;
            cll.oprt.addRoute(int.Parse(textBox1.Text), textBox2.Text.Split(','), int.Parse(textBox3.Text), dateTimePicker1.Value, dateTimePicker2.Value);
            recomplList();
            //textBox1
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dl = new onetimeDialog();
            var res = dl.ShowDialog();
            if (res == DialogResult.OK) cll.oprt.delRoute(comboBox1.SelectedIndex);

            recomplList();
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
            if (res == DialogResult.OK) cll.oprt.genRandData();

            recomplList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var dl = new onetimeDialog();
            var res = dl.ShowDialog();
            if (res == DialogResult.OK) cll.oprt.clearWays();
            recomplList();

        }
    }
}
