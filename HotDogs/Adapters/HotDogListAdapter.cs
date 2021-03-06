﻿using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;
using ClassLibrary1.Model;
using HotDogs.Utility;

namespace HotDogs.Adapters
{
    //ListView is a view group that displays a list of scrollable items. The list items are automatically 
    //inserted to the list using an Adapter that pulls content from a source such
    public class HotDogListAdapter : BaseAdapter<HotDog>
    {
        List<HotDog> items;
        Activity context;

        public HotDogListAdapter(Activity context, List<HotDog> items) : base()
        {
            this.context = context;
            this.items = items;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override HotDog this[int position]
        {
            get
            {
                return items[position];
            }
        }

        public override int Count
        {
            get
            {
                return items.Count;
            }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];

            // since we are getting the image from a URL, the data service on the mobile device
            // must be switched on, otherwise the app will error out.
            var imageBitmap = ImageHelper.GetImageBitmapFromUrl("https://upload.wikimedia.org/wikipedia/commons/thumb/3/3a/NCI_Visuals_Food_Hot_Dog.jpg/800px-NCI_Visuals_Food_Hot_Dog.jpg");

            if (convertView == null)
            {
                convertView = context.LayoutInflater.Inflate(Resource.Layout.HotDogRowView, null);
            }

            convertView.FindViewById<TextView>(Resource.Id.hotDogNameTextView).Text = item.Name;
            convertView.FindViewById<TextView>(Resource.Id.shortDescriptionTextView).Text = item.ShortDescription;
            convertView.FindViewById<TextView>(Resource.Id.priceTextView).Text = "$ " + item.Price;
            convertView.FindViewById<ImageView>(Resource.Id.hotDogImageView).SetImageBitmap(imageBitmap);

            return convertView;
        }

    }
}