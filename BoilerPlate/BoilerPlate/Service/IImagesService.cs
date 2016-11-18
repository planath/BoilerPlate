using System.Collections.Generic;
using BoilerPlate.Model;

namespace BoilerPlate.Service
{
    public interface IImagesService
    {
        IList<Picture> GetPictures();
    }
}