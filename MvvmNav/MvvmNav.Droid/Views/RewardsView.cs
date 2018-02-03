using Android.App;
using Android.OS;

using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmNav.Core.ViewModels;

namespace MvvmNav.Droid.Views
{
    [Activity(Label = "View for RewardsViewModel")]
    public class RewardsView : MvxAppCompatActivity<RewardsViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.RewardsView);
        }
    }
}