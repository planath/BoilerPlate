using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoilerPlate.Model
{
    public class Picture
    {
        public Picture(string fileName)
        {
            FileName = fileName;
        }

        public string Description { get; set; }
        public string FileName { get; }
    }
}
