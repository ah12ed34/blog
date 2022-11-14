using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace blog.tools
{
    internal class ToolsInternet
    {
        public bool GetCanConnectTo(string url = "https://google.com")
        {
            try
            {
                using (var client = new WebClientWithShortTimeout())
                using (client.OpenRead(url))
                    return true;
            }
            catch
            {
                return false;
            }
        }
        public class WebClientWithShortTimeout : WebClient
        {
            protected override WebRequest GetWebRequest(Uri uri)
            {
                var webRequest = base.GetWebRequest(uri);
                webRequest.Timeout = 5000;
                return webRequest;
            }
        }

        public string getData(String url,string parmiters ,string Method= "POST")
        {
            try
            {
                WebRequest request = WebRequest.Create(url);
                request.Method = Method;// the method to send data
                request.ContentType = "application/x-www-form-urlencoded"; // send the data (Very Important)

                // string postData = "Type=Lunch";

                ASCIIEncoding enc = new ASCIIEncoding();
                byte[] data = enc.GetBytes(parmiters);
                Stream stream = request.GetRequestStream();
                stream.Write(data, 0, data.Length);

                WebResponse response = request.GetResponse();
                Stream stream2 = response.GetResponseStream();
                StreamReader sr = new StreamReader(stream2);

                string menuLunch = sr.ReadToEnd();

                return menuLunch;
            }catch (Exception ex) {
                throw new Exception();
            }
            
        }



        //
        //WebRequest request = WebRequest.Create("http://localhost/Resturant/APIs/Menujson.php");
        //request.Method = "POST";// the method to send data
        //    request.ContentType = "application/x-www-form-urlencoded"; // send the data (Very Important)

        //    string postData = "Type=Lunch";

        //ASCIIEncoding enc = new ASCIIEncoding();
        //byte[] data = enc.GetBytes(postData);
        //Stream stream = request.GetRequestStream();
        //stream.Write(data, 0, data.Length);

        //    WebResponse response = request.GetResponse();
        //Stream stream2 = response.GetResponseStream();
        //StreamReader sr = new StreamReader(stream2);

        //string menuLunch = sr.ReadToEnd();
        //MessageBox.Show(menuLunch);
        //    if (menuLunch != "Sorry, No food in this menu")
        //    {
        //        DataTable dt = JsonConvert.DeserializeObject<DataTable>(menuLunch);
        //dt.TableName = "Menu";
        //        dataGridView1.DataSource = dt;
        //    }



}
}
