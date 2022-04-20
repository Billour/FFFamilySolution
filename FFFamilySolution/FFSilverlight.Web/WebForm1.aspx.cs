using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.Serialization;
using Microsoft.Http;
using System.Runtime.Serialization.Json;
using FFSilverlight.Web.Common;
using System.Json;
using FFF.Entity.Family;

namespace FFSilverlight.Web
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();

            //string baseUrl = "http://localhost:1107/service/authentication/Login?logid=jack";
            //string aa = client.Get(baseUrl).Content.ReadAsJsonDataContract<string>();

            //Response.Write(aa);
            //request.Headers.ContentType = "application/xml";
            string baseUrl = "http://localhost:1107/service/authentication/Login?logid=jack";
            //string aa = client.Get(baseUrl).Content.ReadAsJsonDataContract<string>();
            //bool isOK= client.Post(baseUrl,HttpContentExtensions.CreateJsonDataContract<string>("Hello")).Content.ReadAsJsonDataContract<bool>();
            HttpResponseMessage msg = client.Post(baseUrl,HttpContentExtensions.CreateDataContract<Person>(new Person() { AccountID="John", AccountPassword="password", EffectiveDate=DateTime.Now, ExpireDate=DateTime.Now, isDisable=false}));

            string aa = msg.Content.ReadAsJsonDataContract<string>();
            
            Func<int, int, int> Add = (x, y) => x + y;

            int add= Add(5, 3);

        }



        

       
    }
}