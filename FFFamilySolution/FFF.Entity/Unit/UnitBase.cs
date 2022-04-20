using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFF.Entity.Unit
{
    public class UnitBase
    {
        public UnitBase()
        {
            this.IsShared = true;
        }

        /// <summary>
        /// UnitID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// UnitName
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 分類
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// 是否為最高層級
        /// </summary>
        public bool IsTop { get; set; }

        /// <summary>
        /// 是否屬於系統分類
        /// default:false
        /// </summary>
        public bool IsSystem { get; set; }

        /// <summary>
        /// Is Shared 
        /// default:true
        /// </summary>
        public bool IsShared { get; set; }

        public bool IsEnable { get; set; }

        public DateTime EffectiveTime { get; set; }

        public DateTime ExpireTime { get; set; }

        
    }
}
