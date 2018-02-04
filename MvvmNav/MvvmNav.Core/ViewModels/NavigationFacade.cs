using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmNav.Core.ViewModels;

[assembly: MvxNavigation(typeof(NavigationFacade), @"http://www.rseg.net/")]
namespace MvvmNav.Core.ViewModels
{
    public class NavigationFacade : IMvxNavigationFacade
    {
        IMvxViewModelLoader _viewModelLoader;
        protected IMvxViewModelLoader ViewModelLoader
        {
            get
            {
                if (_viewModelLoader == null)
                {
                    Mvx.TryResolve<IMvxViewModelLoader>(out _viewModelLoader);
                }

                return _viewModelLoader;
            }
        }

        public Task<MvxViewModelRequest> BuildViewModelRequest(string url, IDictionary<string, string> currentParameters)
        {
            if (url == "http://www.rseg.net/rewards")
            {
                return Task.FromResult(new MvxViewModelRequest(typeof(RewardsViewModel), new MvxBundle(), null));
            }
            else if (url.StartsWith("http://www.rseg.net/rewards/"))
            {
                // logic to create a ViewModelRequest and pass parameters as MvxBundle
                // causing Init() method on ViewModel to be called.

                //var parametersBundle = new MvxBundle();
                //var id = url.Substring(url.LastIndexOf('/') + 1);
                //parametersBundle.Data.Add("id", id);
                //var request = new MvxViewModelRequest(typeof(RewardDetailViewModel), parametersBundle, null);
                //return Task.FromResult(new MvxViewModelRequest(typeof(RewardDetailViewModel), parametersBundle, null));

                // logic to create a ViewModelInstanceRequest and pass parameters object
                // causing Prepare() method on ViewModel to be called. For this to work
                // you must provide a custom NavigationService and change NavigationRouteRequest()
                // to inspect the object returned from this method and if it is a
                // ViewModelInstanceRequest then use it as is rather than creating
                // another one.

                var request = new MvxViewModelInstanceRequest(typeof(RewardDetailViewModel));
                var parameters = new RewardDetailViewModel.Parameteres();
                var idString = url.Substring(url.LastIndexOf('/') + 1);
                int id;
                int.TryParse(idString, out id);
                parameters.RewardId = id;
                request.ViewModelInstance = ViewModelLoader.LoadViewModel(request, parameters, null);

                return Task.FromResult((MvxViewModelRequest)request);
            }
            else
                return Task.FromResult(new MvxViewModelRequest(typeof(FirstViewModel), new MvxBundle(), null));
        }
    }
}
