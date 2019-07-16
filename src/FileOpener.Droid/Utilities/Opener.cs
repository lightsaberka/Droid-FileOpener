using System.Collections.Generic;
using Android.Content;
using Android.Content.PM;
using Android.Net;
using Android.Support.V4.Content;
using Android.Widget;
using HeyRed.Mime;
using Java.IO;
using Java.Lang;


namespace FileOpener.Droid.Utilities
{
    public class Opener
    {
        public void OpenFile(string myFile)
        {
            var intent = new Intent(Intent.ActionEdit);
            Context myContext = Android.App.Application.Context;
            var file = new File(myFile);

            Uri path = FileProvider.GetUriForFile(myContext, myContext.PackageName + ".fileprovider", file);

            intent.SetDataAndType(path, MimeTypesMap.GetMimeType(myFile));

            intent.AddFlags(ActivityFlags.GrantReadUriPermission | ActivityFlags.GrantWriteUriPermission);
            intent.AddFlags(ActivityFlags.NoHistory);
            intent.AddFlags(ActivityFlags.ClearWhenTaskReset | ActivityFlags.NewTask);

            IList<ResolveInfo> resolveList = myContext.PackageManager.QueryIntentActivities(intent, PackageInfoFlags.MatchDefaultOnly);

            foreach (ResolveInfo resolveInfo in resolveList)
            {
                var packageName = resolveInfo.ActivityInfo.PackageName;
                myContext.GrantUriPermission(packageName, path, ActivityFlags.GrantReadUriPermission | ActivityFlags.GrantWriteUriPermission);
            }

            try
            {
                myContext.StartActivity(intent);
            }
            catch (Exception e)
            {
                Toast.MakeText(myContext, "Error: " + e, ToastLength.Long);
            }
        }
    }
}
