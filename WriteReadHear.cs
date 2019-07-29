using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace IgboNumbers
{
    [Activity(Label = "SYMLIZ_XI")]
    public class WriteReadHear : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.WriteReadHear);

            TextView desc = FindViewById<TextView>(Resource.Id.txtDesc);
            RadioButton write = FindViewById<RadioButton>(Resource.Id.radioWrite);
            RadioButton read = FindViewById<RadioButton>(Resource.Id.radioRead);
            RadioButton hear = FindViewById<RadioButton>(Resource.Id.radioHear);

            var language = Intent.GetStringExtra("Language");

            if (language == "Igbo")
            {
                desc.Text = "Guo, dee ma o bu guo?";
            }

            if (language == "Lingala")
            {
                desc.Text = "koma tanga yoka?";
            }

            if (language == "Mashi")
            {
                desc.Text = "Ukuandika, Ukusoma erhi Ukuyunva?";
            }

            if (language == "IsiXhosa")
            {
                desc.Text = "Funda,Bhala noma yiva?";
            }

            if (language == "IsiZulu")
            {
                desc.Text = "Funda, Bhala noma Lalela?";
            }

            if (language == "Swati")
            {
                desc.Text = "Fundza, Bhala noma yitwa?";
            }

            if (language == "Iton")
            {
                desc.Text = "Till? lang? wog?";
            }

            write.Text = "Write in " + language + " / Ecrire en " + language;
            read.Text = "Read in " + language + " / Lire en " + language;
            hear.Text = "Hear " + language + " / Ecouter I'" + language;
            
            var btnTeachNav = FindViewById<Button>(Resource.Id.btnNav);
            btnTeachNav.Click += BtnNavTeach_Click;
        }

        private void BtnNavTeach_Click(object sender, System.EventArgs e)
        {
            var language = Intent.GetStringExtra("Language");

            RadioGroup rg = FindViewById<RadioGroup>(Resource.Id.radioGroup1);
            string radiovalue = (FindViewById<RadioButton>(rg.CheckedRadioButtonId)).Text;

            Intent intent = new Intent(this, typeof(Selection));
            intent.PutExtra("Type", radiovalue);
            intent.PutExtra("Language", language);
            StartActivity(intent);
        }
    }
}

