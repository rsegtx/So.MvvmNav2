using Android.App;
using Android.OS;

using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmNav.Core.ViewModels;

namespace MvvmNav.Droid.Views
{
    [Activity(Label = "View for RewardDetailView")]
    public class RewardDetailView : MvxAppCompatActivity<RewardDetailViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.RewardDetailView);
        }
    }
}