using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.OracleClient;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Collections;
using System.ComponentModel;
using FFF.Core.Data.Extensions;
using FFF.Core.Logic;
using System.Reflection;

using FFF.Core.Data.Attributes;


namespace FFF.Core.Data
{
    public class DataContext
    {
        public const int QueryMode = 1;
        public const int InsertMode = 2;
        public const int UpdateMode = 4;

        public const string COMMAND_INSERT = "insert";
        public const string COMMAND_UPDATE = "update";
        public const string COMMAND_DELETE = "delete";

        /// <summary>
        /// 資料字串的Key(For Enterprise Library Using) 
        /// </summary>
        public string ConnectionStringKey { get; set; }

        /// <summary>
        /// DataBase 
        /// </summary>
        public Database DBase { get; set; }

        /// <summary>
        /// Constructor Default ConnectionString
        /// </summary>
        public DataContext()
        {
            this.DBase = DatabaseFactory.CreateDatabase();
        }

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="connStringKey"></param>
        public DataContext(string connStringKey)
        {
            this.ConnectionStringKey = connStringKey;

            this.DBase = DatabaseFactory.CreateDatabase(this.ConnectionStringKey);
        }

        /// <summary>
        /// Query Select 
        /// Return Generic List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">sql/packagename</param>
        /// <param name="parameterValues">if no values set it to null</param>
        /// <returns></returns>
        public List<T> QuerySelect<T>(string sql,string mapId, params object[] parameterValues)
        {
            EnumSQLContext mode =mapId.GetSQLContextMap<T>().SQLContextType;

            DataTable dt = Select(mode, sql, parameterValues);

            return dt.ToGenericList<T>(mapId);

        }

        

        /// <summary>
        /// Query By SQL String
        /// Return DataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>DataTable</returns>
        public DataTable QuerySelect(string sql, params object[] parameterValues)
        {
            return Select(EnumSQLContext.SQLString, sql, parameterValues);
        }

        /// <summary>
        /// 取回資料庫資料表
        /// DataTable
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="sql"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        public DataTable QuerySelect(EnumSQLContext mode, string sql, params object[] parameterValues)
        {
            return Select(mode,sql, parameterValues);
        }

        /// <summary>
        /// Select By SQL String
        /// </summary>
        /// <param name="sql">SQL String or PackageName</param>
        /// <returns>DataTable</returns>
        private DataTable Select(EnumSQLContext mode, string sql,params object[] parameterValues)
        {
            Database db = DBase;

            DbCommand command = null;

            switch (mode)
            { 
                case EnumSQLContext.SQLString:
                    
                    if (parameterValues != null)
                    {
                        sql = String.Format(sql, parameterValues);
                    }
                    
                    command = db.GetSqlStringCommand(sql);
                    
                    break;
                case EnumSQLContext.StoreProcedure:
                    
                    if (parameterValues != null)
                    {
                        command = db.GetStoredProcCommand(sql,parameterValues);
                    }
                    else
                    {
                        command = db.GetStoredProcCommand(sql);
                    }
                    
                    break;
                default:
                    throw new Exception(String.Format("無法取得此類型={0}的實作，請查明",mode.ToString()));
            }

            DataSet ds = new DataSet();

            db.LoadDataSet(command, ds, "Table1");

            return ds.Tables["Table1"];
        }

        
        /// <summary>
        /// Save Change By SQL
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public bool SaveChange(string sql)
        {
            List<DbCommand> commandTextList = new List<DbCommand>();

            DbCommand command = this.DBase.GetSqlStringCommand(sql);

            commandTextList.Add(command);

            return SaveChangeCommand(commandTextList);
        }

        /// <summary>
        /// Save Command
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public bool SaveChange(DbCommand command)
        {
            List<DbCommand> commandList = new List<DbCommand>();
            commandList.Add(command);

            return SaveChangeCommand(commandList);
        }


        /// <summary>
        /// Save Command List
        /// </summary>
        /// <param name="commandList"></param>
        /// <returns></returns>
        public bool SaveChange(IEnumerable commandList)
        {
            return SaveChangeCommand(commandList);
        }

        /// <summary>
        /// Save Command List
        /// </summary>
        /// <param name="SqlCommands"></param>
        /// <returns></returns>
        private bool SaveChangeCommand(IEnumerable SqlCommands)
        {
            Database db = this.DBase;

            IDbConnection connection = null;

            IDbTransaction transaction = null;

            try
            {
                connection = db.CreateConnection();

                connection.Open();

                transaction = connection.BeginTransaction();

                Int32 rowsEffected = 0;

                foreach (Object s in SqlCommands)
                {

                    DbCommand command = null;

                    if (s.GetType().Equals(typeof(String)))
                    {
                        command = db.GetSqlStringCommand(s as string);
                    }
                    else
                    {
                        DbCommand cmd = s as DbCommand;
                        command = cmd;
                    }

                    
                    command.Connection = (DbConnection)connection;
                    command.Transaction = (DbTransaction)transaction;
                    rowsEffected += command.ExecuteNonQuery();
                }

                transaction.Commit();

                return rowsEffected >= 0;
            }
            catch
            {
                transaction.Rollback();

                throw;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }

            }
        }

