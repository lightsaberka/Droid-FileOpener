using System.Diagnostics;
using System.IO;
using Android.App;
using Android.Content;
using Android.Content.Res;
using File = System.IO.File;


namespace FileOpener.Droid.Utilities
{
    public class Saver
    {
        public void SaveFiles()
        {
            Context myContext = Application.Context;
            AssetManager assets = myContext.Assets;

            var itemsInRoot = assets.List("Examples");

            foreach (var item in itemsInRoot)
            {
                var path = Path.Combine(myContext.FilesDir.Path, item);
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
}

