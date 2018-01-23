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
    public partial class newReport : Form
    {
        public string name;
        public string id;


        public void set_name(string name)
        {
            this.name = name;
        }

        public string get_name()
        {
            return this.name;

        }

        public void set_id(string id)
        {
            this.id = id;
        }

        public string get_id()
        {
            return this.id;

        }


        //AD DATABASE FILE LINK HERE
        SqlConnection sqlconnection = new SqlConnection(@" ");
        //AD DATABASE FILE LINK HERE
        public newReport(string name,string id)
        {
          
            InitializeComponent();
            set_name(name);
            set_id(id);
        }

        private void newReport_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

          
            //EMPTY FIELDS
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox4.Text.Trim()== "")
            {
                MessageBox.Show("Make Sure All Fields are Completed");
            }
            else
            {
                sqlconnection.Open();
                SqlCommand cmd = sqlconnection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO REPORT(REPORT_NAME, REPORTER_NAME,TO_USER,GIT_SOURCE,ADDITIONAL_INFORMATION,USER_ID) values('" + textBox1.Text.Trim() + "','" + get_name() + "','" + textBox3.Text.Trim() + "','" + textBox4.Text.Trim() + "','" + richTextBox1.Text.Trim() + "','" + get_id() + "')";
                cmd.ExecuteNonQuery();
                sqlconnection.Close();
                MessageBox.Show("REPORT CREATED");

                //VALUE PASSING
                SqlCommand command = new SqlCommand("Select * from REPORT Where REPORT_NAME = '" + textBox1.Text.Trim() + "'and REPORTER_NAME = '" + get_name() + "'", sqlconnection
                         );
                try
                {
                    sqlconnection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        //MessageBox.Show(reader["Id"].ToString());

                        Commit c = new Commit(reader["Id"].ToString(),get_name(),get_id());
                        this.Hide();
                        c.Show();

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
               
            }//EMPTY FIELDS
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(get_name(), get_id());
            this.Hide();
            f2.Show();
        }
    }
}
