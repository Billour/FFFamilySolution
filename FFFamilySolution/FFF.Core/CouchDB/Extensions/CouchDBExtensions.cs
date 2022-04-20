using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FFF.Core.CouchDB.Entity;
using Microsoft.Http;
using System.Net;
using System.Runtime.Serialization.Json;

namespace FFF.Core.CouchDB.Extensions
{
    public static class CouchDBExtensions
    {
        public static T2 ToCouchDB<T2>(this DBConfig config, Func<DBContentConfig> contentMethod)
        { 
            DBContentConfig dbContent=contentMethod();

            return config.ToHttpSend<T2>(dbContent.URL,null, dbContent.SendMethod);
        }

        /// <summary>
        /// To CouchDB
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="config"></param>
        /// <param name="contentConfig"></param>
        /// <returns></returns>
        public static T2 ToCouchDB<T1, T2>(this DBConfig config, Func<DBContentConfig<T1>> contentMethod)
        {
            DBContentConfig<T1> dbContent = contentMethod();

            return config.ToHttpSend<T2>(dbContent.URL,
                                        () =>
                                        { 
                                            return HttpContentExtensions.CreateJsonDataContract<T1>(dbContent.RequestContent, null); 
                                        }
                                        ,
                                        dbContent.SendMethod);

        }

        /// <summary>
        /// 送流程至Http Service
        /// </summary>
        /// <typeparam name="T2"></typeparam>
        /// <param name="config"></param>
        /// <param name="url"></param>
        /// <param name="content"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        private static T2 ToHttpSend<T2>(this DBConfig config,string url,Func<HttpContent> GetContentMethod,HttpMethod method)
        {
            T2 returnData = Activator.CreateInstance<T2>();

            HttpClient client = new HttpClient();

            HttpContent content= GetContentMethod();

            client.TransportSettings.Credentials = new NetworkCredential(config.UserID, config.UserPassword);

            HttpResponseMessage resp = null;

            resp = client.Send(method, url, content);

            HttpContent respContent = resp.Content;

            if (resp.StatusCode == HttpStatusCode.OK || resp.StatusCode == HttpStatusCode.Created)
            {
                // return value
                returnData = respContent.ReadAsJsonDataContract<T2>();
            }
            else
            {
                //產生錯誤
                throw new Exception(String.Format("取得資料錯誤:{0}/{1}", resp.StatusCode.ToString(), respContent.ReadAsString()));
            }

            return returnData;
        }

        
    }
}
