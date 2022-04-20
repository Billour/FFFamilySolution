using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFF.Entity.Unit
{
    /// <summary>
    /// Unit ID
    /// </summary>
    public class Unit<T>
    {
        /// <summary>
        /// UnitID
        /// </summary>
        public string UnitID { get; set; }

        /// <summary>
        /// Unit ID
        /// </summary>
        public T UnitNode { get; set; }

        /// <summary>
        /// 上層Unit ID
        /// </summary>
        public string ParentUnitID { get; set; }

        /// <summary>
        /// 下層的單位
        /// </summary>
        public List<Unit<T>> ChildrenUnit { get; set; }

    }
}
