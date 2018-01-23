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

namespace debugger
{
    public partial class DEBUGGER : Form
        
    {
        /*WARNING SQL CONNECTION FILE WILL ONLY WORK IF IT IS SPECIFED TO THE HOST MACHINE FILEPATH CONTAINING EXPORTABLE DATABASE FILE
        FOR EXAMPLE.
        SqlConnection sqlconnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Drive D\C# Projects\Bug track\mydb.mdf;Integrated Security=True;Connect Timeout=30”); */


        SqlConnection sqlconnection = new SqlConnection(@" ");
        
        public DEBUGGER()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            string query = "Select * from Users Where userName = '" + textBox1.Text.Trim() + "' and userPassword = '" + textBox2.Text.Trim() + "'";

            SqlDataAdapter sd = new SqlDataAdapter(query, sqlconnection);

            DataTable dt = new DataTable();

            sd.Fill(dt);



            if (dt.Rows.Count == 1)
            {
             
                SqlCommand command = new SqlCommand("Select * from Users Where userName = '" + textBox1.Text.Trim() + "' and userPassword = '" + textBox2.Text.Trim() + "'", sqlconnection
                          );

                try
                {
                    sqlconnection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                       // MessageBox.Show(reader["userName"].ToString());
                       // MessageBox.Show(reader["userID"].ToString());
                        Form2 fm = new Form2(reader["userName"].ToString(), reader["userID"].ToString());
                        this.Hide();
                        fm.Show();


                    }
                    reader.Close();
                }
                catch
                {

                }
                finally
                {
                    sqlconnection.Close();
                }
              
            }
            else
            {
                MessageBox.Show("Username or Password Incorrect.");
            }




        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "")
            {
                MessageBox.Show("Make Sure All Fields are Completed");
            }
            else
            {
                sqlconnection.Open();
                SqlCommand cmd = sqlconnection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO Users(userName, userPassword) values('" + textBox1.Text + "','" + textBox2.Text.Trim() + "')";
                cmd.ExecuteNonQuery();
                sqlconnection.Close();


                //VALUE PASSING
                SqlCommand command = new SqlCommand("Select * from Users Where userName = '" + textBox1.Text.Trim() + "' and userPassword = '" + textBox2.Text.Trim() + "'", sqlconnection
                         );
                try
                {
                    sqlconnection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                       // MessageBox.Show(reader["userName"].ToString());
                      //  MessageBox.Show(reader["userID"].ToString());
                        Form2 fm = new Form2(reader["userName"].ToString(),reader["userID"].ToString());
                        MessageBox.Show("SUccessfully registered");
                        this.Hide();
                        fm.Show();


                    }
                    reader.Close();
                }
                catch
                {

                }
                finally
                {
                    sqlconnection.Close();
                }
                //VALUE PASSING
               
               
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
