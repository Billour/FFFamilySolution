﻿#pragma checksum "D:\GIT_Solution\FFFamily\FFFamilySolution\FFF.Prism.Silverlight\Views\View1.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9B1A38A1C4E27977CB560074E6B685CB"
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


namespace FFF.Prism.Silverlight.Views {
    
    
    public partial class View1 : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBlock lb1;
        
        internal System.Windows.Controls.TextBox CID;
        
        internal System.Windows.Controls.Button btnSubmit;
        
        internal System.Windows.Controls.TextBox PersonID;
        
        internal System.Windows.Controls.TextBox PersonName;
        
        internal System.Windows.Controls.Button btnSave;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/FFF.Prism.Silverlight;component/Views/View1.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.lb1 = ((System.Windows.Controls.TextBlock)(this.FindName("lb1")));
            this.CID = ((System.Windows.Controls.TextBox)(this.FindName("CID")));
            this.btnSubmit = ((System.Windows.Controls.Button)(this.FindName("btnSubmit")));
            this.PersonID = ((System.Windows.Controls.TextBox)(this.FindName("PersonID")));
            this.PersonName = ((System.Windows.Controls.TextBox)(this.FindName("PersonName")));
            this.btnSave = ((System.Windows.Controls.Button)(this.FindName("btnSave")));
        }
    }
}
