using System;
using AVFoundation;
using Foundation;
using AudioToolbox;
using Xamarin.Forms;
using UIKit;

[assembly:Dependency(typeof(SampleLab.Device.iOSAudioRecorder))]
namespace SampleLab.Device
{
	public class iOSAudioRecorder :IAudioRecorder
	{
		AVPlayer _player;
		AVAudioRecorder recorder;
		NSDictionary settings;
		string tempRecording;
		NSUrl audioFilePath;
		string fileName = string.Format ("Myfile{0}.aac", "Xamarin");


		public iOSAudioRecorder ()
		{
			AudioSession.Initialize ();
			tempRecording = NSBundle.MainBundle.BundlePath + "/../tmp/" + fileName;
			this.audioFilePath = NSUrl.FromFilename(tempRecording);
		}

		#region IAudioRecorder implementation

		public void StartRecording (string filePath)
		{

			//PrepareAudioRecording ();
			//recorder.Record ();
			try
			{
				Console.WriteLine("Begin Recording");

				AudioSession.Category = AudioSessionCategory.RecordAudio;
				AudioSession.SetActive (true);

				if (!PrepareAudioRecording ()) {
					Console.WriteLine("Error preparing");
					//RecordingStatusLabel.Text = "Error preparing";
					return;
				}

				if (!recorder.Record ()) {

					Console.WriteLine("Error Preparing");
					//RecordingStatusLabel.Text = "Error preparing";
					return;
				}
			}
			catch (Exception ex) {
				Console.WriteLine ("Error : - " + ex.ToString());
				ShowMessage (ex.Message);
			}

		}

		public void StopRecording ()
		{
			recorder.Stop ();

		}

		public void DisposeUsedResources ()
		{
			try {

				//Console.WriteLine("Playing Back Recording " + this.audioFilePath.ToString());
				AudioSession.Category = AudioSessionCategory.MediaPlayback;
				this._player = new AVPlayer (this.audioFilePath);
				this._player.Play();
			} catch (Exception ex) {
				Console.WriteLine("There was a problem playing back audio: ");
				Console.WriteLine(ex.Message);

			}
		}

		bool PrepareAudioRecording ()
		{
			//Declare string for application temp path and tack on the file extension
			//	string fileName = string.Format ("Myfile{0}.aac", DateTime.Now.ToString ("yyyyMMddHHmmss"));


			//set up the NSObject Array of values that will be combined with the keys to make the NSDictionary
			NSObject[] values = new NSObject[]
			{    
				NSNumber.FromFloat(44100.0f),
				NSNumber.FromInt32((int)AudioToolbox.AudioFormatType.MPEG4AAC),
				NSNumber.FromInt32(1),
				NSNumber.FromInt32((int)AVAudioQuality.High)
			};
			//Set up the NSObject Array of keys that will be combined with the values to make the NSDictionary
			NSObject[] keys = new NSObject[]
			{
				AVAudioSettings.AVSampleRateKey,
				AVAudioSettings.AVFormatIDKey,
				AVAudioSettings.AVNumberOfChannelsKey,
				AVAudioSettings.AVEncoderAudioQualityKey
			};			
			//Set Settings with the Values and Keys to create the NSDictionary
			settings = NSDictionary.FromObjectsAndKeys (values, keys);

			//Set recorder parameters
			NSError error = null;
			//recorder = AVAudioRecorder.(this.audioFilePath, settings, out error);
			if ((recorder == null) || (error != null)) {
				Console.WriteLine (error);
				ShowMessage("No Recorded");
				return false;
			}

			//Set Recorder to Prepare To Record
			if (!recorder.PrepareToRecord ()) {
				recorder.Dispose ();
				recorder = null;
				return false;
				ShowMessage("No Recorded");
			}

			recorder.FinishedRecording += delegate (object sender, AVStatusEventArgs e) {
				recorder.Dispose ();
				recorder = null;
				Console.WriteLine ("Done Recording (status: {0})", e.Status);
				ShowMessage("Recorded");
			};

			return true;
		}

		public void ShowMessage(String message)
		{

			UIAlertView al = new UIAlertView ();
			al.Message = message;
			al.AddButton ("OK");
			al.Show ();
		}

		#endregion
	}
}


