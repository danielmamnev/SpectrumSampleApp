using System;
using System.ComponentModel;
using Android.Content;
using SpectrumSampleApp.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

[assembly: ExportRenderer(typeof(Picker), typeof(CustomPickerRendererDroid))]
namespace SpectrumSampleApp.Droid
{
    public class CustomPickerRendererDroid : PickerRenderer
    {
        public CustomPickerRendererDroid(Context context) : base(context)
        {

        }



        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            var picker = sender as Xamarin.Forms.Picker;
            if (picker.IsFocused)
            {
                Control.SetBackgroundColor(Android.Graphics.Color.Rgb(0, 27, 51));
            }
            else
            {
                Control.SetBackgroundColor(Android.Graphics.Color.White);

            }

        }
    }
}
