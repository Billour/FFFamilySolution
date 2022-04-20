using System;
using System.Collections.Generic;
using System.Linq;


namespace FFF.Silverlight.Library.Extensions
{
    /// <summary>
    /// For Silverlight Generic List<T> Find Method
    /// 
    /// </summary>
    public static class ListGenericExtension
    {
        public static object Find<T>(this List<T> list,Type type)
        {
            return list.Where(p => p.GetType() == type).ToList().FirstOrDefault();
        }
    }
}
