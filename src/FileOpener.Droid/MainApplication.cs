using System;
using Android.Runtime;
using MvvmCross.Droid.Support.V7.AppCompat;
using FileOpener.Core;

namespace FileOpener.Droid
{

    public class MainApplication : MvxAppCompatApplication<Setup, App>
    {
        public MainApplication(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }
    }
}
