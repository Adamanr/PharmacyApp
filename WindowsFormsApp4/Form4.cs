using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        /**************************************************Переменные подключения к db***********/
        public static string connStr = "server=localhost;port=3306;username=root;password=root;database=adaman";
        public static MySqlConnection conn = new MySqlConnection(connStr);

        private void button5_Click(object sender, EventArgs e)
        {
            int quantity = (int)numericUpDown1.Value;
            string price = textBox1.Text;
            int cu = quantity;
            double gu = Convert.ToDouble(price);
            textBox2.Text = ($"{quantity * gu}");
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /*****************************************Меню************************************************/
        private void открытьКлиентскийВидToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void документацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Кнопки программы:\n" +
                "1.Добавить - при полном выборе нужных медикаментов товар заказывается и добавляется в требуемые\n" +
                "2.Удалить - при ошибочном заказе товар можно удалить в течении 24 ч.\n" +
                "3.Обновить - для просмотра медикаментов которые находятся на складе\n" +
                "4.Печать - для печати докладной о заказанных медикаментах");
        }
        private void документацияToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
        private void поставщикиToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        /*********************************************Открывает форму поставщиков ******************************/

        /*********************************************Выводит название товара******************************/
        private void comboBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            switch (comboBox3.SelectedIndex)
            {
                case 0:
                    printProduct("health");
                    break;
                case 1:
                    printProduct("potion");
                    break;
                case 3:
                    printProduct("eatery");
                    break;
            }
        }
        /*********************************************Название товара в combobox2******************************/

        public void printProduct(String productName)
        {
            conn.Open();
            string sql = "SELECT  `product` FROM " + productName;
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            comboBox2.Items.Clear();
            comboBox2.Text = "";
            while (reader.Read())
            {
                comboBox2.Items.Add(reader[0].ToString());
            }
            reader.Close();
            conn.Close();
        }
        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
            numericUpDown1.Value = 1;
            textBox1.Clear();
            textBox2.Clear();
            printSklad();

        }


        /*********************************************Общая цена по количеству******************************/

        private void numericUpDown1_ValueChanged_2(object sender, EventArgs e)
        {
            int quantity = (int)numericUpDown1.Value;
            textBox1.Text = ($"{Convert.ToDouble(textBox2.Text.ToString()) * quantity}");
        }

        /*********************************************Удаление элемента******************************/

        private void deletedElem_Click(object sender, EventArgs e)
        {
            int f = Convert.ToInt32(dataGridView2.CurrentCell.Value.ToString());
            MySqlConnection connection = new MySqlConnection(connStr);
            connection.Open();
            string sql = "DELETE FROM `products` WHERE id = " + f;
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.ExecuteNonQuery();
            string sql1 = "SELECT `id`,`product`,`quantity`,`price`,`fullPrice`,`provider` FROM `products` ";
            MySqlCommand command1 = new MySqlCommand(sql1, connection);
            MySqlDataReader reader = command1.ExecuteReader();
            dataGridView2.Rows.Clear();
            while (reader.Read())
            {
                dataGridView2.Rows.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString());

            }
            reader.Close();
            connection.Close();
           
        }

        /*********************************************Не разобрался******************************/

        private void button7_Click_1(object sender, EventArgs e)
        {
            conn.Open();
            string sql = "SELECT  id FROM products ";
            MySqlCommand command = new MySqlCommand(sql, conn);
            DB db = new DB();
            MySqlConnection connection = new MySqlConnection(connStr);
            connection.Open();
            MySqlCommand commands = new MySqlCommand("INSERT INTO `products` (`ta`) VALUES (@ta);", db.GetConnection());
            string sql1 = "SELECT `product`,`price`,`quantity`,`fullPrice`,`provider` FROM `products` ";
            MySqlCommand commandte = new MySqlCommand(sql1, conn);
            MySqlDataReader reader = commandte.ExecuteReader();
            while (reader.Read())
            {
                //listBox5.Items.Add(reader[0].ToString() + " " + reader[1].ToString() + " " + reader[2].ToString() + " " + reader[3].ToString() + " " + reader[4].ToString());
            }
            reader.Close();
            connection.Close();
            conn.Close();
        }

        /*********************************************Обновление товаров******************************/

        private void Reload_Click(object sender, EventArgs e)
        {
            
            conn.Open();
            string sql = "SELECT `id`,`product`,`quantity`,`price`,`fullPrice`,`provider` FROM `products` ";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            dataGridView2.Rows.Clear();
            while (reader.Read())
            {
                dataGridView2.Rows.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString());

            }
            reader.Close();
            conn.Close();
        }

        /*********************************************Документации админки******************************/


        /*********************************************Добавляет товар******************************/
        private void button6_Click_1(object sender, EventArgs e)
        {
            
            string product = comboBox2.SelectedItem.ToString();
            int id = 1;
            int quantity = (int)numericUpDown1.Value;
            string provider = comboBox3.SelectedItem.ToString();
            double price = Convert.ToDouble(textBox1.Text);
            double fullPrice = Convert.ToDouble(textBox2.Text);
            dataGridView2.Rows.Add(id,product, quantity, price, fullPrice,provider);
            id++;
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `products` (`product`, `price`, `quantity`,  `fullPrice`, `provider`) VALUES (@product,@price,@quantity,@fullPrice,@provider)", db.GetConnection());
            command.Parameters.Add("@product", MySqlDbType.VarChar).Value = product;
            command.Parameters.Add("@price", MySqlDbType.Double).Value = price;
            command.Parameters.Add("@quantity", MySqlDbType.Int64).Value = quantity;
            command.Parameters.Add("@fullPrice", MySqlDbType.Double).Value = fullPrice;
            command.Parameters.Add("@provider", MySqlDbType.VarChar).Value = provider;
            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Создано!");
            }
            else
            {
                MessageBox.Show("Не создано(");
            }
            db.closeConnection();
        }

        /*************************************Для вывода цены*****************************/
        void printSklad()
        {
            conn.Open();
            string providerName = comboBox3.SelectedItem.ToString();
            string productName = comboBox2.SelectedItem.ToString();
            string price = $"SELECT price FROM {providerName} WHERE product = '{productName}'";
            MySqlCommand command = new MySqlCommand(price, conn);
            MySqlDataReader reader = command.ExecuteReader();
            //listBox1.Items.Clear();
            while (reader.Read())
            {
                textBox2.Text = reader[0].ToString();
            }
            reader.Close();
            conn.Close();
        }
        /*********************************************Для записи цены в textbox2******************************/

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string f = comboBox2.SelectedItem.ToString();
            //conn.Open();
            //string price = $"SELECT price FROM  health WHERE `product` = `Фарингосепт`";
            //MySqlCommand command = new MySqlCommand(price, conn);
            //MySqlDataReader reader = command.ExecuteReader();
            ////listBox1.Items.Clear();
            //while (reader.Read())
            //{
            //    listBox1.Items.Add(reader[0].ToString());
            //    //textBox1.Text = reader[0].ToString();
            //}
            //reader.Close();
            //conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void администрацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 fm6 = new Form6();
            fm6.Show();
        }

        private void документацияToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Кнопки программы:\n" +
                "'Добавить' - при полном выборе нужных медикаментов товар заказывается и добавляется в требуемые\n\n" +
                "'Удалить' - при ошибочном заказе товар можно удалить в течении 24 ч.\n\n" +
                "'Обновить' - для просмотра медикаментов которые находятся на складе\n\n" +
                "'Печать' - для печати докладной о заказанных медикаментах");
        }

        private void активнаяФормаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}
