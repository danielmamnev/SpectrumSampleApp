using System;
using System.Threading.Tasks;
using SpectrumSampleApp.Core.Models;

namespace SpectrumSampleApp.Core.Interfaces
{
    public interface ILoginService
    {

        bool IsTokenValid();
        Task<User> LoginAsync();
        Task<User> GetUserAsync();

    }

}
