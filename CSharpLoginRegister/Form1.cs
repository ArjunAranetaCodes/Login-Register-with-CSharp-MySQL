using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CSharpLoginRegister
{
    public partial class Form1 : Form
    {
        MySqlConnection conn = new MySqlConnection("Server=localhost;User Id=root1;Password='';Database=db_csharp1");
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        MySqlCommand command = new MySqlCommand();
        public DataSet ds = new DataSet();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ds = new DataSet();
            adapter = new MySqlDataAdapter("insert into tbl_accounts (username, password) VALUES ('" + textBox3.Text + "','" + textBox4.Text + "')", conn);
            adapter.Fill(ds, "tbl_accounts");
            MessageBox.Show("Registered!");
            textBox3.Clear();
            textBox4.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ds = new DataSet();
            adapter = new MySqlDataAdapter("select * from tbl_accounts where username = '" + textBox1.Text + "' and password = '" + textBox2.Text + "'", conn);
            adapter.Fill(ds, "tbl_accounts");

            if (ds.Tables["tbl_accounts"].Rows.Count > 0) {
                MessageBox.Show("Welcome!");
            }
            else
            {
                MessageBox.Show("Invalid Username and Password!");
            }
        }

    }
}
