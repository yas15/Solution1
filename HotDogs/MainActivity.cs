using Android.App;
using Android.Widget;
using Android.OS;

namespace HotDogs
{
    // An activity in an Android app represents a single screen with a user interface.
    // All activity’s must inherit from the Activity class and have an Activity attribute.
    // Setting MainLauncher = true, will cause this activity to be created,
    // when we launch the application i.e. this will be the first app screen.
    // Label = "HotDogs App":  Change the name of the app to "HotDogs App"
    // Update the App Icon to drawable/icon.png
    [Activity(Label = "HotDogs App", Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        // The OnCreate() method is the first method to be called when an activity is created.
        protected override void OnCreate(Bundle bundle)
        {
            int count = 1;

            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it

            // FindViewById (int id) locates an object in a view, based on its id in Resource.Designer.cs
            // FindViewById<Button>: locate an object of type Button with the Id (Id.MyButton)
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };
        }
    }
}

