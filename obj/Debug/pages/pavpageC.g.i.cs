﻿#pragma checksum "..\..\..\pages\pavpageC.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "BF3B91C129575612B55C7B972025F58C1756EB842366106FBCCB9C628708D2A3"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using rentmall.pages;


namespace rentmall.pages {
    
    
    /// <summary>
    /// pavpageC
    /// </summary>
    public partial class pavpageC : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\..\pages\pavpageC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox pav_name;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\pages\pavpageC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox coef;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\pages\pavpageC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button pav_stat;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\pages\pavpageC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox price;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\pages\pavpageC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox lvl;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\pages\pavpageC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox sqr_box;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\pages\pavpageC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button backbut;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\pages\pavpageC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button changbut;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\pages\pavpageC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Popup stats;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\pages\pavpageC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox stats_list;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/rentmall;component/pages/pavpagec.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\pages\pavpageC.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.pav_name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.coef = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.pav_stat = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\..\pages\pavpageC.xaml"
            this.pav_stat.Click += new System.Windows.RoutedEventHandler(this.mall_stat_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.price = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.lvl = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.sqr_box = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.backbut = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\..\pages\pavpageC.xaml"
            this.backbut.Click += new System.Windows.RoutedEventHandler(this.backbut_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.changbut = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\..\pages\pavpageC.xaml"
            this.changbut.Click += new System.Windows.RoutedEventHandler(this.changbut_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.stats = ((System.Windows.Controls.Primitives.Popup)(target));
            return;
            case 10:
            this.stats_list = ((System.Windows.Controls.ListBox)(target));
            
            #line 59 "..\..\..\pages\pavpageC.xaml"
            this.stats_list.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.stats_list_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

