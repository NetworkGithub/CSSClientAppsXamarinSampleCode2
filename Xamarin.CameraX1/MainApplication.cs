using Android.App;
using Android.OS;
using System;

namespace CameraX
{
#if DEBUG
    [Application(Debuggable = true)]
#else
    [Application(Debuggable = false)]
#endif
    public partial class MainApplication : Application, Application.IActivityLifecycleCallbacks
    {
        public static Activity CurrentContext { get; private set; }

        public MainApplication(IntPtr javaReference, Android.Runtime.JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }
        public override void OnCreate()
        {
            base.OnCreate();
            RegisterActivityLifecycleCallbacks(this);
        }
        public override void OnTerminate()
        {
            base.OnTerminate();
            UnregisterActivityLifecycleCallbacks(this);
        }
        public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
        {
            CurrentContext = activity;
        }
        public void OnActivityDestroyed(Activity activity)
        {
        }
        public void OnActivityPaused(Activity activity)
        {
        }
        public void OnActivityResumed(Activity activity)
        {
            CurrentContext = activity;
        }
        public void OnActivitySaveInstanceState(Activity activity, Bundle outState)
        {
        }
        public void OnActivityStarted(Activity activity)
        {
            CurrentContext = activity;
        }
        public void OnActivityStopped(Activity activity)
        {
        }
    }
}