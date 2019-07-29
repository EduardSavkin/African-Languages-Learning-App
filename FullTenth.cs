using Android.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgboNumbers
{
    class FullTenth : Number
    {
        private MediaPlayer player;
        Android.Media.MediaPlayer player1 = new Android.Media.MediaPlayer();

        public override string igbo()
        {
            int m = propValue / 10;
            string result="i"+propStem[9];
            if (((m >= 2) && (m <= 4)) || ((m >= 7) && (m<= 8)))
            { result = result + " " + "a" + propStem[m - 1]; }
            if (((m >= 5) && (m <= 6)) || (m ==9))
            { result = result + " " + "i" + propStem[m - 1]; }
            return (result);
        }

        public override void setStemSounds()
        {
            propStemSounds[0] = propSoundFolder + "/Iton111/wav/Iton111_02_iri.wav";
            propStemSounds[1] = propSoundFolder + "/Iton222/wav/Iton222_02_iri_abuo.wav";
            propStemSounds[2] = propSoundFolder + "/Iton333/wav/Iton333_02_iri_ato.wav";
            propStemSounds[3] = propSoundFolder + "/Iton444/wav/Iton444_02_iri_ano.wav";
            propStemSounds[4] = propSoundFolder + "/Iton555/wav/Iton555_02_iri_ise.wav";
            propStemSounds[5] = propSoundFolder + "/Iton666/wav/Iton666_02_iri_isii.wav";
            propStemSounds[6] = propSoundFolder + "/Iton777/wav/Iton777_02_iri_asaa.wav";
            propStemSounds[7] = propSoundFolder + "/Iton888/wav/Iton888_02_iri_asato.wav";
            propStemSounds[8] = propSoundFolder + "/Iton999/wav/Iton999_02_iri_iteghete.wav";

            propStemSounds[9] = propSoundFolder + "/Iton111/wav/Iton111_05_na_iri.wav";
            propStemSounds[10] = propSoundFolder + "/Iton222/wav/Iton222_05_na_iri_abuo.wav";
            propStemSounds[11] = propSoundFolder + "/Iton333/wav/Iton333_05_na_iri_ato.wav";
            propStemSounds[12] = propSoundFolder + "/Iton444/wav/Iton444_05_na_iri_ano.wav";
            propStemSounds[13] = propSoundFolder + "/Iton555/wav/Iton555_05_na_iri_ise.wav";
            propStemSounds[14] = propSoundFolder + "/Iton666/wav/Iton666_05_na_iri_isii.wav";
            propStemSounds[15] = propSoundFolder + "/Iton777/wav/Iton777_05_na_iri_asaa.wav";
            propStemSounds[16] = propSoundFolder + "/Iton888/wav/Iton888_05_na_iri_asato.wav";
            propStemSounds[17] = propSoundFolder + "/Iton999/wav/Iton999_05_na_iri_iteghete.wav";
        }
        public async override void play(bool alone)
        {
            try
            {
                setStemSounds();
                string soundResult = propStemSounds[(propValue / 10) - 1];
                if (alone == false) { soundResult = propStemSounds[9 + (propValue / 10) - 1]; }

                if (player == null)
                {
                    player = player ?? new MediaPlayer();
                }
                else
                {
                    player.Reset();
                }

                new System.Threading.Thread(async () => {

                    await player1.SetDataSourceAsync(soundResult);

                    player1.Prepare();
                    player1.Start();
                }).Start();

                byte[] TotalBytes = System.IO.File.ReadAllBytes(soundResult);
                double bitrate = (BitConverter.ToInt32(new[] { TotalBytes[28], TotalBytes[29], TotalBytes[30], TotalBytes[31] }, 0) * 8);
                double duration = (TotalBytes.Length - 8) * 8 / bitrate;
                int durationInt = Convert.ToInt32(duration * 1000);
                System.Threading.Thread.Sleep(durationInt);

                if (player1 == null)
                {
                    player1 = player1 ?? new MediaPlayer();
                }
                else
                {
                    player1.Reset();
                }

                await player.SetDataSourceAsync(soundResult);
                //player.Prepare();
                //player.Start();
            }
            catch(Exception e)
            { }
        }
    }
}
