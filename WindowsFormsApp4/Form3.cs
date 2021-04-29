using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        public static string connStr = "server=localhost;port=3306;username=root;password=root;database=adaman";
        public static MySqlConnection conn = new MySqlConnection(connStr);
        private void button1_Click(object sender, EventArgs e)
        {
     
            string name = textBox1.Text.ToString();
            if (name == "")
            {
                MessageBox.Show("Вы не ввели название товара!");
            }
            else
            {
                conn.Open();
                string sql1 = $"SELECT `product`,`price`,`quantity` FROM `eatery` WHERE product = '{name}'";
                string sql2 = $"SELECT `product`,`price`,`quantity` FROM `health` WHERE product = '{name}'";
                string sql3 = $"SELECT `product`,`price`,`quantity` FROM `potion` WHERE product = '{name}'";
                MySqlCommand command1 = new MySqlCommand(sql1, conn);
                MySqlCommand command2 = new MySqlCommand(sql2, conn);
                MySqlCommand command3 = new MySqlCommand(sql3, conn);
                MySqlDataReader reader1 = command1.ExecuteReader();
                dataGridView2.Rows.Clear();
                while (reader1.Read())
                {
                    //listBox1.Items.Add(reader[0].ToString() + reader[1].ToString() + reader[2].ToString() + reader[3].ToString());
                    dataGridView2.Rows.Add(reader1[0].ToString(), reader1[1].ToString(), reader1[2].ToString(), "eatery");
                }
                reader1.Close();

                MySqlDataReader reader2 = command2.ExecuteReader();
                while (reader2.Read())
                {
                    //listBox1.Items.Add(reader[0].ToString() + reader[1].ToString() + reader[2].ToString() + reader[3].ToString());
                    dataGridView2.Rows.Add(reader2[0].ToString(), reader2[1].ToString(), reader2[2].ToString(), "health");
                }
                reader2.Close();
                MySqlDataReader reader3 = command3.ExecuteReader();

                while (reader3.Read())
                {
                    dataGridView2.Rows.Add(reader3[0].ToString(), reader3[1].ToString(), reader3[2].ToString(), "potion");
                }
                reader3.Close();
                conn.Close();
            }
        }
        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            MessageBox.Show("Товар прибудет " + rand.Next(1, 28) + " числа");
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void документацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Тут вы можете выбрать товар для заказа набрав его название в строке");
        }
    }
}
