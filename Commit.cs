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
    public partial class Commit : Form
    {
        public string name;
        public string id;
        public string rid;
        public string cid;





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


        public void set_rid(string rid)
        {
            this.rid = rid;
        }

        public string get_rid()
        {
            return this.rid;

        }

        public void set_cid(string cid)
        {
            this.cid =cid;
        }

        public string get_cid()
        {
            return this.cid;

        }






        //AD DATABASE FILE LINK HERE
        SqlConnection sqlconnection = new SqlConnection(@" ");
        //AD DATABASE FILE LINK HERE
        public Commit(string rid,string name, string id)
        {
            InitializeComponent();
            set_name(name);
            set_id(id);
            set_rid(rid);
        }

        private void Commit_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            sqlconnection.Open();
            SqlCommand cmd = sqlconnection.CreateCommand();
           cmd.CommandType = CommandType.Text;
           cmd.CommandText = "INSERT INTO Commits(commitName, userName,nameId,reportId) values('" + textBox1.Text + "','" +get_name() + "','"+get_id()+"','"+get_rid()+"')";
           cmd.ExecuteNonQuery();
           sqlconnection.Close();
          
            //VALUE PASSING
            SqlCommand command = new SqlCommand("Select * from Commits Where commitName = '" + textBox1.Text.Trim() + "' and reportId = '" +get_rid() + "'", sqlconnection
                     );
            try
            {
                sqlconnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                   
                    //MessageBox.Show(reader["userID"].ToString());
                    set_cid(reader["userID"].ToString());
                  
                }
                reader.Close();
             

            }
            catch
            {

            }
            finally
            {
                sqlconnection.Close();
                updaterror();
            }
            //VALUE PASSING
           
           



        }
        public void updaterror()
        {
            sqlconnection.Open();
            SqlCommand omd = sqlconnection.CreateCommand();
            omd.CommandType = CommandType.Text;
            omd.CommandText = "INSERT INTO ERROR(LINE_NO, METHOD_NAME,DESCRIPTION,COMMIT_ID) values('" + textBox2.Text.Trim() + "','" + textBox3.Text.Trim() + "','" + richTextBox1.Text.Trim() + "','" + get_cid() + "')";
            omd.ExecuteNonQuery();
            sqlconnection.Close();
            MessageBox.Show("You have reported the bug. Thanks");
            Form2 f2 = new Form2(get_name(), get_id());
            this.Hide();
            f2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(get_name(), get_id());
            this.Hide();
            f2.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }


}
