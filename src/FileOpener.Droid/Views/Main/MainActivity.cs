using Android.App;
using Android.OS;
using Android.Views;
using MvvmCross.Droid.Support.V7.AppCompat;
using FileOpener.Core.ViewModels.Main;
using FileOpener.Droid.Utilities;


namespace FileOpener.Droid.Views.Main
{
    [Activity(
        Theme = "@style/AppTheme",
        WindowSoftInputMode = SoftInput.AdjustResize | SoftInput.StateHidden)]
    public class MainActivity : MvxAppCompatActivity<MainViewModel>
    {
        private Opener _opener = new Opener();
        private Saver _saver = new Saver();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            this.SetContentView(Resource.Layout.activity_main_container);

            this._saver.SaveFiles();
        }


        public void OpenHello(View view)
        {
            this._opener.OpenFile("hello.txt");
        }

        public void OpenReddit(View view)
        {
            this._opener.OpenFile("reddit.png");
        }

        public void OpenRocket(View view)
        {
            this._opener.OpenFile("rocket.pdf");
        }

        public void OpenTrex(View view)
        {
            this._opener.OpenFile("trex.jpg");
        }
    }
}
