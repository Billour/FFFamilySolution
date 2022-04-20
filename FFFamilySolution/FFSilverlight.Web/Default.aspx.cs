using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FFF.Core.CouchDB;
using FFF.Core.CouchDB.Entity;
using System.Runtime.Serialization;
using Microsoft.Http;
using System.Runtime.Serialization.Json;

namespace FFSilverlight.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            //HttpClient client = new HttpClient();
            //string baseUrl = "http://localhost:1107/family/VVV";
            //string aa = client.Get(baseUrl).Content.ReadAsJsonDataContract<string>();
        }

        /// <summary>
        /// 新增一筆資料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClick_Click(object sender, EventArgs e)
        {
            //新增一筆資料
            //Family obj = new Family() { ID = "A", Name = "Name1",Table="Family"};

            //CouchDBDataContext context = new CouchDBDataContext("CouchDB");

            //CouchResponseMessage result= context.SaveChange<Family>(DateTime.Now.ToString("yyyyMMddHHmmss"), obj);

            //if (result.IsOK)
            //{
            //    lbMsg.Text = "id=" + result.DocumemtID + ":rev=" + result.DocumentRev;
            //}
            //else
            //{
            //    lbMsg.Text = "Fail";
            //}
        }

        /// <summary>
        /// 刪除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            //CouchDBDataContext context = new CouchDBDataContext("CouchDB");

            //CouchResponseMessage result = context.Delete("20101220160238", "1-ab1d26d181430a3bbb34353775b0d22b");

            //if (result.IsOK)
            //{
            //    lbMsg.Text = "id=" + result.DocumemtID + ":rev=" + result.DocumentRev;
            //}
            //else
            //{
            //    lbMsg.Text = "Fail"+result.StatusMessage;
            //}
        }

        /// <summary>
        /// 查詢一個程式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            //CouchDBDataContext context = new CouchDBDataContext("CouchDB");

            //vFamily result = context.QuerySelect<vFamily>("20101220160208");
         
        }

        /// <summary>
        /// Document
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button3_Click(object sender, EventArgs e)
        {
            ////更新一筆資料
            //vFamily obj = new vFamily() { DocumemtID = "20101220160208", DocumentRev = "1-ab1d26d181430a3bbb34353775b0d22b", ID = "A2", Name = "Name2" };

            //CouchDBDataContext context = new CouchDBDataContext("CouchDB");

            //CouchResponseMessage result = context.SaveChange<vFamily>("20101220160208", obj);

            //if (result.IsOK)
            //{
            //    lbMsg.Text = "id=" + result.DocumemtID + ":rev=" + result.DocumentRev;
            //}
            //else
            //{
            //    lbMsg.Text = "Fail";
            //}
        }

        /// <summary>
        /// View Sample
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnView_Click(object sender, EventArgs e)
        {
//            string map = @"
//                            function(doc)
//                            { 
//                                 
//                                 emit(null, doc); 
//                                     
//                            }
//                         ";
//            CouchDBDataContext context = new CouchDBDataContext("CouchDB");

//            DBView view=new DBView(){ Map=map};

//            CouchDBViewList<vFamily> list = context.QuerySelect<vFamily>(view);
        }
    }

    /// <summary>
    /// Update Use
    /// </summary>
    [DataContract]
    public class Family:ITable
    {
        public Family()
        {
            this.Table = "Family";
        }

        [DataMember]
        public string ID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Table { get; set; }
        
    }

    [DataContract]
    public class vFamily :Family, CouchDBEntity
    {
        public vFamily()
            : base()
        { 
            
        }

        /// <summary>
        /// Document ID
        /// </summary>
        [DataMember(Name="_id")]
        public string DocumemtID{get;set;}

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "_rev")] 
        public string DocumentRev { get; set; }
       
    }

    

    //[DataContract]
    //public class View<T>
    //{
    //    [DataMember(Name = "id")]
    //    public string ViewID { get; set; }

    //    [DataMember(Name = "key")]
    //    public string ViewKey { get; set; }

    //    [DataMember(Name = "value")]
    //    public T ViewValue { get; set; }
    //}
}