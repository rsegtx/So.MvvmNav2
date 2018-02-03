using System.Threading.Tasks;

using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;

using MvvmNav.Core.ViewModels;

//[assembly: MvxNavigation(typeof(RewardDetailViewModel), @"http://www.rseg.net/rewards/(?<id>[0-9]{4})$")]
namespace MvvmNav.Core.ViewModels
{
    public class RewardDetailViewModel : MvxViewModel<RewardDetailViewModel.Parameteres>
    {
        public class Parameteres
        {
            public int RewardId { get; set; }
        }

        IMvxNavigationService _navigationService;
        int _rewardId;

        public string RewardIdCaption
        {
            get { return $"Reward Id = {_rewardId}"; }
        }

        public RewardDetailViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public new void Init(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                if (int.TryParse(id, out _rewardId))
                    RaiseAllPropertiesChanged();
            }
        }

        public override void Prepare(Parameteres parameter)
        {
            if (parameter != null)
            {
                _rewardId = parameter.RewardId;
                RaiseAllPropertiesChanged();
            }
        }
    }
}