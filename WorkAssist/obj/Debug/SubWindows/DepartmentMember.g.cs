﻿#pragma checksum "..\..\..\SubWindows\DepartmentMember.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F6C3C8E7E3DBFBFDF953B46D0AC3B75A2F3941BB"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
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
using WorkAssist.SubWindows;


namespace WorkAssist.SubWindows {
    
    
    /// <summary>
    /// DepartmentMember
    /// </summary>
    public partial class DepartmentMember : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\SubWindows\DepartmentMember.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chkbxIsOnJob;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\SubWindows\DepartmentMember.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TreeView memberTree;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\SubWindows\DepartmentMember.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnInsert;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\SubWindows\DepartmentMember.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridMemberInfo;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\SubWindows\DepartmentMember.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBoxName;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\SubWindows\DepartmentMember.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBoxID;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\SubWindows\DepartmentMember.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSave;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\SubWindows\DepartmentMember.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnEdit;
        
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
            System.Uri resourceLocater = new System.Uri("/WorkAssist;component/subwindows/departmentmember.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\SubWindows\DepartmentMember.xaml"
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
            
            #line 8 "..\..\..\SubWindows\DepartmentMember.xaml"
            ((WorkAssist.SubWindows.DepartmentMember)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.chkbxIsOnJob = ((System.Windows.Controls.CheckBox)(target));
            
            #line 17 "..\..\..\SubWindows\DepartmentMember.xaml"
            this.chkbxIsOnJob.Checked += new System.Windows.RoutedEventHandler(this.ChkbxIsOnJob_Checked);
            
            #line default
            #line hidden
            
            #line 17 "..\..\..\SubWindows\DepartmentMember.xaml"
            this.chkbxIsOnJob.Unchecked += new System.Windows.RoutedEventHandler(this.ChkbxIsOnJob_Unchecked);
            
            #line default
            #line hidden
            return;
            case 3:
            this.memberTree = ((System.Windows.Controls.TreeView)(target));
            
            #line 19 "..\..\..\SubWindows\DepartmentMember.xaml"
            this.memberTree.SelectedItemChanged += new System.Windows.RoutedPropertyChangedEventHandler<object>(this.MemberTree_SelectedItemChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnInsert = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\SubWindows\DepartmentMember.xaml"
            this.btnInsert.Click += new System.Windows.RoutedEventHandler(this.BtnInsert_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.gridMemberInfo = ((System.Windows.Controls.Grid)(target));
            return;
            case 6:
            this.txtBoxName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.txtBoxID = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.btnSave = ((System.Windows.Controls.Button)(target));
            
            #line 73 "..\..\..\SubWindows\DepartmentMember.xaml"
            this.btnSave.Click += new System.Windows.RoutedEventHandler(this.BtnSave_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnEdit = ((System.Windows.Controls.Button)(target));
            
            #line 74 "..\..\..\SubWindows\DepartmentMember.xaml"
            this.btnEdit.Click += new System.Windows.RoutedEventHandler(this.BtnEdit_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

