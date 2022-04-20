using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFF.Entity
{
    /// <summary>
    /// Sex
    /// </summary>
    public enum EnumSex
    { 
        /// <summary>
        /// Male
        /// </summary>
        M,
        /// <summary>
        /// Female
        /// </summary>
        F
    }

    /// <summary>
    /// Role
    /// </summary>
    public enum EnumRole
    { 
        /// <summary>
        /// Admin
        /// </summary>
        Admin,

        /// <summary>
        /// User
        /// </summary>
        User,

        /// <summary>
        /// Guest
        /// </summary>
        Guest
    }

    /// <summary>
    /// Unit Role
    /// </summary>
    public enum EnumUnitRole
    { 
        Admin,

        User
    }
}
