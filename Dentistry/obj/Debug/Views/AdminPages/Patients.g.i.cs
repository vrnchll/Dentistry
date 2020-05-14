﻿#pragma checksum "..\..\..\..\Views\AdminPages\Patients.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "CA7A99A2069EE53F139845907FC082D48A7AFA30"
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
        
        
        #line 26 "..\..\..\..\Views\AdminPages\Patients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid PatientsList;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\Views\AdminPages\Patients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTemplateColumn Birth;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\..\Views\AdminPages\Patients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NameFirst;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\Views\AdminPages\Patients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NameLast;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\Views\AdminPages\Patients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ExperienceOfWork;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\..\Views\AdminPages\Patients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DateOfBirth;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\Views\AdminPages\Patients.xaml"
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
            this.NameFirst = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.NameLast = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.ExperienceOfWork = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.DateOfBirth = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.search = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

