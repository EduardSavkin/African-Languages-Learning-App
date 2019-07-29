using Android.Media;
using Java.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgboNumbers
{
    abstract class WordIgbo
    {
        File path = new File(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDcim), "/Iton_App/VoiceRoots/Igbo/Words");

        private MediaPlayer player;

        private static string[] stemSounds = new String[15];

        private string[] stemEnglish = new String[15];

        private string[] stemFrench = new String[15];

        private int val;

        public int propValue
        {
            set { val = value; }
            get { return val; }
        }

        public string propSoundFolder
        {
            get { return path.ToString(); }
        }

        public void setSoundFolder(string folderPathPar)
        {
            folderPathPar = path.ToString();
        }

        public string[] propStemSounds
        {
            get { return stemSounds; }
        }

        public string[] propStemEnglish
        {
            get { return stemEnglish; }
        }

        public string[] propStemFrench
        {
            get { return stemFrench; }
        }

        public bool checkIton(string s)
        {
            setStemEnglish();
            setStemFrench();
            return ((s.ToUpper()==propStemEnglish[propValue]) || (s.ToUpper() == propStemFrench[propValue]));
        }

        public void play()
        {
            try
            {
                setStemSounds();
                string soundResult = propStemSounds[propValue];

                if (player == null)
                {
                    player = player ?? new MediaPlayer();
                }
                else
                {
                    player.Reset();
                }
                player.SetDataSource(soundResult);
                player.Prepare();
                player.Start();
            }
            catch (Exception e)
            { }
        }

        abstract public void setStemSounds();
        abstract public void setStemEnglish();
        abstract public void setStemFrench();

    }
}
