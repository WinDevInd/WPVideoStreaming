using SharedLibrary.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace PortableEssentials.Utils
{
    /// <summary>
    /// Isolated storage and file storage manager
    /// </summary>
    public class StorageManager : IStorageManager
    {
        public async Task<object> GetFileFromApplicationFolder(string path)
        {
            path = "ms-appx:///" + path;
            var file = await Windows.Storage.StorageFile.GetFileFromApplicationUriAsync(
                       new Uri(path, UriKind.RelativeOrAbsolute));
            return file;
        }
    }
}
