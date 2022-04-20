using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Net;


namespace FFF.Core.CouchDB.Entity
{
    /// <summary>
    /// 回傳訊息
    /// </summary>
    [DataContract]
    public class CouchResponseMessage
    {
        /// <summary>
        /// ok
        /// </summary>
        [DataMember(Name="ok")]
        public bool IsOK { get; set; }

        [DataMember(Name = "id")]
        public string DocumemtID { get; set; }

        /// <summary>
        /// rev
        /// </summary>
        [DataMember(Name = "rev")]
        public string DocumentRev { get; set; }

        /// <summary>
        /// Status Code
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// 目前所狀態的訊息
        /// for Error Message
        /// </summary>
        public string StatusMessage { get; set; }

    }
}
