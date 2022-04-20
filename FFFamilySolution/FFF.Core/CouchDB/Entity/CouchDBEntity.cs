using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace FFF.Core.CouchDB.Entity
{
    /// <summary>
    /// Couch DB Base Entity
    /// </summary>
   
    public interface CouchDBEntity
    {

        /// <summary>
        /// couchdb _id
        /// </summary>
        //[DataMember(Name = "_id")]
        string DocumemtID { get; set; }

        /// <summary>
        /// couchdb _rev
        /// </summary>
        //[DataMember(Name = "_rev")]
        string DocumentRev { get; set; }

       
    }
}
