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
using System.Threading.Tasks;

namespace IgboNumbers
{
    [Activity(Label = "SYMLIZ_XI")]
    public class TestMeWords : Activity
    {
        static Random r = new Random();
        EditText name;
        TextView desc;
        TextView score;
        TextView total;
        TextView hidden;
        TextView message;
        int s = 0;
        int t = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.TestMeWords);

            name = FindViewById<EditText>(Resource.Id.txtName);
            desc = FindViewById<TextView>(Resource.Id.txtDesc);
            message = FindViewById<TextView>(Resource.Id.txtMessage);
            hidden = FindViewById<TextView>(Resource.Id.txtHidden);
            score = FindViewById<TextView>(Resource.Id.txtScore);
            total = FindViewById<TextView>(Resource.Id.txtOutOf);

            var language = Intent.GetStringExtra("Language");
            desc.Text = "Wale m";

            var hear = Intent.GetStringExtra("Hear");

            var btnHear = FindViewById<Button>(Resource.Id.btnHear);
            btnHear.Click += replayButton_Click;

            name.KeyPress += Text_Enter;

            WordIgbo wd = null;
            Random rnd = new Random();
            int myVal = rnd.Next(0, 10);
            hidden.Text = myVal.ToString();
            hidden.Visibility = ViewStates.Gone;
            if (hear == "To be")
            {
                ToBeIgbo tbi = new ToBeIgbo();
                tbi.propValue = myVal;
                wd = tbi;
                hidden.Text = myVal.ToString();
            }
            if (hear == "To have")
            {
                ToHaveIgbo thi = new ToHaveIgbo();
                thi.propValue = myVal;
                hidden.Text = (myVal + 10).ToString();
                wd = thi;
            }
            if (hear == "To have and To be")
            {
                Random rnd2 = new Random();
                int myVal2 = rnd.Next(0, 2);
                if (myVal2 == 0)
                {
                    ToBeIgbo tbi = new ToBeIgbo();
                    tbi.propValue = myVal;
                    wd = tbi;
                    hidden.Text = (myVal + 20).ToString();
                }
                if (myVal2 == 1)
                {
                    ToHaveIgbo thi = new ToHaveIgbo();
                    thi.propValue = myVal;
                    wd = thi;
                    hidden.Text = (myVal + 30).ToString();
                }
            }
            wd.play();
            //tmwif.propEnglishOrFrenchTextTextBox.Select();
            //tmwif.propEnglishOrFrenchTextTextBox.Focus();
            //tmwif.Show();
        }

        private void replayButton_Click(object sender, EventArgs e)
        {
            WordIgbo wd = null;
            int n = int.Parse(hidden.Text);
            if (((n >= 0) && (n <= 9)) || ((n >= 20) && (n <= 29)))
            {
                ToBeIgbo tbi = new ToBeIgbo();
                if ((n >= 0) && (n <= 9)) { tbi.propValue = n; };
                if ((n >= 20) && (n <= 29)) { tbi.propValue = n - 20; }
                wd = tbi;
            }
            if (((n >= 10) && (n <= 19)) || ((n >= 30) && (n <= 39)))
            {
                ToHaveIgbo thi = new ToHaveIgbo();
                if ((n >= 10) && (n <= 19)) { thi.propValue = n - 10; }
                if ((n >= 30) && (n <= 39)) { thi.propValue = n - 30; }
                wd = thi;
            }
            wd.play();
            //englishOrFrenchTextTextBox.Select();
            //englishOrFrenchTextTextBox.Focus();
        }

        private void Text_Enter(object sender, View.KeyEventArgs e)
        {
            e.Handled = false;
            if (e.Event.Action == KeyEventActions.Down && e.KeyCode == Keycode.Enter)
            {
                t = t + 1;
                WordIgbo wd = null;
                int n = int.Parse(hidden.Text);
                if (((n >= 0) && (n <= 9)) || ((n >= 20) && (n <= 29)))
                {
                    ToBeIgbo tbi = new ToBeIgbo();
                    if ((n >= 0) && (n <= 9)) { tbi.propValue = n; };
                    if ((n >= 20) && (n <= 29)) { tbi.propValue = n - 20; }
                    wd = tbi;
                }
                if (((n >= 10) && (n <= 19)) || ((n >= 30) && (n <= 39)))
                {
                    ToHaveIgbo thi = new ToHaveIgbo();
                    if ((n >= 10) && (n <= 19)) { thi.propValue = n - 10; }
                    if ((n >= 30) && (n <= 39)) { thi.propValue = n - 30; }
                    wd = thi;
                }
                if (wd.checkIton(name.Text.ToUpper()) == true)
                {
                    s = s + 1;
                    //if (msgBoxLabel.BackColor == Color.Gold)
                    //{ msgBoxLabel.BackColor = Color.Green; }
                    //else
                    //{ msgBoxLabel.BackColor = Color.Gold; }
                    message.Text = "Correct";
                    //Timer ti = new Timer();
                    //ti.Tick += blinkTextbox;
                    //ti.Interval = 450;
                    //ti.Enabled = true;
                }
                if (wd.checkIton(name.Text.ToUpper()) == false)
                {
                    message.Text = "Incorrect answer below";
                    Task.Delay(1000).Wait();
                }
                score.Text = s.ToString();
                total.Text = t.ToString();

                Random rnd = new Random();
                int myVal = rnd.Next(0, 10);
                if ((n >= 0) && (n <= 9))
                {
                    ToBeIgbo tbi = new ToBeIgbo();
                    tbi.propValue = myVal;
                    wd = tbi;
                    hidden.Text = myVal.ToString();
                }
                if ((n >= 10) && (n <= 19))
                {
                    ToHaveIgbo thi = new ToHaveIgbo();
                    thi.propValue = myVal;
                    wd = thi;
                    hidden.Text = (myVal + 10).ToString();
                }
                if ((n >= 20) && (n <= 39))
                {
                    Random rnd2 = new Random();
                    int myVal2 = rnd.Next(0, 2);
                    if (myVal2 == 0)
                    {
                        ToBeIgbo tbi = new ToBeIgbo();
                        tbi.propValue = myVal;
                        wd = tbi;
                        hidden.Text = (myVal + 20).ToString();
                    }
                    if (myVal2 == 1)
                    {
                        ToHaveIgbo thi = new ToHaveIgbo();
                        thi.propValue = myVal;
                        wd = thi;
                        hidden.Text = (myVal + 30).ToString();
                    }
                }
                wd.play();
                name.Text = "";

                e.Handled = true;
            }
        }

        private void testMeAgainButton_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int myVal = rnd.Next(0, 10);
            WordIgbo wd = null;
            int n = int.Parse(hidden.Text);
            if ((n >= 0) && (n <= 9))
            {
                ToBeIgbo tbi = new ToBeIgbo();
                tbi.propValue = myVal;
                wd = tbi;
                hidden.Text = myVal.ToString();
            }
            if ((n >= 10) && (n <= 19))
            {
                ToHaveIgbo thi = new ToHaveIgbo();
                thi.propValue = myVal;
                wd = thi;
                hidden.Text = (myVal + 10).ToString();
            }
            if ((n >= 20) && (n <= 39))
            {
                Random rnd2 = new Random();
                int myVal2 = rnd.Next(0, 2);
                if (myVal2 == 0)
                {
                    ToBeIgbo tbi = new ToBeIgbo();
                    tbi.propValue = myVal;
                    wd = tbi;
                    hidden.Text = (myVal + 20).ToString();
                }
                if (myVal2 == 1)
                {
                    ToHaveIgbo thi = new ToHaveIgbo();
                    thi.propValue = myVal;
                    wd = thi;
                    hidden.Text = (myVal + 30).ToString();
                }
            }
            wd.play();
            name.Text = "";
            //englishOrFrenchTextTextBox.Select();
            //englishOrFrenchTextTextBox.Focus();
        }
    }
}