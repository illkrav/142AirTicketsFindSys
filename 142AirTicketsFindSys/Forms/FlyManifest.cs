using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _142AirTicketsFindSys.Forms
{
    public partial class FlyManifest : Form
    {
        public MainForm cll;
        public FlyManifest()
        {
            InitializeComponent();

        }
        private string[] FormPreview()
        {
            string[] text = new string[10];
            Flyway selectedWay = cll.oprt.FlyWays[cll.selectedWay];
            text[0] = "ПОСАДКОВА ВІДОМІСТЬ";
            text[1] = "-------------------";
            text[2] = "Рейс: "+selectedWay.Id.ToString();
            text[3] = "Дата відльоту: " + selectedWay.StartTime.ToString();
            text[4] = "Дата прильоту: " + selectedWay.EndTime.ToString();
            string middle = "";
            for (int i = 0; i < selectedWay.Route.Length; i++)
            {
                middle += selectedWay.Route[i] + "---";
            }
            middle = middle.Remove(middle.Length - 3, 3);
            text[5] = "Маршрут: " + middle;
            text[6] = "-------------------";
            text[7] = "Загальна кількість пасажирів: " + (120-selectedWay.Places[0] - selectedWay.Places[1]).ToString();
            text[8] = "Першого класу: " + (30-selectedWay.Places[0]).ToString();
            text[9] = "Другого класу: " + (90-selectedWay.Places[1]).ToString();
            return text;
        }
        public void SetTextPreview()
        {
            richTextBox1.Lines = FormPreview();
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