        ///// <summary>
        ///// Save By DataSet By SQL String
        ///// </summary>
        ///// <param name="ds"></param>
        ///// <returns></returns>
        //public bool SaveChange(DataSet ds)
        //{
        //    Database db = DBase;

        //    IDbConnection connection = null;

        //    IDbTransaction transaction = null;

        //    int rowsEffected = 0;

        //    try
        //    {
        //        connection = db.CreateConnection();

        //        connection.Open();

        //        transaction = connection.BeginTransaction();

        //        List<DbCommand> commList = new List<DbCommand>();

        //        foreach (DataTable dt in ds.Tables)
        //        {
        //            //確認DataTable 有放TableName
        //            if (dt.TableName == "")
        //            {
        //                throw new Exception("無法取得Table Name資料請查明");
        //            }

        //            if (dt.ExtendedProperties["COMMAND_MODE"].ToString() == "")
        //            {
        //                throw new Exception("無法取得目前的資料庫操作模式請查明，是否忘了設定Insert/update/delete");
        //            }

        //            foreach (DataRow row in dt.Rows)
        //            {
        //                DbCommand comm = GetSqlDataRowCommand(db, row);

        //                commList.Add(comm);
        //            }

        //        }


        //        foreach (DbCommand command in commList)
        //        {

        //            command.Connection = (DbConnection)connection;
        //            command.Transaction = (DbTransaction)transaction;
        //            rowsEffected += command.ExecuteNonQuery();
        //        }

        //        transaction.Commit();

        //        return rowsEffected > 0;
        //    }
        //    catch
        //    {
        //        transaction.Rollback();

        //        throw;
        //    }
        //    finally
        //    {
        //        if (connection.State == ConnectionState.Open)
        //        {
        //            connection.Close();
        //        }

        //    }
        //}


        //private DbCommand GetSqlDataRowCommand(Database db, DataRow row)
        //{
        //    string sql = QuerySqlString(row);

        //    DbCommand comm = this.DBase.GetSqlStringCommand(sql);

        //    List<SqlParameter> list = CreateNewParamerListByDataRow(row);

        //    foreach (DbParameter s in list)
        //    {
        //        comm.Parameters.Add(s);
        //    }

        //    return comm;
        //}

        ///// <summary>
        ///// 取得一整個的Sql Command
        ///// </summary>
        ///// <param name="db"></param>
        ///// <param name="ds"></param>
        ///// <returns></returns>
        //public List<DbCommand> GetSqlDataSetCommand(DataSet ds)
        //{
        //    List<DbCommand> commList = new List<DbCommand>();

        //    foreach (DataTable dt in ds.Tables)
        //    {
        //        foreach (DataRow row in dt.Rows)
        //        {
        //            string sql = QuerySqlString(row);

        //            DbCommand comm = DBase.GetSqlStringCommand(sql);

        //            List<SqlParameter> list = CreateNewParamerListByDataRow(row);

        //            foreach (DbParameter s in list)
        //            {
        //                comm.Parameters.Add(s);
        //            }

        //            commList.Add(comm);
        //        }
        //    }

        //    return commList;

        //}

        ///// <summary>
        ///// 等待實作中，切記切記
        ///// </summary>
        ///// <param name="row"></param>
        ///// <param name="commamd"></param>
        ///// <returns></returns>
        //public DbCommand GetSqlDataRowCommand(DataRow row, string commamd)
        //{

        //    string sql = QuerySqlString(row);

        //    DbCommand comm = DBase.GetSqlStringCommand(sql);

        //    List<SqlParameter> list = CreateNewParamerListByDataRow(row);

        //    foreach (DbParameter s in list)
        //    {
        //        comm.Parameters.Add(s);
        //    }



        //    return comm;

        //}

        //private string QuerySqlString(DataRow row)
        //{
        //    string sql = "";

        //    string mode = row.Table.ExtendedProperties["COMMAND_MODE"].ToString();

        //    if (mode == COMMAND_INSERT)
        //    {
        //        string paraSQL = "";
        //        string objSQL = "";

        //        //Insert Mode
        //        sql = " insert into ";

        //        sql += row.Table.TableName;

        //        sql += "(";

        //        for (int i = 0; i < row.Table.Columns.Count; i++)
        //        {
        //            if (row[row.Table.Columns[i].ColumnName] != System.DBNull.Value)
        //            {
        //                DateTime dtime;

        //                bool isVisible = false;

        //                if (DateTime.TryParse(row[row.Table.Columns[i].ColumnName].ToString(), out dtime))
        //                {
        //                    if (dtime != DateTime.MinValue)
        //                    {
        //                        isVisible = true;
        //                    }
        //                }
        //                else
        //                {
        //                    isVisible = true;
        //                }

