using System;
using System.Threading.Tasks;
using Windows.Storage;

namespace App1
{
    public static class Initializer
    {
        private static bool _initialized;

        public static async Task Initialize()
        {
            //if (_initialized)
            //{
            //    return;
            //}
            //var uri = new Uri("ms-appx:///Assets/Northwind.sqlite");
            //var db = await StorageFile.GetFileFromApplicationUriAsync(uri);
            //var path = await StorageFolder.GetFolderFromPathAsync(ApplicationData.Current.LocalFolder.Path);
            //try
            //{
            //    await db.CopyAsync(path, "Northwind.sqlite", NameCollisionOption.FailIfExists);
            //    _initialized = true;
            //}
            //catch
            //{
            //}
        }
    }
}
