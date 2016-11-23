using System.ComponentModel;
using BoilerPlate.iOS;
using BoilerPlate.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(RoundedBoxView), typeof(RoundedBoxRenderer))]
namespace BoilerPlate.iOS
{
    class RoundedBoxRenderer : BoxRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<BoxView> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                SetRadius();
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == RoundedBoxView.CornerRadiusProperty.PropertyName)
            {
                SetRadius();
                SetNeedsDisplay();
            }
        }

        private void SetRadius()
        {
            var radius = (float) ((RoundedBoxView) this.Element).CornerRadius;
            Layer.MasksToBounds = true;
            Layer.CornerRadius = radius;
        }
    }
}
