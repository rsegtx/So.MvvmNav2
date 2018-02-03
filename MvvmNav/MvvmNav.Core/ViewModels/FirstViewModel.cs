using System.Threading.Tasks;

using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;

namespace MvvmNav.Core.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        IMvxNavigationService _navigationService;

        public FirstViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;

            ShowRewardsByUrl = new MvxAsyncCommand(ShowRewardsByUrlHandler);
            ShowRewards = new MvxAsyncCommand(ShowRewardsHandler);
            ShowRewardDetailByUrl = new MvxAsyncCommand(ShowRewardDetailByUrlHandler);
            ShowRewardDetail = new MvxAsyncCommand(ShowRewardDetailHandler);
        }

        public IMvxAsyncCommand ShowRewardsByUrl { get; protected set; }
        protected async Task ShowRewardsByUrlHandler()
        {
            var url = "http://www.rseg.net/rewards";

            if (await _navigationService.CanNavigate(url))
                await _navigationService.Navigate(url);
        }

        public IMvxAsyncCommand ShowRewards { get; protected set; }
        protected async Task ShowRewardsHandler()
        {
            await _navigationService.Navigate<RewardsViewModel>();
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