using blog.tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using blog.focus;
using blog.objects;
using System.Collections;

namespace blog
{
    public partial class Loggin : Form
    {
        
        public  Loggin()
        {
            InitializeComponent();
           
        }
        ToolsMessages messages = new ToolsMessages() ;
        FConnect connect = new FConnect() ;
        public log_datacs logD = new log_datacs() ;
        
       
        //private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    Process.Start(new ProcessStartInfo("https://project.proprogye.com/login/"));
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox_user.Text.Length > 3 && textBox_pass.Text.Length > 3)
            {
              logD =  connect.Login(textBox_user.Text, textBox_pass.Text);
                if(logD != null)
                if(!logD.isEmpty())
                {
                    this.Close();
                    //messages.Message("ok", "ok", ToolsMessages.IconName.Information);
                }
            }
            else
            {
                messages.Message("", "يجب ان يكون طول اسم المستخدم وكلمة السر اكبر من 3");
            }
        }

        private void Loggin_Load(object sender, EventArgs e)
        {
            textBox_user.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://project.proprogye.com/login/"));
        }
    }
}
