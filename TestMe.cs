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
using Java.IO;
using Android.Media;
using Android.Views.InputMethods;

namespace IgboNumbers
{
    [Activity(Label = "SYMLIZ_XI")]
    public class TestMe : Activity
    {
        static Random r = new Random();
        TextView num;
        EditText name;
        TextView desc;
        TextView score;
        TextView total;
        TextView hidden;
        TextView TextLabel;
        TextView message;
        //Button button;
        int count;
        int tot;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var learn = Intent.GetStringExtra("Learn");

            if (learn == "Writing")
            {
                SetContentView(Resource.Layout.TestMe);
            }
            if (learn == "Reading" || learn == "Hearing")
            {
                SetContentView(Resource.Layout.TestMeReadHear);
            }

            num = FindViewById<EditText>(Resource.Id.txtNumber);
            name = FindViewById<EditText>(Resource.Id.txtName);
            desc = FindViewById<TextView>(Resource.Id.txtDesc);
            message = FindViewById<TextView>(Resource.Id.txtMessage);
            //button = FindViewById<Button>(Resource.Id.btnCheck);
            hidden = FindViewById<TextView>(Resource.Id.txtHidden);
            score = FindViewById<TextView>(Resource.Id.txtScore);
            total = FindViewById<TextView>(Resource.Id.txtOutOf);
            TextLabel = FindViewById<TextView>(Resource.Id.txtNameLabel);

            var language = Intent.GetStringExtra("Language");
            desc.Text = "Ongiphime ama numero";

            var type = Intent.GetStringExtra("Range");

            //var btnCheck = FindViewById<Button>(Resource.Id.btnCheck);
            //btnCheck.Click += BtnCheck_Click;

            //var btnAgain = FindViewById<Button>(Resource.Id.btnAgain);
            //btnAgain.Click += BtnAgain_Click;

            var btnHear = FindViewById<Button>(Resource.Id.btnHear);
            btnHear.Click += BtnHear_Click;

            name.KeyPress += Text_Enter;

            num.KeyPress += NumText_Enter;

            try
            {
                RangeAndValue rAndv = new RangeAndValue();
                rAndv.propRange = type;
                rAndv.setNumberValue();

                if (learn == "Writing")
                {
                    rAndv.propRange = type;
                    rAndv.setNumberValue();
                    num.Text = rAndv.propMyVal.ToString();
                    hidden.Text = rAndv.propMyVal.ToString();
                    num.Enabled = false;
                    btnHear.Visibility = ViewStates.Gone;                    
                }

                if (learn == "Reading")
                {
                    Number numb = null;
                    numb = rAndv.generatedNumber();
                    hidden.Text = numb.propValue.ToString();
                    name.Text = numb.igbo();
                    name.Enabled = false;
                    btnHear.Visibility = ViewStates.Gone;
                }

                if (learn == "Hearing")
                {
                    Number numb = null;
                    rAndv.setNumberValue();
                    numb = rAndv.generatedNumber();
                    hidden.Text = numb.propValue.ToString();
                    numb.setStemSounds();
                    numb.play(true);                    
                    name.Visibility = ViewStates.Gone;
                    TextLabel.Visibility = ViewStates.Gone;
                }
            }

            catch(Exception e)
            {
                message.Text = e.Message;
            }
            hidden.Visibility = ViewStates.Gone;    
        }

