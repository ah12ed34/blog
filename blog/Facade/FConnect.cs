using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using blog.tools;
using Newtonsoft.Json;
using blog.objects;
using System.Collections;
using System.Windows.Forms;

namespace blog.focus
{
    internal class FConnect
    {
        ToolsInternet TInternet = new ToolsInternet();
        ToolsMessages TMessage = new ToolsMessages();
        DataTable dataTable = new DataTable();
        public DataTable getArticles()
        {
             dataTable =new DataTable();
            if (TInternet.GetCanConnectTo())
            {
                dataTable = JsonConvert.DeserializeObject<DataTable>(
                        TInternet.getData("https://project.proprogye.com/APIs/getlist.php", ""));
                dataTable.TableName = "Articles";
            }
            else
            {
               
                switch (TMessage.Message("اتصال الانترنت", "خطا في الاتصال بالانترنت", ToolsMessages.IconName.Warning, ToolsMessages.ButtonName.RetryCancel))
                {
                    case DialogResult.Retry:
                        return getArticles();
                       // break;
                        case DialogResult.Cancel:
                       Application.Exit();
                        break;

                }
            }
            return dataTable;
        }
        public DataPermissions getPermissions()
        {
            DataPermissions dataPermissions = new DataPermissions();
             dataTable =new DataTable();
            if (TInternet.GetCanConnectTo())
            {
                string s = TInternet.getData("https://project.proprogye.com/APIs/permissions.php","");
                dataTable = JsonConvert.DeserializeObject<DataTable>(s);
                if (!dataTable.Columns.Contains("error")) {

                    for (int i = 0; i < dataTable.Rows.Count; i++) { 
                    switch(dataTable.Rows[i]["name"].ToString()) {
                            case "admin":
                                
                                dataPermissions.AdminProAdd = true;
                                dataPermissions.AdminProEdi = getBool(dataTable.Rows[i]["edit_profile"]);
                                dataPermissions.AdminProDel = getBool(dataTable.Rows[i]["del_profile"]);

                                dataPermissions.AdminComAdd = getBool(dataTable.Rows[i]["add_comment"]);
                                dataPermissions.AdminComEdi = getBool(dataTable.Rows[i]["edit_comment"]);
                                dataPermissions.AdminComDel = getBool(dataTable.Rows[i]["del_comment"]);

                                dataPermissions.AdminWritAdd = getBool(dataTable.Rows[i]["add_articles"]);
                                dataPermissions.AdminWritEdi = getBool(dataTable.Rows[i]["edit_articles"]);
                                dataPermissions.AdminWritDel = getBool(dataTable.Rows[i]["del_articles"]);

                                dataPermissions.AdminAdsView = getBool(dataTable.Rows[i]["ads"]);

                                dataPermissions.AdminLinkWait = getBool(dataTable.Rows[i]["wait_link"]);
                                dataPermissions.AdminLinkShow = getBool(dataTable.Rows[i]["show_link"]);
                                break;
case "user":
                                dataPermissions.UserProAdd = true;
                                dataPermissions.UserProEdi = getBool(dataTable.Rows[i]["edit_profile"]);
                                dataPermissions.UserProDel = getBool(dataTable.Rows[i]["del_profile"]);

                                dataPermissions.UserComAdd = getBool(dataTable.Rows[i]["add_comment"]);
                                dataPermissions.UserComEdi = getBool(dataTable.Rows[i]["edit_comment"]);
                                dataPermissions.UserComDel = getBool(dataTable.Rows[i]["del_comment"]);

                                dataPermissions.UserWritAdd = getBool(dataTable.Rows[i]["add_articles"]);
                                dataPermissions.UserWritEdi = getBool(dataTable.Rows[i]["edit_articles"]);
                                dataPermissions.UserWritDel = getBool(dataTable.Rows[i]["del_articles"]);

                                dataPermissions.UserAdsView = getBool(dataTable.Rows[i]["ads"]);

                                dataPermissions.UserLinkWait = getBool(dataTable.Rows[i]["wait_link"]);
                                dataPermissions.UserLinkShow = getBool(dataTable.Rows[i]["show_link"]);
                                break;
case "vip_user":
                                dataPermissions.VuserProAdd = true;
                                dataPermissions.VuserProEdi = getBool(dataTable.Rows[i]["edit_profile"]);
                                dataPermissions.VuserProDel = getBool(dataTable.Rows[i]["del_profile"]);

                                dataPermissions.VuserComAdd = getBool(dataTable.Rows[i]["add_comment"]);
                                dataPermissions.VuserComEdi = getBool(dataTable.Rows[i]["edit_comment"]);
                                dataPermissions.VuserComDel = getBool(dataTable.Rows[i]["del_comment"]);

                                dataPermissions.VuserWritAdd = getBool(dataTable.Rows[i]["add_articles"]);
                                dataPermissions.VuserWritEdi = getBool(dataTable.Rows[i]["edit_articles"]);
                                dataPermissions.VuserWritDel = getBool(dataTable.Rows[i]["del_articles"]);

                                dataPermissions.VuserAdsView = getBool(dataTable.Rows[i]["ads"]);

                                dataPermissions.VuserLinkWait = getBool(dataTable.Rows[i]["wait_link"]);
                                dataPermissions.VuserLinkShow = getBool(dataTable.Rows[i]["show_link"]);
                                break;
case "creator":
                                dataPermissions.CreatorProAdd = true;
                                dataPermissions.CreatorProEdi = getBool(dataTable.Rows[i]["edit_profile"]);
                                dataPermissions.CreatorProDel = getBool(dataTable.Rows[i]["del_profile"]);

                                dataPermissions.CreatorComAdd = getBool(dataTable.Rows[i]["add_comment"]);
                                dataPermissions.CreatorComEdi = getBool(dataTable.Rows[i]["edit_comment"]);
                                dataPermissions.CreatorComDel = getBool(dataTable.Rows[i]["del_comment"]);

                                dataPermissions.CreatorWritAdd = getBool(dataTable.Rows[i]["add_articles"]);
                                dataPermissions.CreatorWritEdi = getBool(dataTable.Rows[i]["edit_articles"]);
                                dataPermissions.CreatorWritDel = getBool(dataTable.Rows[i]["del_articles"]);

                                dataPermissions.CreatorAdsView = getBool(dataTable.Rows[i]["ads"]);

                                dataPermissions.CreatorLinkWait = getBool(dataTable.Rows[i]["wait_link"]);
                                dataPermissions.CreatorLinkShow = getBool(dataTable.Rows[i]["show_link"]);
                                break;
                        }
                    }

                }
                else
                {
                    TMessage.Message("خطاء من الموقع", dataTable.Rows[0]["error"].ToString(), ToolsMessages.IconName.error, ToolsMessages.ButtonName.ok);
                }
            }
            else
            {
              DialogResult s = TMessage.Message("اتصال الانترنت", "خطا في الاتصال بالانترنت", ToolsMessages.IconName.Warning, ToolsMessages.ButtonName.RetryCancel);
                switch (s)
                {
                    case DialogResult.Retry:
                        return getPermissions();
                       // break;
                        case DialogResult.Cancel:
                       Application.Exit();
                        break;

                }
            }
            return dataPermissions;
        }
        /*  */

