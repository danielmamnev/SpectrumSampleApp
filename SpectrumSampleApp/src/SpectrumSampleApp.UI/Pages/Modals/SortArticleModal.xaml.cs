using System;
using System.Collections.Generic;
using SpectrumSampleApp.Core.ViewModels.Home;
using Xamarin.Forms;

namespace SpectrumSampleApp.UI.Pages.Modals
{
    public partial class SortArticleModal : ContentPage
    {
        public SortArticleModal()
        {
            InitializeComponent();
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}