        private void NumText_Enter(object sender, View.KeyEventArgs e)
        {
            e.Handled = false;
            if (e.Event.Action == KeyEventActions.Down && e.KeyCode == Keycode.Enter)
            {
                int n = 0;

                bool isNumeric = int.TryParse(num.Text, out n);
                if ((isNumeric == false) || ((isNumeric == true) && ((n < 1) || (n > 999))))
                {
                    message.Text = "Error! Erreur! Numbers from 1 to 999! Nombre entre 1 et 999";
                }
                else
                {
                    total.Text = (++count).ToString();
                    var learn = Intent.GetStringExtra("Learn");
                    var type = Intent.GetStringExtra("Range");
                    Number numb = null;
                    RangeAndValue rAndv = new RangeAndValue();
                    rAndv.propRange = type;
                    rAndv.propMyVal = n;
                    numb = rAndv.generatedNumber();
                    bool correctAnswer = false;
                    string answer = "";

                    if (learn == "Reading" || learn == "Hearing")
                    {
                        correctAnswer = (num.Text == hidden.Text);
                        answer = hidden.Text;
                        num.Text = "";
                    }

                    if (correctAnswer == true)
                    {
                        message.Text = "Correct answer!     /     Réponse correcte";
                        score.Text = (++tot).ToString();
                        //msgBoxLabel2.Text = "";
                    }
                    else
                    {
                        if (score.Text == "")
                        {
                            score.Text = 0.ToString();
                        }
                        // numb.play();
                        message.Text = "Incorrect answer!     /     Réponse incorrecte";
                        //msgBoxLabel2.Font = new Font(msgBoxLabel2.Font.Name, 12, FontStyle.Bold | FontStyle.Underline);

                    }

                    if (learn == "Reading")
                    {
                        rAndv.setNumberValue();
                        numb = rAndv.generatedNumber();
                        num.Text = "";
                        hidden.Text = numb.propValue.ToString();
                        name.Text = numb.igbo();
                    }

                    if (learn == "Hearing")
                    {
                        rAndv.setNumberValue();
                        numb = rAndv.generatedNumber();
                        hidden.Text = numb.propValue.ToString();
                        numb.setStemSounds();
                        numb.play(true);
                    }
                    //Toast.MakeText(ApplicationContext, message, ToastLength.Long).Show();
                    //button.Enabled = false;

                }

                e.Handled = true;
            }
        }

        private void Text_Enter(object sender, View.KeyEventArgs e)
        {
            e.Handled = false;
            if (e.Event.Action == KeyEventActions.Down && e.KeyCode == Keycode.Enter)
            {
                int n = 0;
                total.Text = (++count).ToString();

                bool isNumeric = int.TryParse(num.Text, out n);
                if ((isNumeric == false) || ((isNumeric == true) && ((n < 1) || (n > 999))))
                {
                    message.Text = "Error! Erreur! Numbers from 1 to 999! Nombre entre 1 et 999";
                }
                else
                {
                    var learn = Intent.GetStringExtra("Learn");
                    var type = Intent.GetStringExtra("Range");
                    Number numb = null;
                    RangeAndValue rAndv = new RangeAndValue();
                    rAndv.propRange = type;
                    rAndv.propMyVal = n;
                    numb = rAndv.generatedNumber();
                    bool correctAnswer = false;
                    string answer = "";
                    rAndv.setNumberValue();
                    hidden.Text = rAndv.propMyVal.ToString();

                    if (learn == "Writing")
                    {
                        correctAnswer = (name.Text == numb.igbo());
                        answer = numb.igbo();
                        name.Enabled = false;
                        name.Text = "";
                    }
                   
                    if (correctAnswer == true)
                    {
                        message.Text = "Correct answer!     /     Réponse correcte";
                        score.Text = (++tot).ToString();
                        //msgBoxLabel2.Text = "";
                    }
                    else
                    {
                        if (score.Text == "")
                        {
                            score.Text = 0.ToString();
                        }
                        // numb.play();
                        message.Text = "Incorrect answer!     /     Réponse incorrecte";
                        //msgBoxLabel2.Font = new Font(msgBoxLabel2.Font.Name, 12, FontStyle.Bold | FontStyle.Underline);                      
                    }

                    if (learn == "Writing")
                    {
                        num.Text = rAndv.propMyVal.ToString();
                        name.Text = "";
                        name.Enabled = true;
                    }

                    //Toast.MakeText(ApplicationContext, message, ToastLength.Long).Show();
                    //button.Enabled = false;
                }

                e.Handled = true;
            }
        }

        private void BtnHear_Click(object sender, EventArgs e)
        {
            int n = int.Parse(hidden.Text);
            RangeAndValue rAndv = new RangeAndValue();
            Number numb = rAndv.generatedNumber(n);
            numb.setStemSounds();
            numb.play(true);
        }

