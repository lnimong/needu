//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Need_U.Layout {
    using System;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    
    
    public partial class MyPublicationsPage : global::Xamarin.Forms.ContentPage {
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.BoxView YellowBoxViewQuestion;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.BoxView YellowBoxViewEvent;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.ListView ListMyPublicationQuestion;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.ListView ListMyPublicationEvent;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.ActivityIndicator theActivityIndicator;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private void InitializeComponent() {
            this.LoadFromXaml(typeof(MyPublicationsPage));
            YellowBoxViewQuestion = this.FindByName<global::Xamarin.Forms.BoxView>("YellowBoxViewQuestion");
            YellowBoxViewEvent = this.FindByName<global::Xamarin.Forms.BoxView>("YellowBoxViewEvent");
            ListMyPublicationQuestion = this.FindByName<global::Xamarin.Forms.ListView>("ListMyPublicationQuestion");
            ListMyPublicationEvent = this.FindByName<global::Xamarin.Forms.ListView>("ListMyPublicationEvent");
            theActivityIndicator = this.FindByName<global::Xamarin.Forms.ActivityIndicator>("theActivityIndicator");
        }
    }
}
