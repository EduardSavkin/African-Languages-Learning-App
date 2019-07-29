using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace IgboNumbers
{
    [Activity(Label = "SYMLIZ_XI")]
    public class ChooseVerb : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ChooseVerb);

            TextView desc = FindViewById<TextView>(Resource.Id.txtDesc);
            RadioButton have = FindViewById<RadioButton>(Resource.Id.radioButton1);
            RadioButton be = FindViewById<RadioButton>(Resource.Id.radioButton2);
            RadioButton both = FindViewById<RadioButton>(Resource.Id.radioButton3);

            var language = Intent.GetStringExtra("Language");

            if (language == "Igbo")
            {
                desc.Text = "Kedu okwu?";
            }

            if (language == "Lingala")
            {
                desc.Text = "Maloba nini?";
            }

            if (language == "Mashi")
            {
                desc.Text = "Izino liphi?";
            }

            if (language == "IsiXhosa")
            {
                desc.Text = "Liphi igama?";
            }

            if (language == "IsiZulu")
            {
                desc.Text = "Kuwaphi amagama?";
            }

            if (language == "Swati")
            {
                desc.Text = "Imaphi amagama?";
            }

            if (language == "Iton")
            {
                desc.Text = "Ibug ipe?";
            }

            var btnTeach = FindViewById<Button>(Resource.Id.btnTeach);
            btnTeach.Click += BtnTeach_Click;

            var btnTest = FindViewById<Button>(Resource.Id.btnTest);
            btnTest.Click += BtnTest_Click;
        }

        private void BtnTeach_Click(object sender, EventArgs e)
        {
            var language = Intent.GetStringExtra("Language");

            RadioGroup rg = FindViewById<RadioGroup>(Resource.Id.radioGroup1);
            string radiovalue = (FindViewById<RadioButton>(rg.CheckedRadioButtonId)).Text;

            Intent intentIgbo = new Intent(this, typeof(TeachMeWords));
            Intent intentLingala = new Intent(this, typeof(TeachMeWordsLingala));
            Intent intentMashi = new Intent(this, typeof(TeachMeWordsMashi));
            Intent intentIsiZulu = new Intent(this, typeof(TeachMeWordsIsiZulu));
            Intent intentIsiXhosa = new Intent(this, typeof(TeachMeWordsIsiXhosa));
            Intent intentSwati = new Intent(this, typeof(TeachMeWordsSwati));
            Intent intentIton = new Intent(this, typeof(TeachMeWordsIton));

            intentIgbo.PutExtra("Hear", radiovalue);
            intentIgbo.PutExtra("Language", language);
            intentLingala.PutExtra("Hear", radiovalue);
            intentLingala.PutExtra("Language", language);
            intentMashi.PutExtra("Hear", radiovalue);
            intentMashi.PutExtra("Language", language);
            intentIsiZulu.PutExtra("Hear", radiovalue);
            intentIsiZulu.PutExtra("Language", language);
            intentIsiXhosa.PutExtra("Hear", radiovalue);
            intentIsiXhosa.PutExtra("Language", language);
            intentSwati.PutExtra("Hear", radiovalue);
            intentSwati.PutExtra("Language", language);
            intentIton.PutExtra("Hear", radiovalue);
            intentIton.PutExtra("Language", language);

            if (language == "Igbo")
            {
                StartActivity(intentIgbo);
            }

            if (language == "Lingala")
            {
                StartActivity(intentLingala);
            }

            if (language == "Mashi")
            {
                StartActivity(intentMashi);
            }

            if (language == "IsiZulu")
            {
                StartActivity(intentIsiZulu);
            }

            if (language == "IsiXhosa")
            {
                StartActivity(intentIsiXhosa);
            }

            if (language == "Swati")
            {
                StartActivity(intentSwati);
            }

            if (language == "Iton")
            {
                StartActivity(intentIton);
            }
        }

        private void BtnTest_Click(object sender, EventArgs e)
        {
            var language = Intent.GetStringExtra("Language");

            RadioGroup rg = FindViewById<RadioGroup>(Resource.Id.radioGroup1);
            string radiovalue = (FindViewById<RadioButton>(rg.CheckedRadioButtonId)).Text;

            Intent intentIgbo = new Intent(this, typeof(TestMeWords));
            Intent intentLingala = new Intent(this, typeof(TestMeWordsLingala));
            Intent intentMashi = new Intent(this, typeof(TestMeWordsMashi));
            Intent intentIsiZulu = new Intent(this, typeof(TestMeWordsIsiZulu));
            Intent intentIsiXhosa = new Intent(this, typeof(TestMeWordsIsiXhosa));
            Intent intentSwati = new Intent(this, typeof(TestMeWordsSwati));
            Intent intentIton = new Intent(this, typeof(TestMeWordsIton));

            intentIgbo.PutExtra("Hear", radiovalue);
            intentIgbo.PutExtra("Language", language);
            intentLingala.PutExtra("Hear", radiovalue);
            intentLingala.PutExtra("Language", language);
            intentMashi.PutExtra("Hear", radiovalue);
            intentMashi.PutExtra("Language", language);
            intentIsiZulu.PutExtra("Hear", radiovalue);
            intentIsiZulu.PutExtra("Language", language);
            intentIsiXhosa.PutExtra("Hear", radiovalue);
            intentIsiXhosa.PutExtra("Language", language);
            intentSwati.PutExtra("Hear", radiovalue);
            intentSwati.PutExtra("Language", language);
            intentIton.PutExtra("Hear", radiovalue);
            intentIton.PutExtra("Language", language);

            if (language == "Igbo")
            {
                StartActivity(intentIgbo);
            }

            if (language == "Lingala")
            {
                StartActivity(intentLingala);
            }

            if (language == "Mashi")
            {
                StartActivity(intentMashi);
            }

            if (language == "IsiZulu")
            {
                StartActivity(intentIsiZulu);
            }

            if (language == "IsiXhosa")
            {
                StartActivity(intentIsiXhosa);
            }

            if (language == "Swati")
            {
                StartActivity(intentSwati);
            }

            if (language == "Iton")
            {
                StartActivity(intentIton);
            }
        }
    }
}