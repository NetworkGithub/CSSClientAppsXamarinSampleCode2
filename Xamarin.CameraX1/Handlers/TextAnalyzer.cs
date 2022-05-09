using Android.Gms.Tasks;
using Android.Gms.Vision.Texts;
using AndroidX.Camera.Core;
using Java.Nio;
using System;
using Xamarin.Google.MLKit.Vision.Text;
using Xamarin.Google.MLKit.Vision.Common;

namespace CameraX
{
    public class TextAnalyzer : Java.Lang.Object, ImageAnalysis.IAnalyzer
    {
        private const string TAG = "CameraXBasic";
        private readonly Action<string> textListener;

        public TextAnalyzer(Action<string> callback) //TextListener listener)
        {
            this.textListener = callback;
        }

        public void Analyze(IImageProxy image)
        {
            var byteBuffer = image.GetPlanes()[0].Buffer;
            var bitmap = image.Image;
            ITextRecognizer recognizer = TextRecognition.GetClient(TextRecognizerOptions.DefaultOptions);
            var firebaseVisionImage = InputImage.FromByteBuffer(byteBuffer, 480, 640, 0, InputImage.ImageFormatYuv420888);
            //var firebaseVisionImage = InputImage.FromBitmap()

            var process = recognizer
                .Process(firebaseVisionImage)
                .AddOnSuccessListener(new ImageTextProcessedSuccess());
            var text = "Something at least..";
            textListener.Invoke(text);
        }

        private byte[] ToByteArray(ByteBuffer buff)
        {
            buff.Rewind();    // Rewind the buffer to zero
            var data = new byte[buff.Remaining()];
            buff.Get(data);   // Copy the buffer into a byte array
            return data;      // Return the byte array
        }

    }
}