using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Http;

namespace FFF.Core.CouchDB.Entity
{
    public class DBContentConfig
    {
        public string URL { get; set; }

        public HttpMethod SendMethod { get; set; }
    }

    public class DBContentConfig<T>:DBContentConfig
    {
       public T RequestContent { get; set; }
    }


}
