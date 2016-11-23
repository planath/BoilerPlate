using System;
using BoilerPlate.iOS;
using BoilerPlate.Views.Cell;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(FancyCell), typeof(FancyiOSCellRenderer))]
namespace BoilerPlate.iOS
{
    class FancyiOSCellRenderer : ViewCellRenderer
    {
        static NSString rid = new NSString("NativeCell");

        public override UITableViewCell GetCell(Xamarin.Forms.Cell item, UITableViewCell reusableCell, UITableView tv)
        {
            var XFFancyCell = (FancyCell)item;
            Console.WriteLine(XFFancyCell);

            FancyiOSCell IOSFancyCell = reusableCell as FancyiOSCell;

            if (IOSFancyCell == null)
            {
                IOSFancyCell = new FancyiOSCell(rid);
            }

            UIImage i = null;
            if (!String.IsNullOrWhiteSpace(XFFancyCell.ImageFilename))
            {
                i = UIImage.FromFile(XFFancyCell.ImageFilename + ".png");
            }
            IOSFancyCell.UpdateCell(XFFancyCell.Title, XFFancyCell.SubTitle, i);
            
            return IOSFancyCell;
        }
    }
}
