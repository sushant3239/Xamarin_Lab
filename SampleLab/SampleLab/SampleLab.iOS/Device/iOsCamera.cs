using System;
using SampleLab.Device;
using System.Threading.Tasks;
using Foundation;
using Xamarin.Forms;
using CoreGraphics;
using UIKit;

[assembly:Dependency(typeof(SampleLab.Device.iOsCamera))]
namespace SampleLab.Device
{
	public class iOsCamera : ICameraLauncher
	{
		private TaskCompletionSource<Object> _tcs;
		UIImagePickerController imagePicker;
		private bool isCameraAvailable;
		UIImage img;
		public iOsCamera ()
		{
			isCameraAvailable = UIImagePickerController.IsSourceTypeAvailable(UIImagePickerControllerSourceType.Camera);
		}

		#region ICameraLauncher implementation

		public Task<Object> StartCapture (string fileNmae, string folderName)
		{
			if (!isCameraAvailable)
			{
				//throw new NotSupportedException();
			}

//			imagePicker = new UIImagePickerController();
//
//			imagePicker.SourceType = UIImagePickerControllerSourceType.Camera;
//			imagePicker.FinishedPickingMedia +=	imagePicker_FinishedPickingMedia;
//			imagePicker.Canceled += imagepicker_Canceled;
//
//			var window = UIApplication.SharedApplication.KeyWindow;
//			if (window == null)
//			{
//				throw new InvalidOperationException("There's no current active window");
//			}
//
//			var viewController = window.RootViewController;
//			//viewController = viewController.PresentedViewController;
//			if (viewController != null) {
//				viewController.PresentViewController(imagePicker, false,null);
//			}

			newCameraImpelentation ();
			_tcs = new TaskCompletionSource<Object>();
			return _tcs.Task;
		}

		public void newCameraImpelentation()
		{

			imagePicker = new UIImagePickerController();
			var window = UIApplication.SharedApplication.KeyWindow;
			if (window == null)
			{
				throw new InvalidOperationException("There's no current active window");
			}
			imagePicker.FinishedPickingImage +=	imagePicker_FinishedPickingImage;
			var viewController = window.RootViewController;
			UIView v= viewController.View;
			//UIView v = new UIView ();
			//v.BackgroundColor = new UIColor (0f, 0f, 0f, 1f);
			imagePicker.SourceType = UIImagePickerControllerSourceType.Camera;
			imagePicker.ShowsCameraControls = false;
			imagePicker.NavigationBarHidden = true;
			imagePicker.AllowsEditing = false;

			//CGAffineTransformScale(
			CGAffineTransform aff = new CGAffineTransform (1f,0f,0f,1f,1f,1f);
			aff.Scale (1f, 1f);
			//aff.TransformPoint (new System.Drawing.PointF (0f, 0f));
		//	aff.Rotate (1.57f);
			//aff.Translate (3f, 0f);
			//aff.Invert ();
			//aff.xx = 0.99f;
			//aff.xy = 0f;
			//aff.yx = 0f;
			//aff.x0 = 1f;
			//aff.y0 = 3f;
			imagePicker.CameraViewTransform = aff;// new  (0.7f,2f,2f,0.7f,0f,1f);


			UIButton b= new UIButton();
			b.UserInteractionEnabled = true;
			b.Enabled = true;
			b.SetTitleColor (UIColor.Blue, UIControlState.Normal);
			b.SetTitle ("Capture", UIControlState.Normal);
			b.TouchUpInside += btnClick;
			b.Frame = new System.Drawing.RectangleF (120, 520, 80, 40);
			b.BackgroundColor = UIColor.Gray;
			//b.AllTouchEvents += btnClick;


			UIView v1 = new UIView ();
			imagePicker.CameraOverlayView = v1;
			v.Add (v1);
			v.Add(b);
			v.BringSubviewToFront (b);

			UIImageView imgv = new UIImageView(new System.Drawing.RectangleF (0, 520, 40, 40));

			//imgv.Image
			//viewController = viewController.PresentedViewController;
			if (viewController != null) {
				//viewController.Add (v);
				viewController.PresentViewController(imagePicker, false,null);
			}
		}

		private void btnClick(object sender, EventArgs e)
		{
			Show ("Clicked");
			//imagePicker.TakePicture ();

		}

		private void imagePicker_FinishedPickingImage(object sender,UIImagePickerImagePickedEventArgs e)
		{
			UIImage capturedImage = e.Image;//.Info[UIImagePickerController.OriginalImage] as UIImage;
			Byte[] myByteArray;

			UIGraphics.BeginImageContextWithOptions (new System.Drawing.SizeF (650, 850), true, 0.2f);
			UIImage scaledImage = UIGraphics.GetImageFromCurrentImageContext();
			UIGraphics.EndImageContext();

			//UIImage img = new UIImage (capturedImage.CGImage, 0.2f, capturedImage.Orientation);

			using (NSData imageData = capturedImage.AsJPEG ()) {
				myByteArray = new byte[imageData.Length];
				System.Runtime.InteropServices.Marshal.Copy (imageData.Bytes, myByteArray, 0, Convert.ToInt32 (imageData.Length));

			}

			imagePicker.DismissViewController (true, null);
			imagePicker.Dispose ();
			_tcs.SetResult (myByteArray);
		}
		UIAlertView al;
		public void Show(string message)
		{
			al = new UIAlertView ();
			al.Message = message;
			al.AddButton ("OK");
			al.Show ();

		}

		private void imagePicker_FinishedPickingMedia(object sender,UIImagePickerMediaPickedEventArgs e)
		{
			UIImage capturedImage = e.Info[UIImagePickerController.OriginalImage] as UIImage;
			Byte[] myByteArray;

			UIGraphics.BeginImageContextWithOptions (new System.Drawing.SizeF (650, 850), true, 0.2f);
			UIImage scaledImage = UIGraphics.GetImageFromCurrentImageContext();
			UIGraphics.EndImageContext();

			//UIImage img = new UIImage (capturedImage.CGImage, 0.2f, capturedImage.Orientation);

			using (NSData imageData = capturedImage.AsJPEG ()) {
				myByteArray = new byte[imageData.Length];
				System.Runtime.InteropServices.Marshal.Copy (imageData.Bytes, myByteArray, 0, Convert.ToInt32 (imageData.Length));

			}

			imagePicker.DismissViewController (true, null);
			imagePicker.Dispose ();
			_tcs.SetResult (myByteArray);
		}

		private void imagepicker_Canceled(object sender, EventArgs e)
		{
			imagePicker.DismissViewController (true, null);
			imagePicker.Dispose ();
			_tcs.SetResult (false);
		}
		#endregion

	}
}

