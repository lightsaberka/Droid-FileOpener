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
                Debug.WriteLine("path: " + path);

                using (StreamReader streamReader = new StreamReader(assets.Open("Examples/" + item)))
                {
                    streamReader.ReadToEnd();

                    using (Stream stream = File.Create(path))
                    {
                        streamReader.BaseStream.CopyTo(stream);
                    }

                }
            }
        }
    }
}

