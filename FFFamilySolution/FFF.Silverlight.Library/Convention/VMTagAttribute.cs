using System;
using System.ComponentModel.Composition;

namespace Convention.Convention
{
    /// <summary>
    ///     Metadata for tagging a view model to the view
    /// </summary>
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class VMTagAttribute : ExportAttribute
    {
        public string Tag { get; set; }

        //public Type ViewModelType { get; set; }

        public VMTagAttribute(string tag)
            : base(typeof(Object))
        {
            this.Tag = tag;
            
        }
    }

    public interface IVMTagCapabilities
    {
        string Tag { get; }
    }
}
