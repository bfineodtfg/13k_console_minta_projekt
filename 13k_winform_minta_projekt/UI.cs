using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _13k_console_minta_projekt;

namespace _13k_winform_minta_projekt
{
    public partial class UI : Form
    {
        public UI()
        {
            InitializeComponent();
            Start();
        }
        int index;
        async void Start()
        {
            HttpRequests request = new HttpRequests();
            List<jsonResponseData> fruits = await request.GetPersonalFruits();
            fruits.ForEach(item => listBox1.Items.Add($"Gyümölcs neve: {item.nev}, gyümölcs súlya: {item.suly}, ára: {item.ar}"));
            button1.Click += async (s, e) =>
            {
                if (listBox1.SelectedIndex >= 0)
                {
                    index = listBox1.SelectedIndex;
                    string valami = await request.Delete(fruits[index].id);
                    MessageBox.Show(valami);
                    if (valami == "Sikeres törlés")
                    {
                        listBox1.Items.Remove(fruits[index]);
                        fruits.Remove(fruits[index]);
                    }
                }
            };
        }
    }
}
