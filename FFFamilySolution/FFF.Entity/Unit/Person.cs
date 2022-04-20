using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFF.Entity.Unit
{
    /// <summary>
    /// 個人化群組
    /// </summary>
    public class Person:UnitBase
    {
        public Person():base()
        {
            this.IsShared = false;
        }
    }
}
