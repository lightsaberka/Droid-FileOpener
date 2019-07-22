using System.Collections.Generic;
using Android.Content;
using Android.Content.PM;
using Android.Net;
using Android.OS;
using Android.Support.V4.Content;
using HeyRed.Mime;
using Java.IO;
using Java.Lang;
using Debug = System.Diagnostics.Debug;


namespace FileOpener.Droid.Utilities
{
    public class Opener
    {
        public void OpenFile(string myFile, PlaceEnum where)
        {
            Context myContext = Android.App.Application.Context;

            var place = myContext.FilesDir.Path;

            switch (where)
            {
                case PlaceEnum.FILES:
                    place = myContext.FilesDir.Path;
                    break;

                case PlaceEnum.CACHE:
                    place = myContext.CacheDir.Path;
                    break;

                case PlaceEnum.OUTSIDE:
                    place = Environment.ExternalStorageDirectory.AbsoluteFile + "/Examples";
                    break;
            }

            var file = new File(place, myFile);
            Debug.WriteLine("path to file: " + place);

            Uri path = FileProvider.GetUriForFile(myContext, myContext.PackageName + ".fileprovider", file);
            Debug.WriteLine("path to read: " + path);

            var intent = new Intent(Intent.ActionView);
            intent.AddFlags(ActivityFlags.GrantReadUriPermission);

            // grant read permission to all apps available to open our file
            IList<ResolveInfo> resolveList = myContext.PackageManager.QueryIntentActivities(intent, PackageInfoFlags.MatchDefaultOnly);
            foreach (ResolveInfo resolveInfo in resolveList)
            {
                var packageName = resolveInfo.ActivityInfo.PackageName;
                myContext.GrantUriPermission(packageName, path, ActivityFlags.GrantReadUriPermission);
            }

            intent.SetDataAndType(path, MimeTypesMap.GetMimeType(myFile));
            intent.AddFlags(ActivityFlags.NoHistory);
            intent.AddFlags(ActivityFlags.ClearWhenTaskReset | ActivityFlags.NewTask);

            try
            {
                myContext.StartActivity(intent);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error: " + e);
            }
        }
    }
}
