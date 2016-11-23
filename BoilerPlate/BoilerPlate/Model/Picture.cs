namespace BoilerPlate.Model
{
    public class Picture
    {
        public Picture(string fileName)
        {
            FileName = fileName;
        }

        public string FileName { get; }
        public string Title => FileName + " Title";
        public string Description => "desctiption for " + FileName;
    }
}
