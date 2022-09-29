using System;
using System.ComponentModel;
using SpectrumSampleApp.Core.CustomControls;
using SpectrumSampleApp.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;



[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickerRendererIOS))]
namespace SpectrumSampleApp.iOS
{

    public class CustomPickerRendererIOS : PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            Control.BorderStyle = UIKit.UITextBorderStyle.None;
            Control.BackgroundColor = Color.White.ToUIColor();
            Control.TextColor = Color.FromHex("001b33").ToUIColor();

        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {

            base.OnElementPropertyChanged(sender, e);
            var picker = sender as Xamarin.Forms.Picker;
            if (picker.IsFocused)
            {
                Control.BackgroundColor = Color.FromHex("001b33").ToUIColor();
                Control.TextColor = Color.White.ToUIColor();
            }
            else
            {

                Control.BackgroundColor = Color.White.ToUIColor();
                Control.TextColor = Color.Black.ToUIColor();

            }

        }



    }
}

