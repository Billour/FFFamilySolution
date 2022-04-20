using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace FFF.Core.CouchDB.Entity
{
    [DataContract]
    public class DBView
    {
        [DataMember(Name="map")]
        public string Map { get; set; }

        [DataMember(Name = "Reduce")]
        public string Reduce { get; set; }
    }
}
