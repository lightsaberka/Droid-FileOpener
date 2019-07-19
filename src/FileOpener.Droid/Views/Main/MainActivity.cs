using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
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
        private readonly Opener _opener = new Opener();
        private readonly Saver _saver = new Saver();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            this._saver.SaveFiles(PlaceEnum.FILES);
            this._saver.SaveFiles(PlaceEnum.CACHE);
            this._saver.SaveFiles(PlaceEnum.OUTSIDE);

            this.SetContentView(Resource.Layout.activity_main_container);

            var helloButton = (Button) this.FindViewById(Resource.Id.button_hello);
            var redditButton = (Button) this.FindViewById(Resource.Id.button_reddit);
            var rocketButton = (Button) this.FindViewById(Resource.Id.button_rocket);
            var trexButton = (Button) this.FindViewById(Resource.Id.button_trex);

            helloButton.Click += (sender, e) => { this._opener.OpenFile("hello.txt", PlaceEnum.CACHE); };
            redditButton.Click += (sender, e) => { this._opener.OpenFile("reddit.png", PlaceEnum.FILES); };
            rocketButton.Click += (sender, e) => { this._opener.OpenFile("rocket.pdf", PlaceEnum.CACHE); };
            trexButton.Click += (sender, e) => { this._opener.OpenFile("trex.jpg", PlaceEnum.FILES); };

        }
    }
}
