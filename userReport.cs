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
    public partial class userReport : Form
    {
        public string name;
        public string id;
        public string uname;
        public string uid;


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


        public void set_uname(string uname)
        {
            this.uname = uname;
        }

        public string get_uname()
        {
            return this.uname;

        }

        public void set_uid(string uid)
        {
            this.uid = uid;
        }

        public string get_uid()
        {
            return this.uid;

        }


        SqlConnection sqlconnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\c7160289\Desktop\mydb.mdf;Integrated Security=True;Connect Timeout=30");
        public userReport(string name, string id,string uname,string uid)
        {
            InitializeComponent();
            set_name(name);
            set_id(id);
            set_uname(uname);
            set_uid(uid);
            displayreport();
        }

        public void displayreport()
        {
            sqlconnection.Open();
            SqlCommand cmd = sqlconnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select userID as ID, commitName as COMMITS,userName as AUTHOR from commits Where reportId = '" + get_id() + "'  ORDER BY userID DESC";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;



            sqlconnection.Close();
        }




        private void userReport_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedrow = dataGridView1.Rows[index];
            

            error fm = new error(get_name(), selectedrow.Cells[0].Value.ToString());

           // this.Hide();
            fm.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {

           // MessageBox.Show(get_uname());

            Commit c = new Commit(get_id(), get_uname(), get_uid());
            this.Hide();
            c.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(get_uname(), get_uid());
            this.Hide();
            f2.Show();
        }
    }
}
