using Android.Media;
using Java.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgboNumbers
{
    class UnitN : Number
    {
        private MediaPlayer player;

        public override string igbo()
        {
            string result = propStem[propValue-1];
            if ( ((propValue >= 2) && (propValue <= 4)) || ((propValue >= 7) && (propValue <= 8)))
            { result = "a" + result; }
            if (((propValue >= 5) && (propValue <= 6)) || (propValue >= 9))
            { result = "i" + result; }
            return (result);
        }

        public override void setStemSounds()
        {
            propStemSounds[0] = propSoundFolder + "/Iton111/wav/Iton111_01_otu.wav";
            propStemSounds[1] = propSoundFolder + "/Iton222/wav/Iton222_01_abuo.wav";
            propStemSounds[2] = propSoundFolder + "/Iton333/wav/Iton333_01_ato.wav";
            propStemSounds[3] = propSoundFolder + "/Iton444/wav/Iton444_01_ano.wav";
            propStemSounds[4] = propSoundFolder + "/Iton555/wav/Iton555_01_ise.wav";
            propStemSounds[5] = propSoundFolder + "/Iton666/wav/Iton666_01_isii.wav";
            propStemSounds[6] = propSoundFolder + "/Iton777/wav/Iton777_01_asaa.wav";
            propStemSounds[7] = propSoundFolder + "/Iton888/wav/Iton888_01_asato.wav";
            propStemSounds[8] = propSoundFolder + "/Iton999/wav/Iton999_01_iteghete.wav";

            propStemSounds[9] = propSoundFolder + "/Iton111/wav/Iton111_04_na_otu.wav";
            propStemSounds[10] = propSoundFolder + "/Iton222/wav/Iton222_04_na_abuo.wav";
            propStemSounds[11] = propSoundFolder + "/Iton333/wav/Iton333_04_na_ato.wav";
            propStemSounds[12] = propSoundFolder + "/Iton444/wav/Iton444_04_na_ano.wav";
            propStemSounds[13] = propSoundFolder + "/Iton555/wav/Iton555_04_na_ise.wav";
            propStemSounds[14] = propSoundFolder + "/Iton666/wav/Iton666_04_na_isii.wav";
            propStemSounds[15] = propSoundFolder + "/Iton777/wav/Iton777_04_na_asaa.wav";
            propStemSounds[16] = propSoundFolder + "/Iton888/wav/Iton888_04_na_asato.wav";
            propStemSounds[17] = propSoundFolder + "/Iton999/wav/Iton999_04_na_iteghete.wav";
        }

        public async override void play(bool alone)
        {
            try
            {
                setStemSounds();
                string soundResult = propStemSounds[propValue - 1];
                if (alone == false) { soundResult = propStemSounds[9 + propValue - 1]; }

                if (player == null)
                {
                    player = player ?? new MediaPlayer();
                }
                else
                {
                    player.Reset();
                }
                await player.SetDataSourceAsync(soundResult);
                player.Prepare();
                player.Start();
            }
            catch(Exception e)
            { }
        }
    }
}
