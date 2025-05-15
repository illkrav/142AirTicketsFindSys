namespace _142AirTicketsFindSys.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            button2 = new Button();
            comboBox1 = new ComboBox();
            button1 = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(button2);
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(1015, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(183, 403);
            panel1.TabIndex = 0;
            // 
            // button2
            // 
            button2.Location = new Point(9, 105);
            button2.Name = "button2";
            button2.Size = new Size(165, 32);
            button2.TabIndex = 2;
            button2.Text = "Buy";
            button2.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Абу-Дабе", "Анкара", "Тель-Авив", "ЛБС" });
            comboBox1.Location = new Point(9, 9);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(165, 23);
            comboBox1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(8, 51);
            button1.Name = "button1";
            button1.Size = new Size(167, 31);
            button1.TabIndex = 0;
            button1.Text = "Search";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoScroll = true;
            tableLayoutPanel1.ColumnCount = 6;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40.39409F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 59.60591F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 187F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 190F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 154F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 129F));
            tableLayoutPanel1.Location = new Point(13, 10);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(996, 405);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1201, 467);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel1);
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private Button button1;
        private ComboBox comboBox1;
        private Button button2;
    }
}