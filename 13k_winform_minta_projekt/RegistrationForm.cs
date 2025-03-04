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
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
            button1.Click += BackClick;
        }
        void BackClick(object s, EventArgs e)
        {
            this.Close();
        }
    }
}
