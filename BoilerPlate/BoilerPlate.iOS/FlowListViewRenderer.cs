using BoilerPlate.iOS;
using DLToolkit.Forms.Controls;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(FlowListView), typeof(FlowListViewRenderer))]
namespace BoilerPlate.iOS
{
    public class FlowListViewRenderer : ListViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
        {
            base.OnElementChanged(e);

            var tableView = Control as UITableView;
            tableView.ScrollEnabled = false;
        }
    }
}