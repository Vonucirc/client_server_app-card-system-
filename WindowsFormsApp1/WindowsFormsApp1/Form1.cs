using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        SqlConnection SqlCon;
        DataTable tableall = null;
        DataTable tablecard = null;
        DataTable tablecustm = null;
        DataTable tablepur = null;
        SqlDataAdapter adapter1 = null;
        SqlDataAdapter adapter2 = null;
        SqlDataAdapter adapter3 = null;
        SqlDataAdapter adapter4 = null;
        public Form1()
        {
            InitializeComponent();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int flag = -1;
            if (textBox1.TextLength != 0 && textBox2.TextLength != 0)
            {
                SqlCon.Open();
                SqlCommand command = new SqlCommand("Select count(*) from Custm_inf where Номер_карты = @num and Номер_телефона = @phone", SqlCon);
                command.Parameters.AddWithValue("num", Convert.ToInt32(textBox1.Text));
                command.Parameters.AddWithValue("phone", textBox2.Text);
                flag = (Int32)command.ExecuteScalar();
                command.ExecuteNonQuery();
                SqlCon.Close();
                if (flag==1)
                {
                    Form2 FormCl = new Form2();
                    FormCl.num = Convert.ToInt32(textBox1.Text);
                    FormCl.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Введенный номер карты несоответсвует введенному телефону, проверьте правильность введенных данных");
                }
            }
            else
            {
                MessageBox.Show("Введите номер карты и номер телефона в соответсвующие поля");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connstring = @"Data Source=.\SQLEXPRESS;Initial Catalog=RZ_A_12_19_14; Integrated Security = True";
            SqlCon = new SqlConnection(connstring);
            SqlCon.Open();
            adapter1 = new SqlDataAdapter("select * from admininfo", SqlCon);
            tableall = new DataTable();
            adapter1.Fill(tableall);
            dataGridView1.DataSource = tableall;

            adapter2 = new SqlDataAdapter("select * from Card_inf", SqlCon);
            tablecard = new DataTable();
            adapter2.Fill(tablecard);
            dataGridView2.DataSource = tablecard;

            adapter3 = new SqlDataAdapter("select * from Custm_inf", SqlCon);
            tablecustm = new DataTable();
            adapter3.Fill(tablecustm);
            dataGridView3.DataSource = tablecustm;

            adapter4 = new SqlDataAdapter("select * from Pur_inf", SqlCon);
            tablepur = new DataTable();
            adapter4.Fill(tablepur);
            dataGridView4.DataSource = tablepur;
            SqlCon.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCon.Open();
            SqlCommand command = new SqlCommand("exec Card_insert @num, @cartdate, @cardlvl, @bonus, @moneyforlvlup", SqlCon);
            command.Parameters.AddWithValue("num", Convert.ToInt32(textBox3.Text));
            command.Parameters.AddWithValue("cartdate", textBox4.Text);
            command.Parameters.AddWithValue("cardlvl", Convert.ToInt32(textBox5.Text));
            command.Parameters.AddWithValue("bonus", Convert.ToInt32(textBox6.Text));
            command.Parameters.AddWithValue("moneyforlvlup", Convert.ToInt32(textBox7.Text));
            command.ExecuteNonQuery();
            adapter2 = new SqlDataAdapter("select * from Card_inf", SqlCon);
            tablecard = new DataTable();
            adapter2.Fill(tablecard);
            dataGridView2.DataSource = tablecard;
            SqlCon.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCon.Open();
            SqlCommand command = new SqlCommand("delete from Card_inf where Номер_карты=@num", SqlCon);
            command.Parameters.AddWithValue("num", Convert.ToInt32(textBox3.Text));
            command.ExecuteNonQuery();
            adapter2 = new SqlDataAdapter("select * from Card_inf", SqlCon);
            tablecard = new DataTable();
            adapter2.Fill(tablecard);
            dataGridView2.DataSource = tablecard;
            SqlCon.Close();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            SqlCon.Open();
            SqlCommand command = new SqlCommand("exec Custm_insert @f, @i, @o, @daybirt, @sex, @adress, @phone, @num ", SqlCon);
            command.Parameters.AddWithValue("f", textBox8.Text);
            command.Parameters.AddWithValue("i", textBox9.Text);
            command.Parameters.AddWithValue("o", textBox10.Text);
            command.Parameters.AddWithValue("daybirt", textBox11.Text);
            command.Parameters.AddWithValue("sex", textBox12.Text);
            command.Parameters.AddWithValue("adress", textBox13.Text);
            command.Parameters.AddWithValue("phone", textBox14.Text);
            command.Parameters.AddWithValue("num", textBox15.Text);
            command.ExecuteNonQuery();
            adapter3 = new SqlDataAdapter("select * from Custm_inf", SqlCon);
            tablecustm = new DataTable();
            adapter3.Fill(tablecustm);
            dataGridView3.DataSource = tablecustm;
            SqlCon.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlCon.Open();
            SqlCommand command = new SqlCommand("delete from Custm_inf where Номер_карты=@num", SqlCon);
            command.Parameters.AddWithValue("num", Convert.ToInt32(textBox15.Text));
            command.ExecuteNonQuery();
            adapter3 = new SqlDataAdapter("select * from Custm_inf", SqlCon);
            tablecustm = new DataTable();
            adapter3.Fill(tablecustm);
            dataGridView3.DataSource = tablecustm;
            SqlCon.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlCon.Open();
            SqlCommand command = new SqlCommand("exec Pur_insert @wastedmoney, @prchasequan, @prchasequan500, @num ", SqlCon);
            command.Parameters.AddWithValue("wastedmoney", textBox16.Text);
            command.Parameters.AddWithValue("prchasequan", textBox17.Text);
            command.Parameters.AddWithValue("prchasequan500", textBox18.Text);
            command.Parameters.AddWithValue("num", textBox19.Text);
            command.ExecuteNonQuery();
            adapter4 = new SqlDataAdapter("select * from Pur_inf", SqlCon);
            tablepur = new DataTable();
            adapter4.Fill(tablepur);
            dataGridView4.DataSource = tablepur;
            SqlCon.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlCon.Open();
            SqlCommand command = new SqlCommand("delete from Pur_inf where Номер_карты=@num", SqlCon);
            command.Parameters.AddWithValue("num", Convert.ToInt32(textBox19.Text));
            command.ExecuteNonQuery();
            adapter4 = new SqlDataAdapter("select * from Pur_inf", SqlCon);
            tablepur = new DataTable();
            adapter4.Fill(tablepur);
            dataGridView4.DataSource = tablepur;
            SqlCon.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlCon.Open();
            adapter1 = new SqlDataAdapter("select * from admininfo", SqlCon);
            tableall = new DataTable();
            adapter1.Fill(tableall);
            dataGridView1.DataSource = tableall;
            SqlCon.Close();
        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            SqlCon.Open();
            int cost;
            double disc = 0;
            double bonus = 0;
            int cardlvl;
            int lvlcheck;
            int lvlup;
            cost = Convert.ToInt32(textBox20.Text);
            SqlCommand command = new SqlCommand("select Уровень_карты from Card_inf where Номер_карты = @num", SqlCon);
            command.Parameters.AddWithValue("num", Convert.ToInt32(textBox22.Text));
            cardlvl = (Int32)command.ExecuteScalar();
            switch (cardlvl)
            {
                case 1:
                    disc = cost * 0.02;
                    break;
                case 2:
                    disc = cost * 0.05;
                    break;
                case 3:
                    disc = cost * 0.08;
                    break;
            }
            if (checkBox1.Checked && cost>500)
            {
                SqlCommand command1 = new SqlCommand("select Кол_во_баллов from Card_inf where Номер_карты = @num", SqlCon);
                command1.Parameters.AddWithValue("num", Convert.ToInt32(textBox22.Text));
                bonus = (Int32)command1.ExecuteScalar();
                if (bonus > cost)
                {
                    disc = disc + 0.5 * cost;
                    bonus = bonus - 0.5 * cost;
                }
                else
                {
                    disc = disc + bonus;
                    bonus = 0;
                }
                SqlCommand command2 = new SqlCommand("update Card_inf set Кол_во_баллов = @bonus where Номер_карты = @num", SqlCon);
                command2.Parameters.AddWithValue("num", Convert.ToInt32(textBox22.Text));
                command2.Parameters.AddWithValue("bonus", bonus);
                command2.ExecuteNonQuery();
                SqlCommand command4 = new SqlCommand("update Pur_inf set Кол_во_покпок500 = Кол_во_покпок500+1 where Номер_карты = @num", SqlCon);
                command4.Parameters.AddWithValue("num", Convert.ToInt32(textBox22.Text));
                command4.ExecuteNonQuery();
            }
            SqlCommand command3 = new SqlCommand("exec Pur_makepurchase @cost, @num", SqlCon);
            command3.Parameters.AddWithValue("num", Convert.ToInt32(textBox22.Text));
            command3.Parameters.AddWithValue("cost", cost);
            command3.ExecuteNonQuery();
            if (cost>501 && cost < 3000)
            {
                bonus = 0.03 * cost;
            }
            if (cost>3001 && cost < 10000)
            {
                bonus = 0.04 * cost;
            }
            if (cost > 10000)
            {
                bonus = 0.05 * cost;
            }
            SqlCommand command5 = new SqlCommand("update Card_inf set Кол_во_баллов = Кол_во_баллов + @bonus where Номер_карты = @num", SqlCon);
            command5.Parameters.AddWithValue("num", Convert.ToInt32(textBox22.Text));
            command5.Parameters.AddWithValue("bonus", bonus);
            command5.ExecuteNonQuery();

            SqlCommand command6 = new SqlCommand("update Card_inf set Кол_во_до_улучш = Кол_во_до_улучш - @cost where Номер_карты = @num", SqlCon);
            command6.Parameters.AddWithValue("num", Convert.ToInt32(textBox22.Text));
            command6.Parameters.AddWithValue("cost", cost);
            command6.ExecuteNonQuery();

            SqlCommand command7 = new SqlCommand("select Кол_во_до_улучш where Номер_карты = @num", SqlCon);
            command7.Parameters.AddWithValue("num", Convert.ToInt32(textBox22.Text));
            lvlcheck = (Int32)command7.ExecuteScalar();
            if(lvlcheck < 0 && cardlvl<3)
            {
                SqlCommand command8 = new SqlCommand("update Card_inf set Уровень_карты = Уровень_карты +1 where Номер_карты = @num", SqlCon);
                command8.Parameters.AddWithValue("num", Convert.ToInt32(textBox22.Text));
                command8.ExecuteNonQuery();
                cardlvl = cardlvl + 1;
                if (cardlvl == 2)
                {
                    SqlCommand command9 = new SqlCommand("update Card_inf set Кол_во_до_улучш = 100000 where Номер_карты = @num", SqlCon);
                    command9.Parameters.AddWithValue("num", Convert.ToInt32(textBox22.Text));
                    command9.ExecuteNonQuery();
                }
            }
            SqlCon.Close();
            textBox21.Text = "стоимость со скидкой =" + Convert.ToString(cost - disc);
        }
    }
}
