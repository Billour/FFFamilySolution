using System;
using System.ComponentModel.Composition;
using System.Windows.Controls;

namespace Convention.Convention
{
    /// <summary>
    ///     Metadata for tagging a region for a view
    /// </summary>
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class RegionTagAttribute : ExportAttribute
    {
        public string Tag { get; set; }

        public RegionTagAttribute(string tag)
            : base(typeof(ContentControl))
        {
            Tag = tag;
        }
    }

    public interface IRegionTagCapabilities
    {
        string Tag { get; }
    }
}
