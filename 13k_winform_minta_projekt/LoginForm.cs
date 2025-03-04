using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _13k_winform_minta_projekt
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            button1.Click += RegistrationClick;
        }
        void RegistrationClick(object s, EventArgs e)
        {
            this.Hide();
            RegistrationForm form = new RegistrationForm();
            form.Show();
            form.FormClosing += (ss, ee) =>
            {
                this.Show();
            };
        }
    }
}
