using System;
using Android.Media;
using SpectrumSampleApp.Core;
using SpectrumSampleApp.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(AudioService))]
namespace SpectrumSampleApp.Droid
{
    public class AudioService : IAudioService
    {
        public AudioService()
        {
        }

        public void PlayAudio(string fileName)
        {
            var player = new MediaPlayer();
            var fd = global::Android.App.Application.Context.Assets.OpenFd(fileName);
            player.Prepared += (s, e) =>
            {
                player.Start();
            };
            player.SetDataSource(fd.FileDescriptor, fd.StartOffset, fd.Length);
            player.Prepare();
        }
    }
}
