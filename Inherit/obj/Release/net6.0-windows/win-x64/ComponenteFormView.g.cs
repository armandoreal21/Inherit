﻿#pragma checksum "..\..\..\..\ComponenteFormView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D727AAA9C684254E468B96541BE068111E227599"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace Inherit {
    
    
    /// <summary>
    /// ComponenteFormView
    /// </summary>
    public partial class ComponenteFormView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\..\..\ComponenteFormView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Inherit.ComponenteFormView window;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\ComponenteFormView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel barraTitle;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\..\ComponenteFormView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbID;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\ComponenteFormView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbNombre;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\..\ComponenteFormView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbCantidad;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.7.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Inherit;component/componenteformview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\ComponenteFormView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.7.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.window = ((Inherit.ComponenteFormView)(target));
            return;
            case 2:
            this.barraTitle = ((System.Windows.Controls.DockPanel)(target));
            
            #line 32 "..\..\..\..\ComponenteFormView.xaml"
            this.barraTitle.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 33 "..\..\..\..\ComponenteFormView.xaml"
            ((System.Windows.Controls.Image)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.CloseButtonDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.tbID = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.tbNombre = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.tbCantidad = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            
            #line 96 "..\..\..\..\ComponenteFormView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CrearComponente_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
