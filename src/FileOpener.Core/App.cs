using MvvmCross.ViewModels;
using FileOpener.Core.ViewModels.Main;

namespace FileOpener.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            this.RegisterAppStart<MainViewModel>();
        }
    }
}
