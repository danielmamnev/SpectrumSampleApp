using MvvmCross.IoC;
using MvvmCross.ViewModels;
using SpectrumSampleApp.Core.ViewModels;
using SpectrumSampleApp.Core.ViewModels.Home;

namespace SpectrumSampleApp.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterCustomAppStart<AppStart>();
        }
    }
}
