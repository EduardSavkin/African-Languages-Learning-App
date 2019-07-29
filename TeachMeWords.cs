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
using Android.Graphics;

namespace IgboNumbers
{
    [Activity(Label = "SYMLIZ_XI")]
    public class TeachMeWords : Activity
    {
        TextView desc;
        TextView message;
        TextView message2;
        TextView message3;
        TextView name;
        TextView hidden;
        TextView hiddenOld;
        string hiddenOldValueLabel;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.TeachMeWords);

            desc = FindViewById<TextView>(Resource.Id.txtDesc);
            name = FindViewById<EditText>(Resource.Id.txtName);
            message = FindViewById<TextView>(Resource.Id.txtMessage);
            message2 = FindViewById<TextView>(Resource.Id.txtMessage2);
            message3 = FindViewById<TextView>(Resource.Id.txtMessage3);
            hidden = FindViewById<TextView>(Resource.Id.txtHidden);
            hiddenOld = FindViewById<TextView>(Resource.Id.txtHiddenOld);

            var language = Intent.GetStringExtra("Language");
            desc.Text = "Kuziere m";

            var hear = Intent.GetStringExtra("Hear");

            var btnHear = FindViewById<Button>(Resource.Id.btnHear);
            btnHear.Click += replayButton_Click;

            name.KeyPress += Text_Enter;
            message2.Click += msgBoxLabel2_Click;
            message3.Click += msgBoxLabel3_Click;

            WordIgbo wd = null;
            Random rnd = new Random();
            int myVal = rnd.Next(0, 10);
            hidden.Text = myVal.ToString();
            hidden.Visibility = ViewStates.Gone;
            hiddenOld.Visibility = ViewStates.Gone;

            if (hear == "To be")
            {
                ToBeIgbo tbi = new ToBeIgbo();
                tbi.propValue = myVal;
                wd = tbi;
                hidden.Text = myVal.ToString();
                hiddenOld.Text = myVal.ToString();
            }
            if (hear == "To have")
            {
                ToHaveIgbo thi = new ToHaveIgbo();
                thi.propValue = myVal;
                hidden.Text = (myVal + 10).ToString();
                hiddenOld.Text = (myVal + 10).ToString();
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
                    hiddenOld.Text = (myVal + 20).ToString();
                }
                if (myVal2 == 1)
                {
                    ToHaveIgbo thi = new ToHaveIgbo();
                    thi.propValue = myVal;
                    wd = thi;
                    hidden.Text = (myVal + 30).ToString();
                    hiddenOld.Text = (myVal + 30).ToString();
                }
            }
            wd.play();
            //tmwif.propEnglishOrFrenchTextTextBox.Select();
            //tmwif.propEnglishOrFrenchTextTextBox.Focus();
            //tmwif.Show();
        }

        private void blinkTextbox(object sender, EventArgs e)
        {
            message.SetBackgroundColor(Color.Gold);
            if (message.HighlightColor == Color.Gold)
            { message.SetBackgroundColor(Color.Green); }
            else
            { message.SetBackgroundColor(Color.Gold); }
        }

        private void blinkTextbox2(object sender, EventArgs e)
        {
            message2.SetBackgroundColor(Color.Gold);
            if (message2.HighlightColor == Color.Gold)
            { message2.SetBackgroundColor(Color.Green); }
            else
            { message2.SetBackgroundColor(Color.Gold); }
        }

        private void blinkTextbox3(object sender, EventArgs e)
        {
            message3.SetBackgroundColor(Color.Gold);
            if (message3.HighlightColor == Color.Gold)
            { message3.SetBackgroundColor(Color.Green); }
            else
            { message3.SetBackgroundColor(Color.Gold); }
        }

        private void OurReplayButton()
        {
            if (!message2.Text.Contains("....")
                && !message3.Text.Contains("....")
                && message2.Text != "" && message3.Text != "")
            {
                WordIgbo wd = null;
                int n = int.Parse(hiddenOld.Text);
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
                //name.Select();
                //name.Focus();
            }
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
                    hiddenOldValueLabel = "correct";
                    message2.Text = "";
                    message3.Text = "";
                    //if (message.HighlightColor == Color.Gold)
                    //{ message.SetBackgroundColor(Color.Green); }
                    //else
                    //{ message.SetBackgroundColor(Color.Gold); }
                    message.Text = "Correct";
                    //Timer ti = new Timer();
                    //ti.Tick += blinkTextbox;
                    //ti.Interval = 450;
                    //ti.Enabled = true;

                }
                if (wd.checkIton(name.Text.ToUpper()) == false)
                {
                    hiddenOldValueLabel = "incorrect";
                    message.Text = "Incorrect: Click answer below / Click reponse ci-bas";
                    message2.Text = wd.propStemEnglish[wd.propValue];
                    message3.Text = wd.propStemFrench[wd.propValue];
                    hiddenOld.Text = n.ToString();
                }

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
                if (hiddenOldValueLabel == "correct")
                {
                    wd.play();
                }

                name.Text = "";

                e.Handled = true;
            }
        }

        private void teachMeAgainButton_Click(object sender, EventArgs e)
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
            if (hiddenOldValueLabel == "correct") { wd.play(); }

            name.Text = "";
            //englishOrFrenchTextTextBox.Select();
            //englishOrFrenchTextTextBox.Focus();
        }

        private void msgBoxLabel2_Click(object sender, EventArgs e)
        {
            OurReplayButton();
        }

        private void msgBoxLabel3_Click(object sender, EventArgs e)
        {
            OurReplayButton();
        }
    }
}