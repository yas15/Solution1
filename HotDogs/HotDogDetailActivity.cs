﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ClassLibrary1.Service;
using ClassLibrary1.Model;
using HotDogs.Utility;

namespace HotDogs
{
    // An activity in an Android app represents a single screen with a user interface.
    // All activity’s must inherit from the Activity class and have an Activity attribute.
    // Setting MainLauncher = true, will cause this activity to be created,
    // when we launch the application i.e. this will be the first app screen.
    // Label = "Hotdog detail":  Change the name of the app to "Hotdog detail"
    [Activity(Label = "Hotdog details", MainLauncher = true)]
    public class HotDogDetailActivity : Activity
    {
        private ImageView hotDogImageView;
        private TextView hotDogNameTextView;
        private TextView shortDescriptionTextView;
        private TextView descriptionTextView;
        private TextView priceTextView;
        private EditText amountEditText;
        private Button cancelButton;
        private Button orderButton;
        private HotDog selectedHotDog;
        private HotDogDataService dataService;


        // The OnCreate() method is the first method to be called when an activity is created.
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set the view for this activity to be "HotDogDetailView.axml" from the folder layout/resource
            SetContentView(Resource.Layout.HotDogDetailView);

            HotDogDataService dataService = new HotDogDataService();

            selectedHotDog = dataService.GetHotDogById(1);

            // call the FindViews() method
            FindViews();

            // call the BindData() method
            BindData();

            // call the HandleEvents() method
            HandleEvents();
        }


        private void FindViews()
        {

            // FindViewById (int id) locates an object in a view, based on its id in Resource.Designer.cs
            // FindViewById<ImageView>: locate an object of type Button with the Id (Id.hotDogImageView)
            // set the hotDogImageView object
            hotDogImageView = FindViewById<ImageView>(Resource.Id.hotDogImageView);

            hotDogNameTextView = FindViewById<TextView>(Resource.Id.hotDogNameTextView);
            shortDescriptionTextView = FindViewById<TextView>(Resource.Id.shortDescriptionTextView);
            descriptionTextView = FindViewById<TextView>(Resource.Id.descriptionTextView);
            priceTextView = FindViewById<TextView>(Resource.Id.priceTextView);
            amountEditText = FindViewById<EditText>(Resource.Id.amountEditText);
            cancelButton = FindViewById<Button>(Resource.Id.cancelButton);
            orderButton = FindViewById<Button>(Resource.Id.orderButton);
        }


        // use the method BindData() to bind view objects to 
        private void BindData()
        {
            // set the text on the hotDogImageView object to selectedHotDog.Name 
            hotDogNameTextView.Text = selectedHotDog.Name;

            shortDescriptionTextView.Text = selectedHotDog.ShortDescription;
            descriptionTextView.Text = selectedHotDog.Description;
            priceTextView.Text = "Price: " + selectedHotDog.Price;

            var imageBitmap = ImageHelper.GetImageBitmapFromUrl("http://gillcleerenpluralsight.blob.core.windows.net/files/" + selectedHotDog.ImagePath + ".jpg");

            hotDogImageView.SetImageBitmap(imageBitmap);
        }

        // Link the delegate methods to the button events
        private void HandleEvents()
        {
            orderButton.Click += OrderButton_Click;
            cancelButton.Click += CancelButton_Click;
        }


        private void CancelButton_Click(object sender, EventArgs e)
        {
            //TODO
        }


        private void OrderButton_Click(object sender, EventArgs e)
        {
            var amount = Int32.Parse(amountEditText.Text);

            //AlertDialog.Builder(Context context): Creates a builder for an alert dialog
            var dialog = new AlertDialog.Builder(this);

            dialog.SetTitle("Confirmation");
            dialog.SetMessage("Your hot dog has been added to your cart!");
            dialog.Show();
        }

    }
}