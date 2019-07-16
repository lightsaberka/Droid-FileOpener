using Android.App;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace FileOpener.Droid.Views.Splash
{
    [Activity(
        NoHistory = true,
        MainLauncher = true,
        Label = "@string/app_name",
        Theme = "@style/AppTheme.Splash")]
    public class SplashActivity : MvxSplashScreenAppCompatActivity
    {
    }
}
