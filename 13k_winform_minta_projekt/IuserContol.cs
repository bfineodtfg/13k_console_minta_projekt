using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _13k_winform_minta_projekt
{
    interface IuserContol
    {
        Button button { get; set; }
        TextBox input1 { get; set; }
        TextBox input2 { get; set; }
    }
}
