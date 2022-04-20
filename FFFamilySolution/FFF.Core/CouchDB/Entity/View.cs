using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace FFF.Core.CouchDB.Entity
{
    /// <summary>
    /// View For DB View
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [DataContract]
    public class View<T>
    {
        [DataMember(Name = "id")]
        public string ViewID { get; set; }

        [DataMember(Name = "key")]
        public string ViewKey { get; set; }

        [DataMember(Name = "value")]
        public T ViewValue { get; set; }
    }
}
