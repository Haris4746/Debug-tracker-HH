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
    public partial class OldReport : Form
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
        public OldReport(string name,string id)
        {
            InitializeComponent();
            set_name(name);
            set_id(id);
            displayreportd();
        }





        public void displayreportd()
        {
            sqlconnection.Open();
            SqlCommand cmd = sqlconnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select Id AS ID,REPORT_NAME AS NAME,REPORTER_NAME AS REPORTER,TO_USER,GIT_SOURCE AS SOURCE,ADDITIONAL_INFORMATION AS INFO  from REPORT Where USER_ID = '" + get_id()+ "' ORDER BY Id DESC";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;



            sqlconnection.Close();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            int index = e.RowIndex;
            DataGridViewRow selectedrow = dataGridView1.Rows[index];

            //MessageBox.Show(get_name());
           // Console.WriteLine(selectedrow.Cells[1].Value.ToString());

            userReport fm = new userReport(selectedrow.Cells[1].Value.ToString(), selectedrow.Cells[0].Value.ToString(),get_name(),get_id());

            this.Hide();
            fm.Show();


        }

        private void OldReport_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(get_name(),get_id());
            this.Hide();
            f2.Show();
        }
    }
}
