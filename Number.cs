using Java.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgboNumbers
{
    abstract class Number
    {
        File path = new File(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDcim), "/Iton_App/VoiceRoots/Igbo/Numbers");

        private static string[] stemSounds = new String[20];

        private int val;

        private string[] stem = { "otu", "buo", "to", "no", "se", "sii", "saa", "sato", "teghete", "ri", "nari" };


        public int propValue
        {
            set { val = value; }
            get { return val; }
        }

        public string[] propStem
        {
            get { return stem; }
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

        abstract public string igbo();

        abstract public void play(bool alone);

        abstract public void setStemSounds();

    }
}
