// Updated by XamlIntelliSenseFileGenerator 11/03/2020 11.35.47
#pragma checksum "..\..\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "61F7ECD62017C375B043E8134A0B0938915E7D33DEF9298B3161500ED9AC5380"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Msagl.GraphViewerGdi;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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
using grafGUI;


namespace grafGUI
{


    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {


#line 25 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ChoosenFile;

#line default
#line hidden


#line 28 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button OpenfilesButton;

#line default
#line hidden


#line 34 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ChoosenFile2;

#line default
#line hidden


#line 37 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button OpenfilesButton2;

#line default
#line hidden


#line 56 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Query;

#line default
#line hidden


#line 60 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Prev;

#line default
#line hidden


#line 64 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Next;

#line default
#line hidden


#line 69 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button QueryButton;

#line default
#line hidden


#line 80 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Hasil;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/grafGUI;component/mainwindow.xaml", System.UriKind.Relative);

#line 1 "..\..\MainWindow.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.ChoosenFile = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 2:
                    this.OpenfilesButton = ((System.Windows.Controls.Button)(target));

#line 28 "..\..\MainWindow.xaml"
                    this.OpenfilesButton.Click += new System.Windows.RoutedEventHandler(this.button1_Click);

#line default
#line hidden
                    return;
                case 3:
                    this.ChoosenFile2 = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 4:
                    this.OpenfilesButton2 = ((System.Windows.Controls.Button)(target));

#line 37 "..\..\MainWindow.xaml"
                    this.OpenfilesButton2.Click += new System.Windows.RoutedEventHandler(this.button2_Click);

#line default
#line hidden
                    return;
                case 5:
                    this.Query = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 6:
                    this.Prev = ((System.Windows.Controls.Button)(target));

#line 60 "..\..\MainWindow.xaml"
                    this.Prev.Click += new System.Windows.RoutedEventHandler(this.button5_Click);

#line default
#line hidden
                    return;
                case 7:
                    this.Next = ((System.Windows.Controls.Button)(target));

#line 64 "..\..\MainWindow.xaml"
                    this.Next.Click += new System.Windows.RoutedEventHandler(this.button4_Click);

#line default
#line hidden
                    return;
                case 8:
                    this.QueryButton = ((System.Windows.Controls.Button)(target));

#line 69 "..\..\MainWindow.xaml"
                    this.QueryButton.Click += new System.Windows.RoutedEventHandler(this.button3_Click);

#line default
#line hidden
                    return;
                case 9:
                    this.Hasil = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 10:
                    this.windowsFormsHost1 = ((System.Windows.Forms.Integration.WindowsFormsHost)(target));
                    return;
                case 11:
                    this.gViewer = ((Microsoft.Msagl.GraphViewerGdi.GViewer)(target));
                    return;
            }
            this._contentLoaded = true;
        }
    }
}

