//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SampleLab.CustomControls {
    using System;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    
    
    public partial class SelectableView : Grid {
        
        private Grid RootGrid;
        
        private Label ViewLabel;
        
        private void InitializeComponent() {
            this.LoadFromXaml(typeof(SelectableView));
            RootGrid = this.FindByName<Grid>("RootGrid");
            ViewLabel = this.FindByName<Label>("ViewLabel");
        }
    }
}
