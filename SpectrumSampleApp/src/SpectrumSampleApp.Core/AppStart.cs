using System;
using System.Threading.Tasks;
using MvvmCross.Exceptions;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using SpectrumSampleApp.Core.Interfaces;
using SpectrumSampleApp.Core.Services;
using SpectrumSampleApp.Core.ViewModels;
using SpectrumSampleApp.Core.ViewModels.Home;

namespace SpectrumSampleApp.Core
{
    public class AppStart : MvxAppStart
    {
        private readonly ILoginService _loginService;
        private readonly IMvxNavigationService _navigationService;

        public AppStart(IMvxApplication application, IMvxNavigationService navigationService) : base(application, navigationService)
        {
            _loginService = new LoginService();
            _navigationService = navigationService;
        }

        protected override Task NavigateToFirstViewModel(object hint = null)
        {
            try
            {

                var isAuthenticated = _loginService.IsTokenValid();

                if (isAuthenticated)
                {
                    //You need to Navigate sync so the screen is added to the root before continuing.
                    return _navigationService.Navigate<HomeViewModel>();
                }
                else
                {
                    return _navigationService.Navigate<LoginViewModel>();
                }
            }
            catch (System.Exception exception)
            {
                throw exception.MvxWrap("Problem navigating to ViewModel");
            }
        }
    }
}
