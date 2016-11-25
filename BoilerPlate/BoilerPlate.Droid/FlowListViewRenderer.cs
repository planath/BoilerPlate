
using Android.Graphics.Drawables;
using BoilerPlate.Droid;
using DLToolkit.Forms.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(FlowListView), typeof(FlowListViewRenderer))]
namespace BoilerPlate.Droid
{
    public class FlowListViewRenderer : ListViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
        {
            base.OnElementChanged(e);

            var tableView = Control;
            tableView.TranscriptMode = 0;
        }
    }
}