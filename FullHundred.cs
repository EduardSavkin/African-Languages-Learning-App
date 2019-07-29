using Android.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgboNumbers
{
    class FullHundred : Number
    {
        private MediaPlayer player;
        Android.Media.MediaPlayer player1 = new Android.Media.MediaPlayer();

        public override string igbo()
        {
            int m = propValue / 100;
            string result = propStem[10];
            if (((m >= 2) && (m <= 4)) || ((m >= 7) && (m <= 8)))
            { result = result + " " + "a" + propStem[m - 1]; }
            if (((m >= 5) && (m <= 6)) || (m == 9))
            { result = result + " " + "i" + propStem[m - 1]; }
            return (result);

        }

        public override void setStemSounds()
        {
            propStemSounds[0] = propSoundFolder + "/Iton111/wav/Iton111_03_nari.wav";
            propStemSounds[1] = propSoundFolder + "/Iton222/wav/Iton222_03_nari_abuo.wav";
            propStemSounds[2] = propSoundFolder + "/Iton333/wav/Iton333_03_nari_ato.wav";
            propStemSounds[3] = propSoundFolder + "/Iton444/wav/Iton444_03_nari_ano.wav";
            propStemSounds[4] = propSoundFolder + "/Iton555/wav/Iton555_03_nari_ise.wav";
            propStemSounds[5] = propSoundFolder + "/Iton666/wav/Iton666_03_nari_isii.wav";
            propStemSounds[6] = propSoundFolder + "/Iton777/wav/Iton777_03_nari_asaa.wav";
            propStemSounds[7] = propSoundFolder + "/Iton888/wav/Iton888_03_nari_asato.wav";
            propStemSounds[8] = propSoundFolder + "/Iton999/wav/Iton999_03_nari_iteghete.wav";
        }
        public async override void play(bool alone)
        {
            try
            {
                setStemSounds();
                string soundResult = propStemSounds[(propValue / 100) - 1];

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
