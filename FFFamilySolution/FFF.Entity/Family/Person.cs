using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFF.Entity.Family
{
    public class Person
    {
        public string AccountID { get; set; }

        public string AccountPassword { get; set; }

        public bool isDisable { get; set; }

        public DateTime EffectiveDate { get; set; }

        public DateTime ExpireDate { get; set; }
    }
}
