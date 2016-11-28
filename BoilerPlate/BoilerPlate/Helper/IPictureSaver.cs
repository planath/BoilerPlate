using Xamarin.Forms;

namespace BoilerPlate.Helper
{
    public interface IPictureSaver
    {
        void SavePictureToDisk(ImageSource imgSrc, string Id);
        string GetPictureFromDisk(string id);
    }

}
