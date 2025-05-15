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
        TicketOperator oprt = new("Косово");
        public MainForm()
        {
            oprt.load("db");
            //oprt.addRoute(99, ["Абу-Дабе", "ЛБС", "Анкара"], 999, DateTime.Now.AddDays(5), DateTime.Now.AddDays(8));
            //oprt.save("db");
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            foreach(var el in oprt.flyWays) {
                foreach(var name in el.route)
                {
                    if(comboBox1.Items.IndexOf(name)==-1) comboBox1.Items.Add(name);
                    
                }
                
                    
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var rts = oprt.getSortetPrettyRoutes(comboBox1.SelectedItem.ToString());
            tableLayoutPanel1.Controls.Clear();


            foreach (var el in rts)
            {
                for (int i = 0; i < el.Length; i++) { 
                    
                    var lbl = new Label();
                    lbl.Width=230;
                    lbl.Text = el[i];
                    tableLayoutPanel1.Controls.Add(lbl);
                }
                tableLayoutPanel1.RowCount += 1;
            }
        }
    }
}
