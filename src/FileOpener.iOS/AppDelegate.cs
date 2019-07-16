using Foundation;
using MvvmCross.Platforms.Ios.Core;
using FileOpener.Core;

namespace FileOpener.iOS
{
    [Register(nameof(AppDelegate))]
    public class AppDelegate : MvxApplicationDelegate<Setup, App>
    {
    }
}
