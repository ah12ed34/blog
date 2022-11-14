using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using blog.objects;
using blog.focus;
using blog.tools;
using blog.MYControls;
using UI_Button_test;

namespace blog
{
    public partial class dashboard : Form
    {
        public log_datacs data;
        FConnect fConnect = new FConnect();
        DataPermissions permissions;
        ToolsMessages messages = new ToolsMessages();
        DataTable DataTableMem = new DataTable();
        DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
        public dashboard(log_datacs l)
        {
            InitializeComponent();
            data = l;
            
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void toggleButtonTest11_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
           if(tabControl1.SelectedTab == tabPage1)
            {
                dataGridView1.Rows.Clear();
                
               DataTableMem = fConnect.getMembers(data.Id);
                
                for (int i = 0; i < DataTableMem.Rows.Count; i++)
                    dataGridView1.Rows.Add(DataTableMem.Rows[i].ItemArray);

                // dataGridView1.Columns.Insert(dataGridView1.Columns.IndexOf(dataGridView1.Columns["a_admin"]), checkBoxColumn);
                //dataGridView1.Columns["a_admin"] = new DataGridViewCheckBoxColumn();
                //for (int i = 0; i < dataGridView1.Columns.Count; i++)
                //{
                //    switch (dataGridView1.Columns[i].Name)
                //    {
                //        case "a_admin":

                //            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
                //           // checkBoxCell;
                //            checkBoxColumn.HeaderText = "a_admin";
                //            dataGridView1.Columns.Insert(i, checkBoxColumn);
                //            break;
                //    }
                //}

            }
            else if (tabControl1.SelectedTab == tabPage2)
            {
                try
                {
                    permissions  =   fConnect.getPermissions();
                
                                   setToggle();
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
             
            }
           
        }
        private bool checkedProgrammatically = false;
        void setToggle()
        {
            if(permissions != null)
            {
                
                checkedProgrammatically = true;
                toggleAdminProAdd.Checked = permissions.AdminProAdd ;
                toggleAdminProEdit.Checked = permissions.AdminProEdi ;
                toggleAminProDel.Checked = permissions.AdminProDel ;
                
                toggleAdminComAdd.Checked = permissions.AdminComAdd ;
                toggleAdminComEdi.Checked = permissions.AdminComEdi ;
                toggleAdminComDel.Checked = permissions.AdminComDel ;
                 
                toggleAdminWriteAdd.Checked = permissions.AdminWritAdd ;
                toggleAdminWriteEdi.Checked = permissions.AdminWritEdi ;
                toggleAdminWriteDel.Checked = permissions.AdminWritDel;

                toggleAdminAdsView.Checked = permissions.AdminAdsView;

                toggleAdminLinkView.Checked = permissions.AdminLinkShow;
                toggleAdminLinkWait.Checked = permissions.AdminLinkWait;


                toggleCreatorProAdd.Checked = permissions.UserProAdd ;
                toggleCreatorProEdi.Checked = permissions.CreatorProEdi ;
                toggleCreatorProDel.Checked = permissions.CreatorProDel ;
                
                toggleCreatorComAdd.Checked = permissions.CreatorComAdd ;
                toggleCreatorComEdi.Checked = permissions.CreatorComEdi ;
                toggleCreatorComDel.Checked = permissions.CreatorComDel ;
                 
                toggleCreatorWriteAdd.Checked = permissions.CreatorWritAdd ;
                toggleCreatorWriteEdi.Checked = permissions.CreatorWritEdi ;
                toggleCreatorWriteDel.Checked = permissions.CreatorWritDel;

                toggleCreatorAdsView.Checked = permissions.CreatorAdsView;

                toggleCreatorLinkView.Checked = permissions.CreatorLinkShow;
                toggleCreatorLinkWait.Checked = permissions.CreatorLinkWait;


                toggleUserProAdd.Checked = permissions.UserProAdd ;
                toggleUserProEdi.Checked = permissions.UserProEdi ;
                toggleUserProDel.Checked = permissions.UserProDel ;
                
                toggleUserComAdd.Checked = permissions.UserComAdd ;
                toggleUserComEdi.Checked = permissions.UserComEdi ;
                toggleUserComDel.Checked = permissions.UserComDel ;
                 
                toggleUserWriteAdd.Checked = permissions.UserWritAdd ;
                toggleUserWriteEdi.Checked = permissions.UserWritEdi ;
                toggleUserWriteDel.Checked = permissions.UserWritDel;

                toggleUserAdsView.Checked = permissions.UserAdsView;

                toggleUserLinkView.Checked = permissions.UserLinkShow;
                toggleUserLinkWait.Checked = permissions.UserLinkWait;


                toggleVuserProAdd.Checked = permissions.VuserProAdd ;
                toggleVuserProEdi.Checked = permissions.VuserProEdi ;
                toggleVuserProDel.Checked = permissions.VuserProDel ;
                
                toggleVuserComAdd.Checked = permissions.VuserComAdd ;
                toggleVuserComEdi.Checked = permissions.VuserComEdi ;
                toggleVuserComDel.Checked = permissions.VuserComDel ;
                 
                toggleVuserWriteAdd.Checked = permissions.VuserWritAdd ;
                toggleVuserWriteEdi.Checked = permissions.VuserWritEdi ;
                toggleVuserWriteDel.Checked = permissions.VuserWritDel;

                toggleVuserAdsView.Checked = permissions.VuserAdsView;

                toggleVuserLinkView.Checked = permissions.VuserLinkShow;
                toggleVuserLinkWait.Checked = permissions.VuserLinkWait;
                checkedProgrammatically = false;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedTab==tabPage2&permissions==null)
                try
                {
                    permissions = fConnect.getPermissions();

                    setToggle();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            else if (tabControl1.SelectedTab == tabPage1)
            {
                 
            }
        }

        //private void toolStripButton2_Click(object sender, EventArgs e)
        //{
        //    helpcs help = new helpcs(data);
        //    help.ShowDialog();

        //}

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            //MessageBox.Show("rowIndex :" + e.RowIndex+"\nColumn Index :"+e.ColumnIndex+"data id "+ dataGridView1.Rows[e.RowIndex].Cells["id"].Value);
            //if (DataTableMem.Columns[e.ColumnIndex].ColumnName == "a_admin")
            //{
                
            //}
            switch (DataTableMem.Columns[e.ColumnIndex].ColumnName)
            {
                case "a_admin":
                    if (fConnect.getBool(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value))
                    {
                        fConnect.setMembers(data.Id, "idd=" + dataGridView1.Rows[e.RowIndex].Cells["id"].Value + "&value=act");
                    }
                    else
                    {
                        fConnect.setMembers(data.Id, "idd=" + dataGridView1.Rows[e.RowIndex].Cells["id"].Value + "&value=des_act");
                    }
                    break;
                case "typeU":
                    fConnect.setMembers(data.Id, "idd=" + dataGridView1.Rows[e.RowIndex].Cells["id"].Value + "&value=CTA&type="+ dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                    break;
                case "sex":
                    fConnect.setMembers(data.Id, "idd=" + dataGridView1.Rows[e.RowIndex].Cells["id"].Value + "&value=CG&gander=" + comboBoxColumn.Items.IndexOf(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value));
                    break;
            }
            
        }

        private void dashboard_Load(object sender, EventArgs e)
        {
            DataTableMem = new DataTable();
            //dataGridView1.Columns.Insert(9, new DataGridViewCheckBoxColumn());
            DataTableMem = fConnect.getMembers(data.Id);
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.TrueValue = 1;
            checkBoxColumn.FalseValue = 0;
            // checkBoxCell;
            checkBoxColumn.HeaderText = "a_admin";
            checkBoxColumn.Name = "a_admin";
            
            comboBoxColumn.Items.Add("رجل");
            comboBoxColumn.Items.Add("مراة");
            comboBoxColumn.Name = "sex";
            comboBoxColumn.HeaderText = "gender";
            
            DataGridViewComboBoxColumn comboBoxColumn1 = new DataGridViewComboBoxColumn();
            comboBoxColumn1.Items.Add("100");
            comboBoxColumn1.Items.Add("110");
            comboBoxColumn1.Items.Add("111");
            comboBoxColumn1.Items.Add("1970");

            for (int i = 0; i < DataTableMem.Columns.Count; i++)
            {
                if (DataTableMem.Columns[i].ColumnName == "a_admin")
                {
                    dataGridView1.Columns.Insert(i, checkBoxColumn);

                }
                else if (DataTableMem.Columns[i].ColumnName == "sex")
                {
                    dataGridView1.Columns.Insert(i, comboBoxColumn);

                }
                else if (DataTableMem.Columns[i].ColumnName == "typeU")
                {
                    comboBoxColumn1.Name = DataTableMem.Columns[i].ColumnName;
                    comboBoxColumn1.HeaderText = DataTableMem.Columns[i].ColumnName;
                    dataGridView1.Columns.Insert(i, comboBoxColumn1);
                }
                else
                {

                    dataGridView1.Columns.Add(DataTableMem.Columns[i].ColumnName, DataTableMem.Columns[i].ColumnName);
                    

                }
            }
            dataGridView1.Columns[0].ReadOnly = true;
            for (int i = 0;i < DataTableMem.Rows.Count;i++)
                dataGridView1.Rows.Add(DataTableMem.Rows[i].ItemArray);
        }

       

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            switch(messages.Message("حذف","ان حذف هاذا المستخدم سويادي الحذف جميع البيانات من رسائل و مقالات وتعليقات", ToolsMessages.IconName.Question, ToolsMessages.ButtonName.OKCancel))
            {
                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
                    case DialogResult.OK:
                    try
                    {
                        int index = e.Row.Index;
                        DataTable dataTable = fConnect.setMembers(data.Id, "idd=" + DataTableMem.Rows[index]["id"] + "&value=del&photo=" + DataTableMem.Rows[index]["photo"]);
                        if(dataTable != null)
                        {
                            if (!dataTable.Columns.Contains("succ"))
                        {

                            if (dataTable.Columns.Contains("status") & Convert.ToInt32(dataTable.Rows[0]["status"]) > 2)
                            {
                                e.Cancel = true;
                            }
                            MessageBox.Show(dataTable.Rows[0]["error"].ToString());
                        }

                        }
                        else
                        {
                            e.Cancel=true;
                        }
                        

                    }catch (NullReferenceException ee) {
                        MessageBox.Show(ee.Message, "Error");
                        e.Cancel = true; }
                    
                    break;
            }
        }
        string name = null;

        private void toggleButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkedProgrammatically) return;
             name = null;
            
