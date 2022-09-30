using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using SpectrumSampleApp.Core.Interfaces;
using SpectrumSampleApp.Core.Services;
using SpectrumSampleApp.Core.ViewModels.Home;
using Xamarin.Forms;

namespace SpectrumSampleApp.Core.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly ILoginService _loginService;
        private readonly IMvxNavigationService _navigationService;
        private ICommand _loginCommand;

        public ICommand LoginCommand
        {
            get { return _loginCommand; }
            set
            {
                _loginCommand = value;
                RaisePropertyChanged(() => LoginCommand);
            }
        }


        public LoginViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            _loginService = new LoginService();
            LoginCommand = new MvxAsyncCommand(async () => await Login());
        }
        public override async Task Initialize()
        {

            base.Initialize();


        }

        public async Task Login()
        {
            try
            {
                var user = await _loginService.LoginAsync();
                if (user != null)
                    _navigationService.Navigate<HomeViewModel>();

                _navigationService.Close(this);

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Sorry", "There was an error logging in, please try again", "OK");
            }
        }






    }
}
