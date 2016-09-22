using System;
using CoreGraphics;
using UIKit;

namespace TipCalculator
{
	public class myViewController: UIViewController
	{
		UIImageView backgroundImage;

		public myViewController()
		{
		}

		// Garbige collector
		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);

			if (disposing)
			{
				backgroundImage.Dispose();
				backgroundImage = null;
			}
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();

			// clean up amy unneeded resources
		}

		private void Initializate()
		{
			nfloat height = View.Bounds.Height;
			nfloat width = View.Bounds.Width;

			var subview = new UIView()
			{
				Frame = new CGRect(width / 2 - 20, height / 2 - 20, 40, 40)
			};

			this.View.BackgroundColor = UIColor.Yellow;
			this.View.AddSubview(subview);

			UITextField totalAmount = new UITextField(new CGRect(20, 28, width - 40, 35))
			{
				KeyboardType = UIKeyboardType.DecimalPad,
				BorderStyle = UITextBorderStyle.RoundedRect,
				Placeholder = "Enter Total Amount"
			};

			UIButton calcButton = new UIButton(UIButtonType.Custom)
			{
				Frame = new CGRect(20, 71, width - 40, 45),
				BackgroundColor = UIColor.FromRGB(0, 0.5f, 0)
			};

			calcButton.SetTitle("Calculate", UIControlState.Normal);

			UILabel resultLabel = new UILabel(new CGRect(10, 124, width, 40))
			{
				TextAlignment = UITextAlignment.Center,
				Font = UIFont.SystemFontOfSize(24),
				TextColor = UIColor.Blue,
				Text = "Tip is $0.00",
			};

			this.View.AddSubviews(new UIView[] { totalAmount, calcButton, resultLabel});

			calcButton.TouchUpInside += (object sender, EventArgs e) =>
			{
				double value = 0;
				Double.TryParse(totalAmount.Text, out value);
				resultLabel.Text = string.Format("Tip is {0:C}", value * 0.2);

				calcButton.ResignFirstResponder();
			};

		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			Initializate();
		}

		private void RemoveAllContent()
		{
			foreach (UIView subview in View)
			{
				subview.RemoveFromSuperview();
			}
		}

	}
}
