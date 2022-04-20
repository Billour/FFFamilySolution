using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FFF.Core.CouchDB.Entity;
using System.Configuration;
using Microsoft.Http;
using System.Runtime.Serialization.Json;
using System.Net.Sockets;
using System.IO;
using System.Net;
using FFF.Core.CouchDB.Extensions;
using System.Reflection;

namespace FFF.Core.CouchDB
{
    /// <summary>
    /// For CouchDB Connection API
    /// 
    /// </summary>
    public class CouchDBDataContext
    {
        public CouchDBDataContext(string connStringKey)
        {
            this.ConnectionStringKey = connStringKey;

            this.Config = new DBConfig(ConfigurationManager.ConnectionStrings[this.ConnectionStringKey].ConnectionString);
        }

        /// <summary>
        /// Connection String Key
        /// </summary>
        private string ConnectionStringKey { get; set; }

        /// <summary>
        /// DB Config 資料
        /// </summary>
        private DBConfig Config { get; set; }

        /// <summary>
        /// Query Data By id
        /// 有_id,_rev
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public T QuerySelect<T>(string id)
        {
            return this.Config.ToCouchDB<T>(() => {

                string url = String.Format("{0}/{1}/{2}", Config.BaseAddress, Config.DataBase, id);

                return new DBContentConfig() { URL = url, SendMethod = HttpMethod.GET };

            });
        }

        /// <summary>
        /// Query Data 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="view"></param>
        /// <returns></returns>
        public CouchDBViewList<T> QuerySelect<T>(DBView view)
        {
            return this.Config.ToCouchDB<DBView,CouchDBViewList<T>>(() =>
            {
                string url = String.Format("{0}/{1}/_temp_view", new object[] { Config.BaseAddress, Config.DataBase });

                return new DBContentConfig<DBView>() { URL = url, SendMethod = HttpMethod.POST, RequestContent=view};
            });
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rev"></param>
        /// <returns></returns>
        public CouchResponseMessage Delete(string id, string rev)
        {
            return this.Config.ToCouchDB<CouchResponseMessage>(() =>
            {
                string url = String.Format("{0}/{1}/{2}?rev={3}", new object[] { Config.BaseAddress, Config.DataBase, id, rev });

                return new DBContentConfig() { URL = url, SendMethod = HttpMethod.DELETE };
            });
        }

        /// <summary>
        /// Save Change
        /// Create/Update
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public CouchResponseMessage SaveChange<T>(string id, T obj)
        {
            return this.Config.ToCouchDB<T,CouchResponseMessage>(() =>
            {
                string url = String.Format("{0}/{1}/{2}", new object[] { Config.BaseAddress, Config.DataBase, id });

                return new DBContentConfig<T>() { URL = url, SendMethod = HttpMethod.PUT, RequestContent=obj};
            });

        }
    }
}
