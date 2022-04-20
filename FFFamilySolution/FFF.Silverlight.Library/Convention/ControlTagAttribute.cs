using System;
using System.ComponentModel.Composition;
using System.Windows.Controls;

namespace Convention.Convention
{
    /// <summary>
    ///     Meta data to tag a control for marrying with a region and viewmodel
    /// </summary>
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class,AllowMultiple = false)]
    public class ControlTagAttribute : ExportAttribute 
    {
        public string Tag { get; set; }

        public ControlTagAttribute(string tag) : base(typeof(UserControl))
        {
            Tag = tag;
        }
    }

    public interface IControlTagCapabilities
    {
        string Tag { get; }
    }
}
