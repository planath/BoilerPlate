using System.Collections.Generic;
using System.Linq;
using BoilerPlate.Model;

namespace BoilerPlate.Service
{
    public class ImagesService: IImagesService
    {
        public IList<Picture> GetPictures()
        {
            var names = Enumerable.Repeat("journey", 11).ToList();
            var pictures = Enumerable.Range(0, 11).Select(i => names[i] + i.ToString()).Select(s => new Picture(s)).ToList();
            return pictures;
        }
    }
}
