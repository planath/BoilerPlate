using System.Collections.Generic;
using Xamarin.Forms;

namespace BoilerPlate.Helper
{
    public interface IPictureSaver
    {
        void SavePictureToDisk(ImageSource imgSrc, string Id);
        IEnumerable<string> GetPicturesFromDisk(string id);
        void RemoveAllPictures(string id);
    }

}
