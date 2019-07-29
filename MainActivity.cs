using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using System;
using Android.Graphics;

namespace IgboNumbers
{
    [Activity(Label = "SYMLIZ_XI", MainLauncher = true)]
    public class MainActivity : Activity
    {
        string Language;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            RadioButton Cameroon = FindViewById<RadioButton>(Resource.Id.radioCameroon);
            RadioButton DRC = FindViewById<RadioButton>(Resource.Id.radioDRC);
            RadioButton Nigeria = FindViewById<RadioButton>(Resource.Id.radioNigeria);
            RadioButton SA = FindViewById<RadioButton>(Resource.Id.radioSA);
            RadioButton Swaziland = FindViewById<RadioButton>(Resource.Id.radioSwaziland);

            Cameroon.Click += RadioButtonClick;
            DRC.Click += RadioButtonClick;
            Nigeria.Click += RadioButtonClick;
            SA.Click += RadioButtonClick;
            Swaziland.Click += RadioButtonClick;

            RadioGroup rg = FindViewById<RadioGroup>(Resource.Id.radioGroup1);
            string radiovalue = (FindViewById<RadioButton>(rg.CheckedRadioButtonId)).Text;

            Spinner spinner = FindViewById<Spinner>(Resource.Id.spinner);

            String[] array_Cameroon;
            array_Cameroon = new string[1];
            array_Cameroon[0] = "Iton";

            spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);

            if (radiovalue == "Cameroon")
            {
                //var adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, array_Cameroon);
                //adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);

                var adapter = new ArrayAdapter(this, Resource.Layout.spinner_item, array_Cameroon);
                adapter.SetDropDownViewResource(Resource.Layout.spinner_dropdown_item);
                spinner.Adapter = adapter;
            }

            var btnTeachNav = FindViewById<Button>(Resource.Id.btnNav);
            btnTeachNav.Click += BtnNavTeach_Click;          
        }

        private void RadioButtonClick(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;

            Spinner spinner = FindViewById<Spinner>(Resource.Id.spinner);

            String[] array_Cameroon;
            array_Cameroon = new string[1];
            array_Cameroon[0] = "Iton";

            String[] array_DRC;
            array_DRC = new string[2];
            array_DRC[0] = "Lingala";
            array_DRC[1] = "Mashi";

            String[] array_Nigeria;
            array_Nigeria = new string[2];
            array_Nigeria[0] = "Igbo";
            array_Nigeria[1] = "Yoruba";

            String[] array_SA;
            array_SA = new string[2];
            array_SA[0] = "IsiZulu";
            array_SA[1] = "IsiXhosa";

            String[] array_Swaziland;
            array_Swaziland = new string[1];
            array_Swaziland[0] = "Swati";

            spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);

            if (rb.Text == "Cameroon")
            {
                var adapter = new ArrayAdapter(this, Resource.Layout.spinner_item, array_Cameroon);
                adapter.SetDropDownViewResource(Resource.Layout.spinner_dropdown_item);
                spinner.Adapter = adapter;
            }

            if (rb.Text == "DRC")
            {
                var adapter = new ArrayAdapter(this, Resource.Layout.spinner_item, array_DRC);
                adapter.SetDropDownViewResource(Resource.Layout.spinner_dropdown_item);
                spinner.Adapter = adapter;
            }

            if (rb.Text == "Nigeria")
            {
                var adapter = new ArrayAdapter(this, Resource.Layout.spinner_item, array_Nigeria);
                adapter.SetDropDownViewResource(Resource.Layout.spinner_dropdown_item);
                spinner.Adapter = adapter;
            }

            if (rb.Text == "South Africa")
            {
                var adapter = new ArrayAdapter(this, Resource.Layout.spinner_item, array_SA);
                adapter.SetDropDownViewResource(Resource.Layout.spinner_dropdown_item);
                spinner.Adapter = adapter;
            }

            if (rb.Text == "Swaziland")
            {
                var adapter = new ArrayAdapter(this, Resource.Layout.spinner_item, array_Swaziland);
                adapter.SetDropDownViewResource(Resource.Layout.spinner_dropdown_item);
                spinner.Adapter = adapter;
            }
        }

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            //string toast = string.Format("Selected car is {0}", spinner.GetItemAtPosition(e.Position));
            //Toast.MakeText(this, toast, ToastLength.Long).Show();
            Language = spinner.GetItemAtPosition(e.Position).ToString();
        }

        private void BtnNavTeach_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(NumbersWords));
            intent.PutExtra("Language", Language);
            StartActivity(intent);
        }
    }
}