        //                if (isVisible)
        //                {
        //                    if (row[row.Table.Columns[i].ColumnName] != System.DBNull.Value)
        //                    {
        //                        objSQL += row.Table.Columns[i].ColumnName + ",";
        //                        paraSQL += "@" + row.Table.Columns[i].ColumnName + ",";
        //                    }
        //                }


        //            }

        //        }

        //        if (objSQL.Length > 0)
        //        {
        //            objSQL = objSQL.Substring(0, objSQL.Length - 1);
        //        }

        //        if (paraSQL.Length > 0)
        //        {
        //            paraSQL = paraSQL.Substring(0, paraSQL.Length - 1);
        //        }

        //        sql += objSQL;

        //        sql += ")values(";

        //        sql += paraSQL;

        //        sql += ")";
        //    }
        //    else if (mode == COMMAND_UPDATE)
        //    {
        //        //Check Key is Exist
        //        if (row.Table.PrimaryKey.Length == 0)
        //        {
        //            throw new Exception("無法取得此資料表的Key值,請查明");
        //        }

        //        string paraSQL = "";
        //        string objSQL = "";

        //        //Insert Mode
        //        sql = " update ";

        //        sql += row.Table.TableName;

        //        sql += " set ";

        //        SortedList<string, string> keys = new SortedList<string, string>();

        //        foreach (DataColumn col in row.Table.PrimaryKey)
        //        {
        //            keys.Add(col.ColumnName, col.ColumnName);
        //        }

        //        for (int i = 0; i < row.Table.Columns.Count; i++)
        //        {
        //            if (row[row.Table.Columns[i].ColumnName] != System.DBNull.Value)
        //            {

        //                if (!keys.ContainsKey(row.Table.Columns[i].ColumnName))
        //                {
        //                    objSQL += row.Table.Columns[i].ColumnName + "=" + "@" + row.Table.Columns[i].ColumnName + ",";
        //                }


        //            }

        //        }

        //        if (objSQL.Length > 0)
        //        {
        //            objSQL = objSQL.Substring(0, objSQL.Length - 1);
        //        }

        //        sql += objSQL;

        //        //Where clause
        //        sql += " where 1=1";

        //        foreach (DataColumn col in row.Table.PrimaryKey)
        //        {
        //            sql += " and " + col.ColumnName + "=" + "@" + col.ColumnName;
        //        }




        //    }
        //    else if (mode == COMMAND_DELETE)
        //    {
        //        //Check Key is Exist
        //        if (row.Table.PrimaryKey.Length == 0)
        //        {
        //            throw new Exception("無法取得此資料表的Key值,請查明");
        //        }

        //        //Delete Mode
        //        sql = " delete from ";

        //        sql += row.Table.TableName;

        //        sql += " where 1=1";

        //        foreach (DataColumn col in row.Table.PrimaryKey)
        //        {
        //            sql += " and " + col.ColumnName + "=" + "@" + col.ColumnName;
        //        }
        //    }
        //    else
        //    {
        //        throw new Exception("無法取得目前的命令模式");
        //    }

        //    return sql;
        //}

        //private List<SqlParameter> CreateNewParamerListByDataRow(DataRow row)
        //{
        //    List<SqlParameter> list = new List<SqlParameter>();

        //    foreach (DataColumn col in row.Table.Columns)
        //    {
        //        if (row[col.ColumnName] != DBNull.Value && row[col.ColumnName] != null)
        //        {
        //            DateTime dtime;

        //            bool isVisible = false;

        //            if (DateTime.TryParse(row[col.ColumnName].ToString(), out dtime))
        //            {
        //                if (dtime != DateTime.MinValue)
        //                {
        //                    isVisible = true;
        //                }
        //            }
        //            else
        //            {
        //                isVisible = true;
        //            }

        //            if (isVisible)
        //            {
        //                SqlParameter pa = new SqlParameter("@" + col.ColumnName, GetDBType(col.DataType));
        //                pa.Value = row[col.ColumnName];

        //                list.Add(pa);
        //            }


        //        }
        //    }

        //    return list;
        //}


        //private SqlDbType GetDBType(Type theType)
        //{
        //    SqlParameter p1;
        //    TypeConverter tc;
        //    p1 = new SqlParameter();
        //    tc = TypeDescriptor.GetConverter(p1.DbType);
        //    if (tc.CanConvertFrom(theType))
        //    {
        //        p1.DbType = (DbType)tc.ConvertFrom(theType.Name);
        //    }
        //    else
        //    {
        //        //Try brute force 
        //        try
        //        {
        //            p1.DbType = (DbType)tc.ConvertFrom(theType.Name);
        //        }
        //        catch (Exception ex)
        //        {
        //            //Do Nothing 
        //        }
        //    }
        //    return p1.SqlDbType;
        //}
    }
}
