using System.IO;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Java.Nio.FileNio;
using Debug = System.Diagnostics.Debug;


namespace FileOpener.Droid.Utilities
{
    public class Saver
    {
        public void SaveFile(string file, PlaceEnum where)
        {
            Context myContext = Application.Context;
            AssetManager assets = myContext.Assets;

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

                    var folder = new Java.IO.File(place);
                    if (!folder.Exists()) {
                        Files.CreateDirectory(folder.ToPath());
                    }
                    break;
            }

            var path = Path.Combine(place, file);
            Debug.WriteLine("path to store: " + path);

            using (var streamReader = new StreamReader(assets.Open("Examples/" + file)))
            {
                using (var memoryStream = new MemoryStream())
                {
                    streamReader.BaseStream.CopyTo(memoryStream);
                    byte[] bytes = memoryStream.ToArray();

                    File.WriteAllBytes(path, bytes);
                }
            } 
        }
    }
}

