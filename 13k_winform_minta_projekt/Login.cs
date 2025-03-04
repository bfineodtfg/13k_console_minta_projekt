using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _13k_console_minta_projekt;

namespace _13k_winform_minta_projekt
{
    class Login : UserControl
    {

        public Label label1;
        public Label label2;
        public TextBox textBox1;
        public TextBox textBox2;
        public Button button1;

        public HttpRequests request = new HttpRequests();

        public Login()
        {
            InitializeComponent();
            button1.Click += ClickEvent;
        }
        public async virtual void ClickEvent(object s, EventArgs e)
        {
            string result = await request.Login(textBox1.Text, textBox2.Text);
            MessageBox.Show(result);
            if (result == "Sikeres belépés, shalom!")
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                button1.Enabled = false;
                UI oneUI = new UI();
                oneUI.Show();
                oneUI.FormClosing += (ss, ee) =>
                {
                    textBox1.Enabled = true;
                    textBox2.Enabled = true;
                    button1.Enabled = true;
                };
            }
        }
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Felhasználónév:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Jelszó:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(193, 38);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(106, 20);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(193, 85);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(106, 20);
            this.textBox2.TabIndex = 3;
            this.textBox2.PasswordChar = '*';
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(102, 169);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Bejelentkezés";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Login
            // 
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Login";
            this.Size = new System.Drawing.Size(354, 243);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
