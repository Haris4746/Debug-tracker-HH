using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace debugger
{
   
    public partial class Form2 : Form
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


        public Form2(string name, string id)
        {
          
           
            InitializeComponent();

             set_name(name);
             set_id(id);
            
            label.Text = name;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           
        }

        private void oldreports_Click(object sender, EventArgs e)
        {
            OldReport fm = new OldReport(get_name(), get_id());

            this.Hide();
            fm.Show();
        }

        public void reportnew_Click(object sender, EventArgs e)
        {
            newReport ur = new newReport(get_name(),get_id());
          
            this.Hide();
            ur.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DEBUGGER f1 = new DEBUGGER();
            this.Hide();
            f1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 fm = new Form3(get_name(), get_id());

            this.Hide();
            fm.Show();
        }
    }
}
