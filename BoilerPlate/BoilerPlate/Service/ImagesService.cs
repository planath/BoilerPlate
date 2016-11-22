using System.Collections.Generic;
using System.Linq;
using BoilerPlate.Model;

namespace BoilerPlate.Service
{
    public class ImagesService: IImagesService
    {
        //IDs represent files on iOS
        private readonly int[] VALID_IDS = {0,1,2,3,4,5,6,7,8,9,10};
        public IList<Picture> GetPictures()
        {
            var names = Enumerable.Repeat("journey", 11).ToList();
            var pictures = Enumerable.Range(0, 11).Select(i => names[i] + i.ToString()).Select(s => new Picture(s)).ToList();
            return pictures;
        }
        public Picture GetPicture(int id)
        {
            if (!VALID_IDS.Contains(id)) return null;

            return new Picture("journey" + id);
        }
    }
}
