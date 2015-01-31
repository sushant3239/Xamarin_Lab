
using System;
using AudioToolbox;
using AVFoundation;
using Foundation;
using UIKit;

namespace SampleLab.PhoneService
{
	public class iOSMediaPlayer : IMediaPlayer
    {
		AVPlayer _player;
		NSUrl audioFilePath ;
		string fileName = string.Format ("Myfile{0}.aac", "Xamarin");
		string tempRecording;
		public iOSMediaPlayer ()
		{
			AudioSession.Initialize ();
			tempRecording = NSBundle.MainBundle.BundlePath + "/../tmp/" + fileName;
			this.audioFilePath = NSUrl.FromFilename(tempRecording);
		}
		#region IMediaPlayer implementation
		public void Play (string filePath)
		{
			try {
				ShowMessage(tempRecording);
				//Console.WriteLine("Playing Back Recording " + this.audioFilePath.ToString());
				AudioSession.Category = AudioSessionCategory.MediaPlayback;
				this._player = new AVPlayer (this.audioFilePath);
				this._player.Play();
			} catch (Exception ex) {
				Console.WriteLine("There was a problem playing back audio: ");
				Console.WriteLine(ex.Message);

			}
		}
		public void Pause ()
		{
			throw new NotImplementedException ();
		}
		public void Stop ()
		{
			throw new NotImplementedException ();
		}
		public void ReleaseMediaPlayer ()
		{
			throw new NotImplementedException ();
		}
		public int Position {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}
		public double TotalPlayBackInSeconds {
			get {
				throw new NotImplementedException ();
			}
		}
		#endregion
		public void ShowMessage(String message)
		{

			UIAlertView al = new UIAlertView ();
			al.Message = message;
			al.AddButton ("OK");
			al.Show ();
		}


        public System.Threading.Tasks.Task<bool> PlayAsync(string filePath)
        {
            throw new NotImplementedException();
        }

        public event EventHandler OnMediaStopped;
    }
}