using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

namespace FFF.Core.CouchDB.Entity
{
    public class DBConfig
    {
        public DBConfig(string connString)
        {
            this.ConnectionString = connString;
        }

        private string _ConnectionString;

        private DbConnectionStringBuilder builder { get; set; }

        public string ConnectionString
        {
            get { return _ConnectionString; }
            set
            {
                _ConnectionString = value;

                builder = new DbConnectionStringBuilder();
                builder.ConnectionString = value;

        } }

        public string BaseAddress { get {

            return builder["Server"].ToString();

        } }

        public string DataBase
        {
            get
            {

                return builder["Database"].ToString();

            }
        }

        public string UserID
        {
            get
            {

                return builder["User"].ToString();

            }
        }

        /// <summary>
        /// User Password
        /// </summary>
        public string UserPassword
        {
            get
            {
                
                return builder["Password"].ToString();

            }
        }
    }
}
