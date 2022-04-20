using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Net;

namespace FFF.Core.CouchDB.Entity
{

    /// <summary>
    /// 回傳資料
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [DataContract]
    public class CouchDBViewList<T>
    {
        public CouchDBViewList()
        {
            Rows = new List<View<T>>();
        }
        /// <summary>
        /// All Rows Count
        /// </summary>
        [DataMember(Name = "total_rows")]
        public string TotalRow { get; set; }

        /// <summary>
        /// offset
        /// </summary>
        [DataMember(Name="offset")]
        public string OffSet { get; set; }

        /// <summary>
        /// Daata
        /// </summary>
        [DataMember(Name = "rows")]
        public List<View<T>> Rows { get; set; }

        /// <summary>
        /// Status Code
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// 目前所狀態的訊息
        /// </summary>
        public string StatusMessage { get; set; }

        /// <summary>
        /// 加上是否OK
        /// </summary>
        public bool IsOK { get; set; }

    }
}
