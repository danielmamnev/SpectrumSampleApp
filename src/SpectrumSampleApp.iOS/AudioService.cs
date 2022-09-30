using System;
using System.IO;
using AVFoundation;
using Foundation;
using SpectrumSampleApp.Core;
using SpectrumSampleApp.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(AudioService))]
namespace SpectrumSampleApp.iOS
{
    public class AudioService : IAudioService
    {
        public AudioService()
        {
        }

        public void PlayAudio(string fileName)
        {
            string sFilePath = NSBundle.MainBundle.PathForResource
            (Path.GetFileNameWithoutExtension(fileName), Path.GetExtension(fileName));
            var url = NSUrl.FromString(sFilePath);
            var _player = AVAudioPlayer.FromUrl(url);
            _player.FinishedPlaying += (object sender, AVStatusEventArgs e) =>
            {
                _player = null;
            };
            _player.Play();
        }
    }
}