        //private void BtnAgain_Click(object sender, EventArgs e)
        //{
        //    var learn = Intent.GetStringExtra("Learn");
        //    var type = Intent.GetStringExtra("Range");
        //    RangeAndValue rAndv = new RangeAndValue();
        //    rAndv.propRange = type;
        //    rAndv.setNumberValue();
        //    hidden.Text = rAndv.propMyVal.ToString();

        //    try
        //    {
        //        if (learn == "Hearing")
        //        {
        //            Number numb = null;
        //            rAndv.setNumberValue();
        //            numb = rAndv.generatedNumber();
        //            hidden.Text = numb.propValue.ToString();
        //            numb.setStemSounds();
        //            numb.play(true);
        //            num.Enabled = true;
        //        }

        //        if (learn == "Reading")
        //        {
        //            Number numb = null;
        //            numb = rAndv.generatedNumber();
        //            num.Text = "";
        //            hidden.Text = numb.propValue.ToString();
        //            name.Text = numb.igbo();
        //            num.Enabled = true;
        //        }

        //        if (learn == "Writing")
        //        {
        //            num.Text = rAndv.propMyVal.ToString();
        //            name.Text = "";
        //            name.Enabled = true;
        //        }

        //        button.Enabled = true;
        //    }
        //    catch(Exception m)
        //    {
        //        message = m.Message;
        //    }
        //}

        //private void BtnCheck_Click(object sender, EventArgs e)
        //{
        //    int n = 0;
        //    total.Text = (++count).ToString();

        //    bool isNumeric = int.TryParse(num.Text, out n);
        //    if ((isNumeric == false) || ((isNumeric == true) && ((n < 1) || (n > 999))))
        //    {
        //        message = "Error!!! Please enter a number between 1 and 999";
        //        message += "Erreur!! S'il vous plait tapez un nombre entre 1 et 999";
        //    }
        //    else
        //    {
        //        var learn = Intent.GetStringExtra("Learn");
        //        var type = Intent.GetStringExtra("Range");
        //        Number numb = null;
        //        RangeAndValue rAndv = new RangeAndValue();
        //        rAndv.propRange = type;
        //        rAndv.propMyVal = n;
        //        numb = rAndv.generatedNumber();
        //        bool correctAnswer = false;
        //        string answer = "";

        //        if (learn == "Writing")
        //        {
        //            correctAnswer = (name.Text == numb.igbo());
        //            answer = numb.igbo();
        //            name.Enabled = false;
        //            name.Text = "";
        //        }
        //        if (learn == "Reading" || learn == "Hearing")
        //        {
        //            correctAnswer = (num.Text == hidden.Text);
        //            answer = hidden.Text;
        //            num.Enabled = false;
        //            num.Text = "";
        //        }

        //        if (correctAnswer == true)
        //        {
        //            message = "Correct answer!     /     Réponse correcte";
        //            score.Text = (++tot).ToString();
        //            //msgBoxLabel2.Text = "";
        //        }
        //        else
        //        {
        //            if(score.Text == "")
        //            {
        //                score.Text = 0.ToString();
        //            }
        //            // numb.play();
        //            message = "Incorrect/e! Correct answer is / Bonne réponse est ";
        //            //msgBoxLabel2.Font = new Font(msgBoxLabel2.Font.Name, 12, FontStyle.Bold | FontStyle.Underline);
        //            if (learn == "Writing")
        //            {
        //                //itonTextTextBox.Select();
        //                message += numb.propValue + " : " + answer; 
        //                //message2
        //            }
        //            if (learn == "Reading")
        //            {
        //                //itonTextTextBox.Select();
        //                message += hidden.Text + " : " + name.Text; 
        //                //message2
        //            }
        //            if (learn == "Hearing")
        //            {
        //                //itonTextTextBox.Select();
        //                message += hidden.Text; 
        //                //message2
        //            }
        //        }
        //        Toast.MakeText(ApplicationContext, message, ToastLength.Long).Show();
        //        button.Enabled = false;
        //    }
        //}
    }
}