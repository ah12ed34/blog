using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using blog.focus;
using blog.objects;

namespace blog
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ChackLogin();
        }
        FConnect connect = new FConnect();
        log_datacs log_Data = new log_datacs();

        public bool Checked { get; internal set; }

        private void button1_Click(object sender, EventArgs e)
        {
            Loggin loggin = new Loggin();
            loggin.ShowDialog();
            log_Data = loggin.logD;
            ChackLogin();
        }
        void ChackLogin()
        {
            
            if (log_Data.isEmpty())
            {
                dashboard_BTN.Enabled = false;
            }
            else if(log_Data.isAdmin())
            {
                dashboard_BTN.Enabled = true;
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            getData();
        }

        void getData()
        {
            try
            {dataGridView1.DataSource = connect.getArticles();
            if(dataGridView1.DataSource!=null)
         dataGridView1.Columns[0].ReadOnly = true;

            }catch (Exception ex) { }
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            getData();
        }

        private void dashboard_BTN_Click(object sender, EventArgs e)
        {
            this.Hide();
            new dashboard(log_Data).ShowDialog();
            this.Show();
            

        }
    }
}
