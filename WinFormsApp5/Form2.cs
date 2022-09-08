using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WinFormsApp5
{
    public partial class Form2 : Form
    {
        List<int> prices = new List<int>();
        bool option;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "admin" && textBox2.Text == "admin")
            {
                textBox1.Text = "";
                textBox1.Visible = false;
                textBox2.Visible = false;
                textBox3.Visible = true;
                comboBox1.Visible = true;
                textBox2.Text = "";
                label1.Text = "Item";
                label2.Text = "Price";
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = true;
                button5.Visible = true;
                button6.Visible = true;
            }
            else
            {
                StreamReader sr = new StreamReader("Logins.txt", Encoding.UTF8);
                bool login = false;
                bool password = false;
                while (sr.Peek() != -1)
                {
                    if(sr.ReadLine() == textBox1.Text)
                    {
                        login = true;
                    }
                }
                sr.Close();
                sr = new StreamReader("Passwords.txt", Encoding.UTF8);
                while (sr.Peek() != -1 && login)
                {
                    if (sr.ReadLine() == textBox2.Text)
                    {
                        password = true;
                    }
                }
                sr.Close();
                if (password)
                {
                    Window w = new Window();
                    DialogResult res = w.ShowDialog();
                }
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            option = true;
            prices.Clear();
            comboBox1.Items.Clear();
            comboBox1.Text = "";
            textBox2.Text = "";
            StreamReader sr = new StreamReader("Zapravka.txt", Encoding.UTF8);
            string s = "";
            while (sr.Peek() != -1)
            {
                s = sr.ReadLine();
                prices.Add(Convert.ToInt32(sr.ReadLine()));
                comboBox1.Items.Add(s);
            }
            sr.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox3.Text = prices[comboBox1.SelectedIndex].ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            option = false;
            prices.Clear();
            comboBox1.Items.Clear();
            comboBox1.Text = "";
            textBox2.Text = "";
            StreamReader sr = new StreamReader("Kafe.txt", Encoding.UTF8);
            string s = "";
            while (sr.Peek() != -1)
            {
                s = sr.ReadLine();
                prices.Add(Convert.ToInt32(sr.ReadLine()));
                comboBox1.Items.Add(s);
            }
            sr.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StreamWriter sw;
            if (option)
            {
                sw = new StreamWriter("Zapravka.txt", false);
            }
            else
            {
                sw = new StreamWriter("Kafe.txt", false);
            }
            for (int i = 0; i < prices.Count; i++)
            {
                sw.WriteLine(comboBox1.Items[i]);
                sw.WriteLine(prices[i]);
            }
            sw.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            prices[comboBox1.SelectedIndex] = Convert.ToInt32(textBox3.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("Logins.txt", true);
            sw.WriteLine(textBox1.Text);
            sw.Close();
            sw = new StreamWriter("Passwords.txt", true);
            sw.WriteLine(textBox2.Text);
            sw.Close();
            MessageBox.Show("Registration was succesfull");
            Window w = new Window();
            DialogResult res = w.ShowDialog();
        }
    }
}
