﻿#pragma checksum "..\..\..\..\Views\AdminPages\Patients.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E4D883A4B0FC2CE0EA131428C43A6C1251C1CD482DDA44F63CF9A674F6624002"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Dentistry.Views;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace Dentistry.Views {
    
    
    /// <summary>
    /// Patients
    /// </summary>
    public partial class Patients : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 48 "..\..\..\..\Views\AdminPages\Patients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid PatientsList;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\..\Views\AdminPages\Patients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTemplateColumn Birth;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\..\Views\AdminPages\Patients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridSearchPanel;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\..\Views\AdminPages\Patients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CloseSerachPanel;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\..\Views\AdminPages\Patients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button OpenSerachPanel;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\..\..\Views\AdminPages\Patients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NameFirst;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\..\Views\AdminPages\Patients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NameLast;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\..\..\Views\AdminPages\Patients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ExperienceOfWork;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\..\..\Views\AdminPages\Patients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DateOfBirth;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\..\..\Views\AdminPages\Patients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button search;
        
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
            System.Uri resourceLocater = new System.Uri("/Dentistry;component/views/adminpages/patients.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\AdminPages\Patients.xaml"
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
            this.PatientsList = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.Birth = ((System.Windows.Controls.DataGridTemplateColumn)(target));
            return;
            case 3:
            this.GridSearchPanel = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.CloseSerachPanel = ((System.Windows.Controls.Button)(target));
            
            #line 82 "..\..\..\..\Views\AdminPages\Patients.xaml"
            this.CloseSerachPanel.Click += new System.Windows.RoutedEventHandler(this.CloseSerachPanel_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.OpenSerachPanel = ((System.Windows.Controls.Button)(target));
            
            #line 85 "..\..\..\..\Views\AdminPages\Patients.xaml"
            this.OpenSerachPanel.Click += new System.Windows.RoutedEventHandler(this.OpenSerachPanel_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.NameFirst = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.NameLast = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.ExperienceOfWork = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.DateOfBirth = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.search = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

