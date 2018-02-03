using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;

using MvvmNav.Core.ViewModels;

[assembly: MvxNavigation(typeof(NavigationFacade), @"http://www.rseg.net/")]
namespace MvvmNav.Core.ViewModels
{
    public class NavigationFacade : IMvxNavigationFacade
    {
        public Task<MvxViewModelRequest> BuildViewModelRequest(string url, IDictionary<string, string> currentParameters)
        {
            if (url == "http://www.rseg.net/rewards")
            {
                return Task.FromResult(new MvxViewModelRequest(typeof(RewardsViewModel), new MvxBundle(), null));
            }
            else if (url.StartsWith("http://www.rseg.net/rewards/"))
            {
                var parametersBundle = new MvxBundle();
                var id = url.Substring(url.LastIndexOf('/') + 1);
                parametersBundle.Data.Add("id", id);
                return Task.FromResult(new MvxViewModelRequest(typeof(RewardDetailViewModel), parametersBundle, null));
            }
            else
                return Task.FromResult(new MvxViewModelRequest(typeof(FirstViewModel), new MvxBundle(), null));
        }
    }
}
