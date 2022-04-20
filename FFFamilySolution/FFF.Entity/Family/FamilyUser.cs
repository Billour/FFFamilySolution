using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFF.Entity.Family
{
    /// <summary>
    /// 家庭成員
    /// </summary>
    public class FamilyUser
    {
        public string UserID { get; set; }

        public string UserName { get; set; }

        public EnumSex Sex { get; set; }

        public List<EnumRole> RoleList { get; set; }
        
    }
}