            MYControls.ToggleButton toggleButton = (MYControls.ToggleButton)sender;
            switch (toggleButton.Name)
            {
                case "toggleAdminProEdit":
                    name = "edit_profile";
                    break;
case "toggleAdminComAdd":
                    name = "ac";
                    break;
case "toggleAdminComEdi":
                    name = "ec";
                    break;
case "toggleAdminComDel":
                    name = "dc";
                    break;
case "toggleAdminWriteAdd":
                    name = "aar";
                    break;
case "toggleAdminWriteEdi":
                    name = "ear";
                    break;
case "toggleAdminWriteDel":
                    name = "dar";
                    break;
case "toggleAdminLinkView":
                    name = "sl";
                    break;
case "toggleAdminLinkWait":
                    name = "wl";
                    break;
                case "toggleAdminAdsView":
                    name = "ads";
                    break;
            }
            SetPermissions(1970, toggleButton, name);
        }

        private void toggleVuserProEdi_CheckedChanged(object sender, EventArgs e)
        {
            if (checkedProgrammatically) return;
             name = null;

            MYControls.ToggleButton toggleButton = (MYControls.ToggleButton)sender;
            switch (toggleButton.Name)
            {
                case "toggleVuserProEdi":
                    name = "edit_profile";
                    break;
                case "toggleVuserComAdd":
                    name = "ac";
                    break;
                case "toggleVuserComEdi":
                    name = "ec";
                    break;
                case "toggleVuserComDel":
                    name = "dc";
                    break;
                case "toggleVuserWriteAdd":
                    name = "aar";
                    break;
                case "toggleVuserWriteEdi":
                    name = "ear";
                    break;
                case "toggleVuserWriteDel":
                    name = "dar";
                    break;
                case "toggleVuserLinkView":
                    name = "sl";
                    break;
                case "toggleVuserLinkWait":
                    name = "wl";
                    break;
                case "toggleVuserAdsView":
                    name = "ads";
                    break;
            }
            SetPermissions(110, toggleButton, name);
        }

