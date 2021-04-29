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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        public static string connStr = "server=localhost;port=3306;username=root;password=root;database=adaman";
        public static MySqlConnection conn = new MySqlConnection(connStr);

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void printProduct()
        {
            conn.Open();
            string sql1 = $"SELECT `product`,`price`,`quantity` FROM `eatery`";
            string sql2 = $"SELECT `product`,`price`,`quantity` FROM `health` ";
            string sql3 = $"SELECT `product`,`price`,`quantity` FROM `potion` ";
            MySqlCommand command1 = new MySqlCommand(sql1, conn);
            MySqlCommand command2 = new MySqlCommand(sql2, conn);
            MySqlCommand command3 = new MySqlCommand(sql3, conn);
            MySqlDataReader reader1 = command1.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (reader1.Read())
            {
                //listBox1.Items.Add(reader[0].ToString() + reader[1].ToString() + reader[2].ToString() + reader[3].ToString());
                dataGridView1.Rows.Add(reader1[0].ToString(), reader1[1].ToString(), reader1[2].ToString(), "eatery");
            }
            reader1.Close();

            MySqlDataReader reader2 = command2.ExecuteReader();
            while (reader2.Read())
            {
                //listBox1.Items.Add(reader[0].ToString() + reader[1].ToString() + reader[2].ToString() + reader[3].ToString());
                dataGridView1.Rows.Add(reader2[0].ToString(), reader2[1].ToString(), reader2[2].ToString(), "health");
            }
            reader2.Close();
            MySqlDataReader reader3 = command3.ExecuteReader();

            while (reader3.Read())
            {
                dataGridView1.Rows.Add(reader3[0].ToString(), reader3[1].ToString(), reader3[2].ToString(), "potion");
            }
            reader3.Close();
            conn.Close();
        }
        private void Form5_Load(object sender, EventArgs e)
        {
            printProduct();

        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
      
        private void обновитьТоварыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printProduct();
        }

        private void документацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("При нажатии на кнопку 'Купить' вы оплачиваете товар и терминал печатает чек для получения товара");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = dataGridView1.CurrentRow.Index;
            string b = dataGridView1.Rows[a].Cells.ToString();
            listBox1.Items.Add(dataGridView1.CurrentRow.Cells.ToString());

            //printDocument1.Print();
        }
        

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bmp = new Bitmap(dataGridView1.Size.Width + 10, dataGridView1.Size.Height + 10);
            dataGridView1.DrawToBitmap(bmp, dataGridView1.Bounds);
            e.Graphics.DrawImage(bmp, 0, 0);
        }
    }
}
