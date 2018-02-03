using System.Threading.Tasks;

using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;

using MvvmNav.Core.ViewModels;

//[assembly: MvxNavigation(typeof(RewardsViewModel), @"http://www.rseg.net/rewardsx/")]
namespace MvvmNav.Core.ViewModels
{
    public class RewardsViewModel : MvxViewModel
    {
        IMvxNavigationService _navigationService;

        public RewardsViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;

            ShowRewardDetailByUrl = new MvxAsyncCommand(ShowRewardDetailByUrlHandler);
            ShowRewardDetail = new MvxAsyncCommand(ShowRewardDetailHandler);
        }

        public IMvxAsyncCommand ShowRewardDetailByUrl { get; protected set; }
        protected async Task ShowRewardDetailByUrlHandler()
        {
            var url = "http://www.rseg.net/rewards/1234";

            if (await _navigationService.CanNavigate(url))
                await _navigationService.Navigate(url);
        }

        public IMvxAsyncCommand ShowRewardDetail { get; protected set; }
        protected async Task ShowRewardDetailHandler()
        {
            await _navigationService.Navigate<RewardDetailViewModel, RewardDetailViewModel.Parameteres>(
                new RewardDetailViewModel.Parameteres() { RewardId = 5678 });
        }
    }
}