        public DataTable getMembers(int id)
        {

            dataTable = new DataTable();
            DataTable dataTableTemp = new DataTable();
                   
           
            if (TInternet.GetCanConnectTo())
            {
                string s = TInternet.getData("https://project.proprogye.com/APIs/members.php", "id="+id );
                try
                {
                    dataTableTemp = JsonConvert.DeserializeObject<DataTable>(s);
                    

                    dataTable = dataTableTemp;
                    dataTable.TableName = "Members";
                    //for(int i = 0; i < dataTableTemp.Columns.Count; i++)
                    //{
                    //    if(dataTableTemp.Columns[i].ColumnName == "a_admin")
                    //    {
                    //        DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
                    //        dataGridViewCheckBoxColumn.HeaderText = dataTableTemp.Columns[i].ColumnName;
                    //        dataTable.Columns[i].DataType = dataGridViewCheckBoxColumn.GetType();
                    //        for(int j = 0;dataTableTemp.Rows.Count > 0; j++)
                    //        {
                    //            dataTable.Rows[j][i]=getBool(dataTableTemp.Rows[j][i]);
                    //        }
                    //    }
                    //    else
                    //    {
                    //        dataTable.Columns[i].ColumnName = dataTableTemp.Columns[i].ColumnName;
                    //        for(int j = 0; dataTableTemp.Rows.Count > 0; j++)
                    //        {
                    //            dataTable.Rows[j][i] = dataTableTemp.Rows[j][i];
                    //        }
                    //    }

                    //}

                    //if (dataTable != null && dataTable.Columns.Contains("a_admin"))
                    //{
                    //    dataTable.Columns.Clear();
                    //    DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
                    //    dataGridViewCheckBoxColumn.TrueValue = true;
                    //    dataGridViewCheckBoxColumn.FalseValue = false;

                    //    dataTable.Columns[dataTableTemp.Columns.IndexOf("a_admin")].DataType = dataGridViewCheckBoxColumn.GetType();

                    //}
                    for (int i = 0; i < dataTableTemp.Rows.Count; i++)
                    {
                        dataTable.Rows[i]["a_admin"] = getBool(dataTableTemp.Rows[i]["a_admin"]);
                        dataTable.Rows[i]["sex"] = ToGendar(dataTableTemp.Rows[i]["sex"]);

                    }
                    //dataTable.Columns["a_admin"].DataType = typeof(Boolean);
                    //dataTable.Columns["a_admin"]= new DataGridViewCheckBoxColumn();
                    if (dataTable.Columns.Contains("error"))
                    {
                        TMessage.Message("خطاء من الموقع", dataTable.Rows[0]["error"].ToString(), ToolsMessages.IconName.error, ToolsMessages.ButtonName.ok);

                    }
                   
                }
                catch (Exception e)
                {
                    TMessage.Message("خطاء", s, ToolsMessages.IconName.error, ToolsMessages.ButtonName.ok);
                    dataTable = null;
                }



            }
            else
            {
                DialogResult s = TMessage.Message("اتصال الانترنت", "خطا في الاتصال بالانترنت", ToolsMessages.IconName.Warning, ToolsMessages.ButtonName.RetryCancel);
                switch (s)
                {
                    case DialogResult.Retry:
                        return getMembers(id);
                    // break;
                    case DialogResult.Cancel:
                        Application.Exit();
                        break;

                }
            }
           
               
                

            return dataTable;
        }

