#pragma checksum "D:\GIT_Solution\FFFamily\FFFamilySolution\FFSilverlight\Views\About.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0ED9DDA236BD33A7970D54F0072C0AAF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace FFSilverlight {
    
    
    public partial class About : System.Windows.Controls.Page {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.ScrollViewer PageScrollViewer;
        
        internal System.Windows.Controls.TextBlock Sample1;
        
        internal System.Windows.Controls.ContentControl ConventionRegion;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/FFSilverlight;component/Views/About.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.PageScrollViewer = ((System.Windows.Controls.ScrollViewer)(this.FindName("PageScrollViewer")));
            this.Sample1 = ((System.Windows.Controls.TextBlock)(this.FindName("Sample1")));
            this.ConventionRegion = ((System.Windows.Controls.ContentControl)(this.FindName("ConventionRegion")));
        }
    }
}

