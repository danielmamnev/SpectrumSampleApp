using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using SpectrumSampleApp.Core;
using SpectrumSampleApp.Core.ViewModels.Home;
using SpectrumSampleApp.UI.Pages.Modals;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SpectrumSampleApp.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxContentPagePresentation(WrapInNavigationPage = true)]
    public partial class HomePage : MvxContentPage<HomeViewModel>
    {
        public HomePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (Application.Current.MainPage is NavigationPage navigationPage)
            {
                navigationPage.BarTextColor = Color.White;
                navigationPage.BarBackgroundColor = (Color)Application.Current.Resources["PrimaryColor"];
            }

        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            var page = new SortArticleModal();
            page.BindingContext = this.BindingContext.DataContext;
            await Navigation.PushModalAsync(page);
        }
    }
}
