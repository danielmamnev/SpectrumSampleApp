using System;
using System.Collections.Generic;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using SpectrumSampleApp.Core.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SpectrumSampleApp.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxContentPagePresentation(WrapInNavigationPage = true)]
    public partial class ArticleDetailPage : MvxContentPage<ArticleDetailViewModel>
    {
        public ArticleDetailPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            webView.Navigating += (sender, e) =>
            {
                loadingLabel.IsVisible = false;
            };

        }
        public void WebViewLoading(EventHandler<WebNavigationEventArgs> eventHandler)
        {

            webView.BackgroundColor = Color.Blue;
        }
    }
}
