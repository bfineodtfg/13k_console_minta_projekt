using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _13k_winform_minta_projekt
{
    class Registration : Login
    {
        private Label thirdLabel = new Label() { Text = "Jelszó ismét:" };
        public TextBox password2 = new TextBox() { PasswordChar = '*' };
        public Registration()
        {
            this.Controls.Add(thirdLabel);
            this.Controls.Add(password2);
            thirdLabel.Top = label2.Bottom + 25;
            thirdLabel.Left = label2.Left;
            thirdLabel.AutoSize = true;
            password2.Left = textBox2.Left;
            password2.Top = thirdLabel.Top;
            button1.Text = "Regisztráció";
        }

        public async override void ClickEvent(object s, EventArgs e)
        {
            if (textBox2.Text == password2.Text)
            {
                string result = await request.Registration(textBox1.Text, textBox2.Text);
                MessageBox.Show(result);
            }
            else
            {
                MessageBox.Show("Nem egyeznek a jelszavak!");
            }
        }
    }
}
