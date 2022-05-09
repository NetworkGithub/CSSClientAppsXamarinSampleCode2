using Android.App;
using Android.Content;
using Android.Gms.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CameraX
{
    internal class ImageTextProcessedSuccess : Java.Lang.Object, IOnSuccessListener
    {
        public void OnSuccess(Java.Lang.Object result)
        {
            var textObject = (Xamarin.Google.MLKit.Vision.Text.Text)result;
            var t = textObject;
        }
    }
}