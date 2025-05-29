namespace _142AirTicketsFindSys.Forms
{
    partial class BuyForm
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
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            label3 = new Label();
            button1 = new Button();
            button2 = new Button();
            comboBox1 = new ComboBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(53, 9);
            label1.Name = "label1";
            label1.Size = new Size(276, 15);
            label1.TabIndex = 0;
            label1.Text = "Ви впевнені що хочете придбати квитки на рейс:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(53, 38);
            label2.Name = "label2";
            label2.Size = new Size(149, 15);
            label2.TabIndex = 1;
            label2.Text = "TESTREIS|ABOBA|AAA|6786";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(53, 124);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(87, 23);
            textBox1.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(53, 85);
            label3.Name = "label3";
            label3.Size = new Size(103, 15);
            label3.TabIndex = 3;
            label3.Text = "Кількість квитків?";
            // 
            // button1
            // 
            button1.Location = new Point(53, 200);
            button1.Name = "button1";
            button1.Size = new Size(201, 55);
            button1.TabIndex = 4;
            button1.Text = "Buy";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(348, 198);
            button2.Name = "button2";
            button2.Size = new Size(176, 57);
            button2.TabIndex = 5;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Перший класс", "Другий класс" });
            comboBox1.Location = new Point(200, 124);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(153, 23);
            comboBox1.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(206, 88);
            label4.Name = "label4";
            label4.Size = new Size(105, 15);
            label4.TabIndex = 7;
            label4.Text = "Тип квитка(класс)";
            // 
            // BuyForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(554, 276);
            Controls.Add(label4);
            Controls.Add(comboBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "BuyForm";
            Text = "BuyForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private Label label3;
        private Button button1;
        private Button button2;
        private ComboBox comboBox1;
        private Label label4;
    }
}