        private void toggleCreatorProEdi_CheckedChanged(object sender, EventArgs e)
        {
            if (checkedProgrammatically) return;
             name = null;

            MYControls.ToggleButton toggleButton = (MYControls.ToggleButton)sender;
            switch (toggleButton.Name)
            {
                case "toggleCreatorProEdi":
                    name = "edit_profile";
                    break;
                case "toggleCreatorComAdd":
                    name = "ac";
                    break;
                case "toggleCreatorComEdi":
                    name = "ec";
                    break;
                case "toggleCreatorComDel":
                    name = "dc";
                    break;
                case "toggleCreatorWriteAdd":
                    name = "aar";
                    break;
                case "toggleCreatorWriteEdi":
                    name = "ear";
                    break;
                case "toggleCreatorWriteDel":
                    name = "dar";
                    break;
                case "toggleCreatorLinkView":
                    name = "sl";
                    break;
                case "toggleCreatorLinkWait":
                    name = "wl";
                    break;
                case "toggleCreatorAdsView":
                    name = "ads";
                    break;
            }
            SetPermissions(111, toggleButton, name);
        }

        private void toggleUserProEdi_CheckedChanged(object sender, EventArgs e)
        {
            if (checkedProgrammatically) return;
             name = null;

            MYControls.ToggleButton toggleButton = (MYControls.ToggleButton)sender;
            switch (toggleButton.Name)
            {
                case "toggleUserProEdi":
                    name = "edit_profile";
                    break;
                case "toggleUserComAdd":
                    name = "ac";
                    break;
                case "toggleUserComEdi":
                    name = "ec";
                    break;
                case "toggleUserComDel":
                    name = "dc";
                    break;
                case "toggleUserWriteAdd":
                    name = "aar";
                    break;
                case "toggleUserWriteEdi":
                    name = "ear";
                    break;
                case "toggleUserWriteDel":
                    name = "dar";
                    break;
                case "toggleUserLinkView":
                    name = "sl";
                    break;
                case "toggleUserLinkWait":
                    name = "wl";
                    break;
                case "toggleUserAdsView":
                    name = "ads";
                    break;
            }
            SetPermissions(100,toggleButton,name);
            //                                                                      value
           
        }
        private void SetPermissions(int idd , MYControls.ToggleButton toggleButton, string name)
        {
            if (!fConnect.SetPermissions(data.Id, "idd=" + idd + "&value=" + toggleButton.Checked + "&name=" + name))
            {
                checkedProgrammatically = true;

                toggleButton.Checked = !toggleButton.Checked;
                checkedProgrammatically = false;
            }
        }
    }
}