        public DataTable setMembers(int id,string text)
        {

             dataTable = new DataTable();


            if (TInternet.GetCanConnectTo())
            {
                string s = TInternet.getData("https://project.proprogye.com/APIs/members.php", "id=" + id+"&"+text);
                try
                {
                    dataTable = JsonConvert.DeserializeObject<DataTable>(s);


                    
                    dataTable.TableName = "Members";


                }
                catch (Exception e)
                {
                    TMessage.Message("خطاء", s, ToolsMessages.IconName.error, ToolsMessages.ButtonName.ok);
                    dataTable = null;
                }



            }
            else
            {
                DialogResult s = TMessage.Message("اتصال الانترنت", "خطا في الاتصال بالانترنت", ToolsMessages.IconName.Warning, ToolsMessages.ButtonName.RetryCancel);
                switch (s)
                {
                    case DialogResult.Retry:
                        return setMembers(id,text);
                    // break;
                    case DialogResult.Cancel:
                        Application.Exit();
                        break;

                }
            }




            return dataTable;
        }
       
        public Boolean SetPermissions(int id, string text)
        {

             dataTable = new DataTable();


            if (TInternet.GetCanConnectTo())
            {
                string s = TInternet.getData("https://project.proprogye.com/APIs/permissions.php", "id=" + id + "&" + text);
                try
                {
                    dataTable = JsonConvert.DeserializeObject<DataTable>(s);

                    if (dataTable != null)
                    {
                        if (dataTable.Columns.Contains("succ"))
                        {
                           
                            return true;
                        }
                        else
                        {
                            if (dataTable.Columns.Contains("error"))
                                MessageBox.Show(dataTable.Rows[0]["error"].ToString(),"error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            
                            return false;
                        }
                    }
                    else {
                        
                        return false;}

                }
                catch (Exception e)
                {
                    TMessage.Message("خطاء", e.Message, ToolsMessages.IconName.error, ToolsMessages.ButtonName.ok);
                    return false;
                }



            }
            else
            {
                DialogResult s = TMessage.Message("اتصال الانترنت", "خطا في الاتصال بالانترنت", ToolsMessages.IconName.Warning, ToolsMessages.ButtonName.RetryCancel);
                switch (s)
                {
                    case DialogResult.Retry:
                        return SetPermissions(id, text);
                    // break;
                    case DialogResult.Cancel:
                        Application.Exit();
                        return false;
                        break;
                        default: return true;

                }
            }




           
        }
        /* */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user">الاسم</param>
        /// <param name="pass">كلمة المرور</param>
        /// <returns></returns>
        public log_datacs Login(string user,string pass)
        {

             dataTable = new DataTable();
            log_datacs login = new log_datacs();
           
            if (TInternet.GetCanConnectTo())
            {
                string s = TInternet.getData("https://project.proprogye.com/APIs/Log.php", "user=" + user + "&pass=" + pass);
                try
                {dataTable = JsonConvert.DeserializeObject<DataTable>(s );

                    if (dataTable.Columns.Contains("error"))
                    {
                        TMessage.Message("خطاء من الموقع", dataTable.Rows[0]["error"].ToString(), ToolsMessages.IconName.error, ToolsMessages.ButtonName.ok);

                    }
                    else
                    {
                        try
                        {
                           
                            login.User = dataTable.Rows[0]["uname"].ToString();
                            login.Id =Convert.ToInt32(dataTable.Rows[0]["id"]);
                            login.Email = dataTable.Rows[0]["e_mail"].ToString();
                            login.FullName = dataTable.Rows[0]["name"].ToString();
                            login.TypeUser = Convert.ToInt32(dataTable.Rows[0]["typeU"]);
                            login.Gander = ToBool(Convert.ToInt32(dataTable.Rows[0]["sex"]));
                            login.Bday = ToDate(dataTable.Rows[0]["DateBirth"].ToString());
                             
                          
                        }
                        catch (Exception ex)
                        {
                            
                            TMessage.Message("خطاء", "خطاء في استقبال البيانات :"+login.FullName+" \n "+login.User+" \n "+login.Email+" \n "+login.Bday+" \n "+login.Gander+"\n"+ dataTable.Rows[0]["DateBirth"].ToString(), ToolsMessages.IconName.error, ToolsMessages.ButtonName.ok);
                        }
                    }
                }
                catch (Exception e)
                {
                    TMessage.Message("خطاء",s, ToolsMessages.IconName.error, ToolsMessages.ButtonName.ok);
                login = null;
                }
                
                
                
            }
            else
            {

            }
            return login;
        }
        Boolean ToBool(int s)
        {
            if(s == 0) { return false; } else { return true; }
        }
       public Boolean getBool(object o)
        {
            if (o.ToString() == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string ToGendar(object i)
        {
           
            switch (i.ToString())
            {
               
                    case "1":
                    return "مراة";
                default:
                case "0":
                    return "رجل";
            }
        }

        DateTime ToDate(string s)
        {
            int year = 1111, month = 11, day = 11;
            try
            {
                string[] vs = s.Split('-');


                for (int i = 0; i < vs.Length; i++)
                {
                   
                    if (vs[i].Length > 2)
                    {
                        year = Convert.ToInt32(vs[i]);
                    }
                    else if (i == 2 && Convert.ToInt32(vs[i]) < 13)
                    {
                        month = Convert.ToInt32(vs[i]);
                    }
                    else
                    {
                        day = (Convert.ToInt32(vs[i]));
                    }
                }

            }catch (Exception e)
            {
                TMessage.Message("", s);

            }
            
            return new DateTime(year,month,day);
        }

    }
}
