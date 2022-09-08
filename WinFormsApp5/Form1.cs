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
    public partial class Window : Form
    {
        List<int> prices = new List<int>();
        public Window()
        {
            InitializeComponent();
            StreamReader sr = new StreamReader("Zapravka.txt", Encoding.UTF8);
            while (sr.Peek() != -1)
            {
                toolStripComboBox1.Items.Add(sr.ReadLine());
                prices.Add(Convert.ToInt32(sr.ReadLine()));
            }
            sr.Close();
            sr = new StreamReader("Kafe.txt", Encoding.UTF8);
            sr.ReadLine();
            textBox4.Text = sr.ReadLine();
            sr.ReadLine();
            textBox5.Text = sr.ReadLine();
            sr.ReadLine();
            textBox6.Text = sr.ReadLine();
            sr.ReadLine();
            textBox7.Text = sr.ReadLine();
            sr.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                label5.Text = (Convert.ToInt32(textBox3.Text) * Convert.ToInt32(textBox1.Text)).ToString();
                textBox2.Visible = false;
                textBox1.Visible = true;
                checkBox2.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                label5.Text = textBox2.Text;
                textBox1.Visible = false;
                textBox2.Visible = true;
                checkBox1.Checked = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
                textBox8.ReadOnly = false;
            else
                textBox8.ReadOnly = true;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
                textBox9.ReadOnly = false;
            else
                textBox9.ReadOnly = true;
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
                textBox10.ReadOnly = false;
            else
                textBox10.ReadOnly = true;
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
                textBox11.ReadOnly = false;
            else
                textBox11.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                label5.Text = (Convert.ToInt32(textBox3.Text) * Convert.ToInt32(textBox1.Text)).ToString();
            else if (checkBox2.Checked)
                label5.Text = textBox2.Text;
            int sum = 0;
            if (checkBox3.Checked)
                sum += Convert.ToInt32(textBox4.Text) * Convert.ToInt32(textBox8.Text);
            if (checkBox4.Checked)
                sum += Convert.ToInt32(textBox5.Text) * Convert.ToInt32(textBox9.Text);
            if (checkBox5.Checked)
                sum += Convert.ToInt32(textBox6.Text) * Convert.ToInt32(textBox10.Text);
            if (checkBox6.Checked)
                sum += Convert.ToInt32(textBox7.Text) * Convert.ToInt32(textBox11.Text);
            label12.Text = sum.ToString();
            label15.Text = (sum + Convert.ToInt32(label5.Text)).ToString();
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox3.Text = prices[toolStripComboBox1.SelectedIndex].ToString();
        }

        private void заправкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("Auto.txt", false);
            sw.WriteLine(toolStripComboBox1.Text);
            sw.WriteLine(textBox3.Text);
            sw.Close();
        }

        private void кафеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("Kafe.txt", false);
            sw.WriteLine(checkBox3.Text);
            sw.WriteLine(textBox4.Text);
            sw.WriteLine(checkBox4.Text);
            sw.WriteLine(textBox5.Text);
            sw.WriteLine(checkBox5.Text);
            sw.WriteLine(textBox6.Text);
            sw.WriteLine(checkBox6.Text);
            sw.WriteLine(textBox7.Text);
            sw.Close();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("Info.txt", false);
            sw.WriteLine(label5.Text);
            sw.WriteLine(label12.Text);
            sw.WriteLine(label15.Text);
            sw.WriteLine(DateTime.Now);
            sw.WriteLine("Zapravka 3, ylica Tarasa Shev4enko 5");
            sw.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("Check.txt", false);
            sw.Write(label15.Text + " ");
            sw.WriteLine(label3.Text);
            sw.WriteLine(DateTime.Now);
            sw.WriteLine("Zapravka 3, ylica Tarasa Shev4enko 5");
            sw.Close();
        }
    }
}
