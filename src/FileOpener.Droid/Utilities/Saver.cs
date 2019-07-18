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
        public void SaveFiles(PlaceEnum where)
        {
            Context myContext = Application.Context;
            AssetManager assets = myContext.Assets;

            var place = myContext.FilesDir.Path;

            if (where == PlaceEnum.OUTSIDE) {
                this.SaveFilesOutside();
            }
            else {
                place = (where == PlaceEnum.FILES ? myContext.FilesDir.Path : myContext.CacheDir.Path);

                var itemsInRoot = assets.List("Examples");

                foreach (var item in itemsInRoot)
                {
                    var path = Path.Combine(place, item);
                    Debug.WriteLine("path to store: " + path);

                    using (var reader = new StreamReader(assets.Open("Examples/" + item)))
                    {
                        using (var memstream = new MemoryStream())
                        {
                            reader.BaseStream.CopyTo(memstream);
                            byte[] bytes = memstream.ToArray();

                            File.WriteAllBytes(path, bytes);
                        }
                    }
                }
            } 
        }


        private void SaveFilesOutside()
        {
            Context myContext = Application.Context;
            AssetManager assets = myContext.Assets;

            var place = Environment.ExternalStorageDirectory.AbsoluteFile + "/Examples";
            var folder = new Java.IO.File(place);
            Files.CreateDirectory(folder.ToPath());

            var itemsInRoot = assets.List("Examples");

            foreach (var item in itemsInRoot)
            {
                var path = Path.Combine(place, item);
                Debug.WriteLine("path to outside: " + path);

                using (var reader = new StreamReader(assets.Open("Examples/" + item)))
                {
                    using (var memstream = new MemoryStream())
                    {
                        reader.BaseStream.CopyTo(memstream);
                        byte[] bytes = memstream.ToArray();

                        File.WriteAllBytes(path, bytes);
                    }
                }
            }
        }
    }
}

