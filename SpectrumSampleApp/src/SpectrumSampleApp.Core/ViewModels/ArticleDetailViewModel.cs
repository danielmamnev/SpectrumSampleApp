using System;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using SpectrumSampleApp.Core.Models;

namespace SpectrumSampleApp.Core.ViewModels
{
    public class ArticleDetailViewModel : MvxViewModel<Article>
    {
        private readonly IMvxNavigationService _navigationService;
        private Article _article;
        public Article Article { get { return _article; } set { _article = value; RaisePropertyChanged(() => Article); } }
        public ArticleDetailViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Prepare(Article article)
        {
            Article = article;
        }
    }
}
