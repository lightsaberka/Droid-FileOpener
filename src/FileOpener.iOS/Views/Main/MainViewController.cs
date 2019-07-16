using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Cirrious.FluentLayouts.Touch;
using Foundation;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using FileOpener.Core.ViewModels.Main;
using UIKit;

namespace FileOpener.iOS.Views.Main
{
    [MvxRootPresentation(WrapInNavigationController = true)]
    public class MainViewController : MvxViewController<MainViewModel>
    {
    }
}
