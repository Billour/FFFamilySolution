using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFF.Entity.Family
{
    public class User<T> where T:new() 
    {
        /// <summary>
        /// 使用者代號
        /// </summary>
        public string UserID { get; set; }

        public T UserA { get; set; }
    }
}
