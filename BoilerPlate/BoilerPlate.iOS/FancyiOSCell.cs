using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Foundation;
using UIKit;

namespace BoilerPlate.iOS
{
    class FancyiOSCell : UITableViewCell
    {
        UILabel headingLabel, subheadingLabel;
        UIImageView imageView, thumbnailImageView;

        public FancyiOSCell(NSString cellId) : base(UITableViewCellStyle.Default, cellId)
        {
            SelectionStyle = UITableViewCellSelectionStyle.Gray;
            
            imageView = new UIImageView() { Bounds = ContentView.Bounds };
            thumbnailImageView = new UIImageView();
            thumbnailImageView.Layer.MasksToBounds = true;
            thumbnailImageView.Layer.CornerRadius = 50;

            var blurEffect = UIBlurEffect.FromStyle(UIBlurEffectStyle.ExtraLight);
            var vibrancyEffect = UIVibrancyEffect.FromBlurEffect(blurEffect);
            var blurView = new UIVisualEffectView(blurEffect);
            var vibrancyView = new UIVisualEffectView(vibrancyEffect);

            headingLabel = new UILabel()
            {
                Font = UIFont.PreferredTitle1,
                TextAlignment = UITextAlignment.Center,
                BackgroundColor = UIColor.Clear
            };

            subheadingLabel = new UILabel()
            {
                Font = UIFont.PreferredSubheadline,
                TextAlignment = UITextAlignment.Center,
                BackgroundColor = UIColor.Clear
            };

            // creat blur view
            vibrancyView.ContentView.Add(headingLabel);
            vibrancyView.ContentView.Add(subheadingLabel);
            vibrancyView.ContentView.Add(thumbnailImageView);
            subheadingLabel.TranslatesAutoresizingMaskIntoConstraints = false;
            headingLabel.TranslatesAutoresizingMaskIntoConstraints = false;
            thumbnailImageView.TranslatesAutoresizingMaskIntoConstraints = false;

            var labelViews = NSDictionary.FromObjectsAndKeys(new NSObject[] { subheadingLabel, headingLabel, vibrancyView, thumbnailImageView }, new NSObject[] { new NSString("subtitle"), new NSString("title"), new NSString("vibrancy"), new NSString("thumbnail") });
            vibrancyView.AddConstraints(NSLayoutConstraint.FromVisualFormat("V:|-[title]-2-[subtitle]-|", 0, new NSDictionary(), labelViews));
            vibrancyView.AddConstraints(NSLayoutConstraint.FromVisualFormat("V:|-[thumbnail]-|", 0, new NSDictionary(), labelViews));
            vibrancyView.AddConstraints(NSLayoutConstraint.FromVisualFormat("V:|-[thumbnail(100)]-|", 0, new NSDictionary(), labelViews));
            vibrancyView.AddConstraints(NSLayoutConstraint.FromVisualFormat("H:|-[title(>=50)]-[thumbnail(100)]-|", 0, new NSDictionary(), labelViews));
            vibrancyView.AddConstraints(NSLayoutConstraint.FromVisualFormat("H:|-[subtitle(>=50)]-[thumbnail(100)]-|", 0, new NSDictionary(), labelViews));

            blurView.ContentView.Add(vibrancyView);
            vibrancyView.TranslatesAutoresizingMaskIntoConstraints = false;
            blurView.AddConstraints(NSLayoutConstraint.FromVisualFormat("H:|-0-[vibrancy]-0-|", 0, new NSDictionary(), labelViews));
            blurView.AddConstraints(NSLayoutConstraint.FromVisualFormat("V:|-0-[vibrancy]-0-|", 0, new NSDictionary(), labelViews));

            // create ContentView
            ContentView.Add(imageView);
            ContentView.Add(blurView); 

            imageView.TranslatesAutoresizingMaskIntoConstraints = false;
            blurView.TranslatesAutoresizingMaskIntoConstraints = false;

            var viewsDictionary = NSDictionary.FromObjectsAndKeys(new NSObject[] {imageView, blurView }, new NSObject[] { new NSString("image"), new NSString("blur") });
            ContentView.AddConstraints(NSLayoutConstraint.FromVisualFormat("H:|-0-[image]-0-|", 0, new NSDictionary(), viewsDictionary));
            ContentView.AddConstraints(NSLayoutConstraint.FromVisualFormat("V:|-0-[image]-0-|", 0, new NSDictionary(), viewsDictionary));
            ContentView.AddConstraints(NSLayoutConstraint.FromVisualFormat("H:|-0-[blur]-0-|", 0, new NSDictionary(), viewsDictionary));
            ContentView.AddConstraints(NSLayoutConstraint.FromVisualFormat("V:|-0-[blur]-0-|", 0, new NSDictionary(), viewsDictionary));

        }

        public void UpdateCell(string caption, string subtitle, UIImage image)
        {
            headingLabel.Text = caption;
            subheadingLabel.Text = subtitle;
            imageView.Image = image;
            thumbnailImageView.Image = image;
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
        }
    }
}