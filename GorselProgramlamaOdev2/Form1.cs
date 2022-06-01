using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GorselProgramlamaOdev2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            YazıyaÇevir();
        }

        public void KutularıTemizle()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    control.Text = "";
                }
            }
        }

        private string[][] c = new string[][] {
            new string[]{ "sıfır", "bir", "iki", "üç", "dört", "beş", "altı", "yedi", "sekiz", "dokuz", "on" },
            new string[]{ "", "on", "yirmi", "otuz", "kırk", "elli", "altmış", "yetmiş", "seksen", "doksan", "yüz" },
        };

        public void YazıyaÇevir()
        {
            int number;
            List<string> digitNames = new List<string>();
            if (int.TryParse(output.Text, out number))
            {
                int digits = (int)Math.Ceiling(Math.Log10(number));
                int digit = 0;
                while (number > 0)
                {
                    int remainder = number % 10;

                    try
                    {
                        if (digit < 2)
                        {
                            if (digit == 0 && remainder == 0)
                            {
                                continue;
                            }
                            digitNames.Insert(0, c[digit][remainder]);
                        } else if (digit == 2 || digit == 5)
                        {
                            digitNames.Insert(0, c[1][10]);
                            if (remainder > 1)
                            {
                                digitNames.Insert(0, c[0][remainder]);
                            }
                        }
                        else if (digit == 3)
                        {
                            digitNames.Insert(0, "bin");
                            if (remainder > 1)
                            {
                                digitNames.Insert(0, c[0][remainder]);
                            }
                        } else { 
                            digitNames.Insert(0, c[digit % 2 == 0 ? 1 : 0][remainder]);
                        }
                    } finally
                    {
                        number = number / 10;
                        digit++;
                    }
                }
            }
            string t = "";
            foreach (string digitName in digitNames)
            {
                t += digitName + " ";
            }
            output.Text = t;
        }

        public void Topla()
        {
            int sayi1;
            int sayi2;
            if (int.TryParse(textBox1.Text, out sayi1) && int.TryParse(textBox2.Text, out sayi2))
            {
                Topla(sayi1, sayi2);
            }
        }

        public void Topla(params int[] sayılar)
        {
            int toplam = 0;
            foreach (int sayı in sayılar)
            {
                toplam += sayı;
            }
            output.Text = toplam.ToString();
        }

        public void Çarp()
        {
            int sayi1;
            int sayi2;
            if (int.TryParse(textBox1.Text, out sayi1) && int.TryParse(textBox2.Text, out sayi2))
            {
                output.Text = (sayi1 * sayi2).ToString();
            }
        }

        public void ÜsAl()
        {
            int sayi1;
            int sayi2;
            if (int.TryParse(textBox1.Text, out sayi1) && int.TryParse(textBox2.Text, out sayi2))
            {
                ÜsAl(sayi1, sayi2);
            }
        }

        public void ÜsAl(int sayi1, int sayi2)
        {
            output.Text = ÜsAl2(sayi1, sayi2).ToString();
        }

        public int ÜsAl2(int sayi1, int sayi2)
        {
            return (int) Math.Pow(sayi1, sayi2);
        }

        public void Faktoriyel()
        {
            int sayi1;
            if (int.TryParse(textBox1.Text, out sayi1))
            {
                int num = 1;
                for (int i = sayi1; i > 1; i--)
                {
                    num *= i;
                }
                output.Text = num.ToString();
            }
        }

        public void RastgeleSayı()
        {
            Random random = new Random();
            output.Text = random.Next().ToString();
        }

        public void FormuRenklendir()
        {
            ColorDialog dialog = new ColorDialog
            {
                AnyColor = true,
            };
            if (dialog.ShowDialog() == DialogResult.OK){
                FormuRenklendir(dialog.Color); // Random
            }
        }

        public void FormuRenklendir(Color renk)
        {
            this.BackColor = renk;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KutularıTemizle();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Topla();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            YazıyaÇevir();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Çarp();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ÜsAl();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Faktoriyel();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            RastgeleSayı();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            FormuRenklendir();
        }
    }
}
