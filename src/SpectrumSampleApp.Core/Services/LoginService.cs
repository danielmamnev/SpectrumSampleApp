using System;
using System.Threading.Tasks;
using SpectrumSampleApp.Core.Interfaces;
using SpectrumSampleApp.Core.Models;

namespace SpectrumSampleApp.Core.Services
{
    public class LoginService : ILoginService
    {


        //For the sake of a sample app - just check if the last login was less than 2 hours ago
        public bool IsTokenValid()
        {
            if (Convert.ToDateTime(Settings.LastSuccesfulLogin) > DateTime.Now.AddHours(-2))
                return true;
            else
                return false;
        }

        public async Task<User> LoginAsync()
        {
            Settings.LastSuccesfulLogin = DateTime.Now.ToString();
            return new User() { Id = 123, Username = "McUserTheThird" };
        }
        public async Task<User> GetUserAsync()
        {
            return new User() { Id = 123, Username = "McUserTheThird" };

        }
    }
}
