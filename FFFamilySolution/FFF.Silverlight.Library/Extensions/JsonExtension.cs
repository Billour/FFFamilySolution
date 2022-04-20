using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;


namespace FFF.Silverlight.Library.Extensions
{
    public static class JsonExtension
    {
        

        /// <summary>
        /// Read as Json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static T ReadAsJsonDataContract<T>(this Stream stream)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            
            T obj = (T)serializer.ReadObject(stream);

            return obj;
        }

        public static T JsonStringToObject<T>(this string jsonString)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));

            MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(jsonString));

            T obj = (T)serializer.ReadObject(ms);

            ms.Close();

            return obj;
        }

        public static string ObjectToJsonString<T>(this T obj)
        {
            using( MemoryStream ms = new MemoryStream() )
            {   
                DataContractJsonSerializer serializer =new DataContractJsonSerializer(typeof(T));
                serializer.WriteObject( ms,obj );
                ms.Position = 0;
                using( StreamReader reader = new StreamReader( ms ) )
                {
                    return reader.ReadToEnd();
                 }  
             }
        }
     }
}
