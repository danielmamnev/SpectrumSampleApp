using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using SpectrumSampleApp.Core.Interfaces;
using SpectrumSampleApp.Core.Models;
using SpectrumSampleApp.Core.Services;
using System.Linq;
using Xamarin.Forms;

namespace SpectrumSampleApp.Core.ViewModels.Home
{
    public class HomeViewModel : MvxViewModel
    {
        private readonly ILoginService _loginService;
        private readonly IMvxNavigationService _navigationService;
        private readonly IDataService _dataService;
        private string _selectedCategory;
        private SortObject _selectedSort;
        private string _searchText;

        private List<Article> _articles;
        private Article _articleSelected;
        public User user { get; set; }
        public string WelcomeText { get; set; }
        private ICommand _modalClosedCommand;

        public ICommand ModalClosedCommand
        {
            get { return _modalClosedCommand; }
            set
            {
                _modalClosedCommand = value;
                RaisePropertyChanged(() => ModalClosedCommand);
            }
        }

        public bool ShowList { get { return Articles.Any(); } }
        public List<Article> Articles
        {
            get { return _articles; }
            set { _articles = value; RaiseAllPropertiesChanged(); }
        }
        public List<string> Categories => new List<string> { "All", "General", "Business", "Entertainment", "Health", "Science", "Sports", "Technology" };
        public string SelectedCategory
        {
            get { return _selectedCategory; }
            set { _selectedCategory = value; RaisePropertyChanged(() => SelectedCategory); }
        }

        public List<SortObject> SortByList => new List<SortObject>() {
             new SortObject()
            {
                Name = "Default",
                Value = "default",
            },
            new SortObject()
            {
                Name = "Date (Newest)",
                Value = "date",
            },
            new SortObject(){
                Name = "Source (Alphabetical)",
                Value = "source",
            },

        };

        public SortObject SelectedSort
        {
            get { return _selectedSort; }
            set { _selectedSort = value; RaisePropertyChanged(() => SelectedSort); }
        }

        public string SearchText
        {
            get { return _searchText; }
            set { _searchText = value; RaisePropertyChanged(() => SearchText); }
        }

        public Article ArticleSelected
        {
            get => _articleSelected;
            set
            {
                _articleSelected = value;
                RaisePropertyChanged(() => ArticleSelected);
                GoToArticleDetailsPage(value);
            }
        }


        public HomeViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            _loginService = new LoginService();
            _dataService = new DataService();
            Articles = new List<Article>();
            ModalClosedCommand = new MvxCommand(() => GetAllNews());

        }

        private async void GoToArticleDetailsPage(Article article)
        {
            if (article != null)
            {
                _navigationService.Navigate<ArticleDetailViewModel, Article>(article);

            }
            else
            {
                await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Sorry", "There was an issue getting this article", "Go Back");
            }


        }

        public override void Prepare()
        {
            // first callback. Initialize parameter-agnostic stuff here
        }
        public override async Task Initialize()
        {

            base.Initialize();
            user = await _loginService.GetUserAsync();
            WelcomeText = $"Welcome, {user.Username}!";
            GetAllNews();

        }

        public async Task GetAllNews()
        {
            StringBuilder sb = new StringBuilder();
            if (SelectedCategory != null)
                if (SelectedCategory != "All")
                    sb.Append($"&categories={SelectedCategory.ToLower()}");
            if (SearchText != null)
                sb.Append($"&keywords={SearchText}");


            ArticleCollection news = await _dataService.GetAllNews(sb.ToString());
            if (SelectedSort != null)
            {
                switch (SelectedSort.Value)
                {
                    case "date":
                        Articles = news.data.OrderBy(x => x.published_at).ToList();
                        break;
                    case "source":
                        Articles = news.data.OrderBy(x => x.source).ToList();
                        break;
                    default:
                        Articles = news.data;
                        break;



                }
            }
            else
                Articles = news.data;

            //play on login and refresh
            DependencyService.Get<IAudioService>().PlayAudio("LoginChime.mp3");

        }


    }

}
