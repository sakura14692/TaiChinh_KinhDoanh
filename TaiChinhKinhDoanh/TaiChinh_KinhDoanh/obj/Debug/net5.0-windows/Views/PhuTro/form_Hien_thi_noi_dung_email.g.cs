﻿#pragma checksum "..\..\..\..\..\Views\PhuTro\form_Hien_thi_noi_dung_email.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0CE82B453BE8DAC966D0EC8DA73E791871CEABDF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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
using TaiChinh_KinhDoanh.Views.PhuTro;


namespace TaiChinh_KinhDoanh.Views.PhuTro {
    
    
    /// <summary>
    /// form_Hien_thi_noi_dung_email
    /// </summary>
    public partial class form_Hien_thi_noi_dung_email : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\..\..\..\Views\PhuTro\form_Hien_thi_noi_dung_email.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textblock_TieuDe;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\..\Views\PhuTro\form_Hien_thi_noi_dung_email.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_Minimized;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\..\..\Views\PhuTro\form_Hien_thi_noi_dung_email.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_Close;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\..\..\Views\PhuTro\form_Hien_thi_noi_dung_email.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textblock_tin_nhan;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.8.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TaiChinh_KinhDoanh;component/views/phutro/form_hien_thi_noi_dung_email.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\PhuTro\form_Hien_thi_noi_dung_email.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.8.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 13 "..\..\..\..\..\Views\PhuTro\form_Hien_thi_noi_dung_email.xaml"
            ((TaiChinh_KinhDoanh.Views.PhuTro.form_Hien_thi_noi_dung_email)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.textblock_TieuDe = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.button_Minimized = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\..\..\..\Views\PhuTro\form_Hien_thi_noi_dung_email.xaml"
            this.button_Minimized.Click += new System.Windows.RoutedEventHandler(this.button_Minimized_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.button_Close = ((System.Windows.Controls.Button)(target));
            
            #line 68 "..\..\..\..\..\Views\PhuTro\form_Hien_thi_noi_dung_email.xaml"
            this.button_Close.Click += new System.Windows.RoutedEventHandler(this.button_Close_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.textblock_tin_nhan = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

