using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        SqlConnection SqlCon;
        public int num;
        DataTable table = null;
        SqlDataAdapter adapter = null;
        SqlCommand command = null;
        public Form2()
        {
            InitializeComponent();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string connstring = @"Data Source=.\SQLEXPRESS;Initial Catalog=RZ_A_12_19_14; Integrated Security = True";
            SqlCon = new SqlConnection(connstring);
            SqlCon.Open();
            command = new SqlCommand("select * from Vforclient where Номер_карты = @num",SqlCon);
            command.Parameters.AddWithValue("num", num);
            adapter = new SqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            SqlCon.Close();
        }
    }
}
