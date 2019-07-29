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
    public class Selection : Activity
    {
        string t;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Selection);

            TextView desc = FindViewById<TextView>(Resource.Id.txtDesc);
            RadioButton units = FindViewById<RadioButton>(Resource.Id.radioButton1);
            RadioButton fullTenths = FindViewById<RadioButton>(Resource.Id.radioButton2);
            RadioButton halfTenths = FindViewById<RadioButton>(Resource.Id.radioButton3);
            RadioButton fullHundreds = FindViewById<RadioButton>(Resource.Id.radioButton4);
            RadioButton halfHunderds = FindViewById<RadioButton>(Resource.Id.radioButton5);

            TextView type = FindViewById<TextView>(Resource.Id.txtType);
            var typeText = Intent.GetStringExtra("Type");
            var language = Intent.GetStringExtra("Language");

            if(language == "Igbo")
            {
                desc.Text = "Horo nomba gi";
            }

            if (language == "Lingala")
            {
                desc.Text = "Pona numero";
            }

            if (language == "Mashi")
            {
                desc.Text = "Ochagule enumero yawe";
            }

            if (language == "IsiXhosa")
            {
                desc.Text = "Khetha inombolo";
            }

            if (language == "IsiZulu")
            {
                desc.Text = "Khetha inombolo yakho";
            }

            if (language == "Swati")
            {
                desc.Text = "Khetha Inombolo yakho";
            }

            if (language == "Iton")
            {
                desc.Text = "Twab nwamo wo";
            }

            var write = typeText.Contains("Write");
            var read = typeText.Contains("Read");
            var hear = typeText.Contains("Hear");

            if (write == true)
            {
                t = "Writing";
            }
            if (read == true)
            {
                t = "Reading";
            }
            if (hear == true)
            {
                t = "Hearing";
            }

            type.Text += t;

            var btnTeach = FindViewById<Button>(Resource.Id.btnTeach);
            btnTeach.Click += BtnTeach_Click;

            var btnTest = FindViewById<Button>(Resource.Id.btnTest);
            btnTest.Click += BtnTest_Click;
        }

        private void BtnTeach_Click(object sender, EventArgs e)
        {
            var typeText = Intent.GetStringExtra("Type");
            var language = Intent.GetStringExtra("Language");

            RadioGroup rg = FindViewById<RadioGroup>(Resource.Id.radioGroup1);
            string radiovalue = (FindViewById<RadioButton>(rg.CheckedRadioButtonId)).Text;

            Intent intentIgbo = new Intent(this, typeof(TeachMe));
            Intent intentLingala = new Intent(this, typeof(TeachMeLingala));
            Intent intentMashi = new Intent(this, typeof(TeachMeMashi));
            Intent intentIsiZulu = new Intent(this, typeof(TeachMeIsiZulu));
            Intent intentIton = new Intent(this, typeof(TeachMeIton));
            Intent intentSwati = new Intent(this, typeof(TeachMeSwati));
            Intent intentIsiXhosa = new Intent(this, typeof(TeachMeIsiXhosa));

            intentIgbo.PutExtra("Range", radiovalue);
            intentIgbo.PutExtra("Language", language);
            intentLingala.PutExtra("Range", radiovalue);
            intentLingala.PutExtra("Language", language);
            intentMashi.PutExtra("Range", radiovalue);
            intentMashi.PutExtra("Language", language);
            intentIsiZulu.PutExtra("Range", radiovalue);
            intentIsiZulu.PutExtra("Language", language);
            intentIton.PutExtra("Range", radiovalue);
            intentIton.PutExtra("Language", language);
            intentSwati.PutExtra("Range", radiovalue);
            intentSwati.PutExtra("Language", language);
            intentIsiXhosa.PutExtra("Range", radiovalue);
            intentIsiXhosa.PutExtra("Language", language);

            if (typeText == "Write in Igbo / Ecrire en Igbo")
            {
                intentIgbo.PutExtra("Learn", "Writing");
                StartActivity(intentIgbo);
            }
            if (typeText == "Read in Igbo / Lire en Igbo")
            {
                intentIgbo.PutExtra("Learn", "Reading");
                StartActivity(intentIgbo);
            }
            if (typeText == "Hear Igbo / Ecouter I'Igbo")
            {
                intentIgbo.PutExtra("Learn", "Hearing");
                StartActivity(intentIgbo);
            }

            if (typeText == "Write in Lingala / Ecrire en Lingala")
            {
                intentLingala.PutExtra("Learn", "Writing");
                StartActivity(intentLingala);
            }
            if (typeText == "Read in Lingala / Lire en Lingala")
            {
                intentLingala.PutExtra("Learn", "Reading");
                StartActivity(intentLingala);
            }
            if (typeText == "Hear Lingala / Ecouter I'Lingala")
            {
                intentLingala.PutExtra("Learn", "Hearing");
                StartActivity(intentLingala);
            }

            if (typeText == "Write in Mashi / Ecrire en Mashi")
            {
                intentMashi.PutExtra("Learn", "Writing");
                StartActivity(intentMashi);
            }
            if (typeText == "Read in Mashi / Lire en Mashi")
            {
                intentMashi.PutExtra("Learn", "Reading");
                StartActivity(intentMashi);
            }
            if (typeText == "Hear Mashi / Ecouter I'Mashi")
            {
                intentMashi.PutExtra("Learn", "Hearing");
                StartActivity(intentMashi);
            }

            if (typeText == "Write in IsiZulu / Ecrire en IsiZulu")
            {
                intentIsiZulu.PutExtra("Learn", "Writing");
                StartActivity(intentIsiZulu);
            }
            if (typeText == "Read in IsiZulu / Lire en IsiZulu")
            {
                intentIsiZulu.PutExtra("Learn", "Reading");
                StartActivity(intentIsiZulu);
            }
            if (typeText == "Hear IsiZulu / Ecouter I'IsiZulu")
            {
                intentIsiZulu.PutExtra("Learn", "Hearing");
                StartActivity(intentIsiZulu);
            }

            if (typeText == "Write in Iton / Ecrire en Iton")
            {
                intentIton.PutExtra("Learn", "Writing");
                StartActivity(intentIton);
            }
            if (typeText == "Read in Iton / Lire en Iton")
            {
                intentIton.PutExtra("Learn", "Reading");
                StartActivity(intentIton);
            }
            if (typeText == "Hear Iton / Ecouter I'Iton")
            {
                intentIton.PutExtra("Learn", "Hearing");
                StartActivity(intentIton);
            }

            if (typeText == "Write in Swati / Ecrire en Swati")
            {
                intentSwati.PutExtra("Learn", "Writing");
                StartActivity(intentSwati);
            }
            if (typeText == "Read in Swati / Lire en Swati")
            {
                intentSwati.PutExtra("Learn", "Reading");
                StartActivity(intentSwati);
            }
            if (typeText == "Hear Swati / Ecouter I'Swati")
            {
                intentSwati.PutExtra("Learn", "Hearing");
                StartActivity(intentSwati);
            }

            if (typeText == "Write in IsiXhosa / Ecrire en IsiXhosa")
            {
                intentIsiXhosa.PutExtra("Learn", "Writing");
                StartActivity(intentIsiXhosa);
            }
            if (typeText == "Read in IsiXhosa / Lire en IsiXhosa")
            {
                intentIsiXhosa.PutExtra("Learn", "Reading");
                StartActivity(intentIsiXhosa);
            }
            if (typeText == "Hear IsiXhosa / Ecouter I'IsiXhosa")
            {
                intentIsiXhosa.PutExtra("Learn", "Hearing");
                StartActivity(intentIsiXhosa);
            }
        }

        private void BtnTest_Click(object sender, EventArgs e)
        {
            var typeText = Intent.GetStringExtra("Type");
            var language = Intent.GetStringExtra("Language");

            RadioGroup rg = FindViewById<RadioGroup>(Resource.Id.radioGroup1);
            string radiovalue = (FindViewById<RadioButton>(rg.CheckedRadioButtonId)).Text;

            Intent intentIgbo = new Intent(this, typeof(TestMe));
            Intent intentLingala = new Intent(this, typeof(TestMeLingala));
            Intent intentMashi = new Intent(this, typeof(TestMeMashi));
            Intent intentIsiZulu = new Intent(this, typeof(TestMeIsiZulu));
            Intent intentIton = new Intent(this, typeof(TestMeIton));
            Intent intentSwati = new Intent(this, typeof(TestMeSwati));
            Intent intentIsiXhosa = new Intent(this, typeof(TestMeIsiXhosa));

            intentIgbo.PutExtra("Range", radiovalue);
            intentIgbo.PutExtra("Language", language);
            intentLingala.PutExtra("Range", radiovalue);
            intentLingala.PutExtra("Language", language);
            intentMashi.PutExtra("Range", radiovalue);
            intentMashi.PutExtra("Language", language);
            intentIsiZulu.PutExtra("Range", radiovalue);
            intentIsiZulu.PutExtra("Language", language);
            intentIton.PutExtra("Range", radiovalue);
            intentIton.PutExtra("Language", language);
            intentSwati.PutExtra("Range", radiovalue);
            intentSwati.PutExtra("Language", language);
            intentIsiXhosa.PutExtra("Range", radiovalue);
            intentIsiXhosa.PutExtra("Language", language);

            if (typeText == "Write in Igbo / Ecrire en Igbo")
            {
                intentIgbo.PutExtra("Learn", "Writing");
                StartActivity(intentIgbo);
            }
            if (typeText == "Read in Igbo / Lire en Igbo")
            {
                intentIgbo.PutExtra("Learn", "Reading");
                StartActivity(intentIgbo);
            }
            if (typeText == "Hear Igbo / Ecouter I'Igbo")
            {
                intentIgbo.PutExtra("Learn", "Hearing");
                StartActivity(intentIgbo);
            }

            if (typeText == "Write in Lingala / Ecrire en Lingala")
            {
                intentLingala.PutExtra("Learn", "Writing");
                StartActivity(intentLingala);
            }
            if (typeText == "Read in Lingala / Lire en Lingala")
            {
                intentLingala.PutExtra("Learn", "Reading");
                StartActivity(intentLingala);
            }
            if (typeText == "Hear Lingala / Ecouter I'Lingala")
            {
                intentLingala.PutExtra("Learn", "Hearing");
                StartActivity(intentLingala);
            }

            if (typeText == "Write in Mashi / Ecrire en Mashi")
            {
                intentMashi.PutExtra("Learn", "Writing");
                StartActivity(intentMashi);
            }
            if (typeText == "Read in Mashi / Lire en Mashi")
            {
                intentMashi.PutExtra("Learn", "Reading");
                StartActivity(intentMashi);
            }
            if (typeText == "Hear Mashi / Ecouter I'Mashi")
            {
                intentMashi.PutExtra("Learn", "Hearing");
                StartActivity(intentMashi);
            }

            if (typeText == "Write in IsiZulu / Ecrire en IsiZulu")
            {
                intentIsiZulu.PutExtra("Learn", "Writing");
                StartActivity(intentIsiZulu);
            }
            if (typeText == "Read in IsiZulu / Lire en IsiZulu")
            {
                intentIsiZulu.PutExtra("Learn", "Reading");
                StartActivity(intentIsiZulu);
            }
            if (typeText == "Hear IsiZulu / Ecouter I'IsiZulu")
            {
                intentIsiZulu.PutExtra("Learn", "Hearing");
                StartActivity(intentIsiZulu);
            }

            if (typeText == "Write in Iton / Ecrire en Iton")
            {
                intentIton.PutExtra("Learn", "Writing");
                StartActivity(intentIton);
            }
            if (typeText == "Read in Iton / Lire en Iton")
            {
                intentIton.PutExtra("Learn", "Reading");
                StartActivity(intentIton);
            }
            if (typeText == "Hear Iton / Ecouter I'Iton")
            {
                intentIton.PutExtra("Learn", "Hearing");
                StartActivity(intentIton);
            }

            if (typeText == "Write in Swati / Ecrire en Swati")
            {
                intentSwati.PutExtra("Learn", "Writing");
                StartActivity(intentSwati);
            }
            if (typeText == "Read in Swati / Lire en Swati")
            {
                intentSwati.PutExtra("Learn", "Reading");
                StartActivity(intentSwati);
            }
            if (typeText == "Hear Swati / Ecouter I'Swati")
            {
                intentSwati.PutExtra("Learn", "Hearing");
                StartActivity(intentSwati);
            }

            if (typeText == "Write in IsiXhosa / Ecrire en IsiXhosa")
            {
                intentIsiXhosa.PutExtra("Learn", "Writing");
                StartActivity(intentIsiXhosa);
            }
            if (typeText == "Read in IsiXhosa / Lire en IsiXhosa")
            {
                intentIsiXhosa.PutExtra("Learn", "Reading");
                StartActivity(intentIsiXhosa);
            }
            if (typeText == "Hear IsiXhosa / Ecouter I'IsiXhosa")
            {
                intentIsiXhosa.PutExtra("Learn", "Hearing");
                StartActivity(intentIsiXhosa);
            }
        }
    }
}