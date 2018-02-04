using Android.Content;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;

namespace MvvmNav.Droid
{
    public class Setup : MvxAppCompatSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        protected override void InitializeLastChance()
        {
            base.InitializeLastChance();

            IMvxNavigationCache navigationCache;
            Mvx.TryResolve<IMvxNavigationCache>(out navigationCache);

            IMvxViewModelLoader viewModelLoader;
            Mvx.TryResolve<IMvxViewModelLoader>(out viewModelLoader);

            MvvmNav.Core.Mvvm.MvxNavigationService1.LoadRoutes(GetViewModelAssemblies());

            var navigationService = new MvvmNav.Core.Mvvm.MvxNavigationService1(navigationCache, viewModelLoader);
            Mvx.RegisterSingleton<IMvxNavigationService>(navigationService);
        }
    }
}
