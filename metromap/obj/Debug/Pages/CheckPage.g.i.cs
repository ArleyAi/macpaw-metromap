﻿#pragma checksum "..\..\..\Pages\CheckPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "196C641A9755033C21294340476753BB"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using FirstFloor.ModernUI.Presentation;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Controls;
using FirstFloor.ModernUI.Windows.Converters;
using FirstFloor.ModernUI.Windows.Navigation;
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


namespace DS {
    
    
    /// <summary>
    /// CheckPage
    /// </summary>
    public partial class CheckPage : FirstFloor.ModernUI.Windows.Controls.ModernFrame, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\Pages\CheckPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbFilePath;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Pages\CheckPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonChoose;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Pages\CheckPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbSignature;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\Pages\CheckPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbAlgorithm;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Pages\CheckPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbHashAlgorithm;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Pages\CheckPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonCheck;
        
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
            System.Uri resourceLocater = new System.Uri("/MetroMap;component/pages/checkpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\CheckPage.xaml"
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
            this.tbFilePath = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.buttonChoose = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\Pages\CheckPage.xaml"
            this.buttonChoose.Click += new System.Windows.RoutedEventHandler(this.buttonChoose_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.tbSignature = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.tbAlgorithm = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.tbHashAlgorithm = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.buttonCheck = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\Pages\CheckPage.xaml"
            this.buttonCheck.Click += new System.Windows.RoutedEventHandler(this.buttonCheck_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

