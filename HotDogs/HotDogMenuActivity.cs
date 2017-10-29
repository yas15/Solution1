﻿using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Widget;
using ClassLibrary1.Model;
using ClassLibrary1.Service;
using HotDogs.Adapters;

namespace HotDogs
{
    [Activity(Label = "HotDogMenuActivity", MainLauncher = true)]
    public class HotDogMenuActivity : Activity
    {

        private ListView hotDogListView;
        private List<HotDog> allHotDogs;
        private HotDogDataService hotDogDataService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.HotDogMenuView);

            hotDogListView = FindViewById<ListView>(Resource.Id.hotDogListView);

            hotDogDataService = new HotDogDataService();

            allHotDogs = hotDogDataService.GetAllHotDogs();

            hotDogListView.Adapter = new HotDogListAdapter(this, allHotDogs);

            hotDogListView.FastScrollEnabled = true;
        }
    }
}