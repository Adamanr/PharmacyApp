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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        public static string connStr = "server=localhost;port=3306;username=root;password=root;database=adaman";
        public static MySqlConnection conn = new MySqlConnection(connStr);
 
        public void printProvider(string fase)
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Rows.Clear();
            conn.Open();
            string sql = "SELECT  product,price,quantity FROM " + fase;
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString());

            }
            reader.Close();
            conn.Close();

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    printProvider("eatery");
                    break;
                case 1:
                    printProvider("health");
                    break;
                case 2:
                    printProvider("potion");
                    break;
            }
        }

        private void документацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Форма 'Склад поставщиков' - позволяет узнать какие товары имеются у поставщиков в настоящее время");
        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
