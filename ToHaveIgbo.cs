using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgboNumbers
{
    class ToHaveIgbo : WordIgbo

    {

        public override void setStemSounds()
        {
            propStemSounds[0] = propSoundFolder + "/ToHave/wav/0_have.wav";
            propStemSounds[1] = propSoundFolder + "/ToHave/wav/1_have.wav";
            propStemSounds[2] = propSoundFolder + "/ToHave/wav/2_have.wav";
            propStemSounds[3] = propSoundFolder + "/ToHave/wav/3_have.wav";
            propStemSounds[4] = propSoundFolder + "/ToHave/wav/4_have.wav";
            propStemSounds[5] = propSoundFolder + "/ToHave/wav/5_have.wav";
            propStemSounds[6] = propSoundFolder + "/ToHave/wav/6_have.wav";
            propStemSounds[7] = propSoundFolder + "/ToHave/wav/7_have.wav";
            propStemSounds[8] = propSoundFolder + "/ToHave/wav/8_have.wav";
            propStemSounds[9] = propSoundFolder + "/ToHave/wav/9_have.wav";
        }

        public override void setStemEnglish()
        {
            propStemEnglish[0] = "I HAVE A HOME";
            propStemEnglish[1] = "I DO NOT HAVE A HOME";
            propStemEnglish[2] = "I HAD A HOME";
            propStemEnglish[3] = "I DID NOT HAVE A HOME";
            propStemEnglish[4] = "I WILL HAVE A HOME";
            propStemEnglish[5] = "I WILL NOT HAVE A HOME";
            propStemEnglish[6] = "I USUALLY HAVE A HOME";
            propStemEnglish[7] = "I DO NOT USUALLY HAVE A HOME";
            propStemEnglish[8] = "I USUALLY HAD A HOME";
            propStemEnglish[9] = "I DID NOT USUALLY HAVE A HOME";
        }

        public override void setStemFrench()
        {
            propStemFrench[0] = "J'AI UN DOMICILE";
            propStemFrench[1] = "JE N'AI PAS DE DOMICILE";
            propStemFrench[2] = "J'AVAIS UN DOMICILE";
            propStemFrench[3] = "JE N'AVAIS PAS DE DOMICILE";
            propStemFrench[4] = "J'AURAI UN DOMICILE";
            propStemFrench[5] = "JE N'AURAI PAS DE DOMICILE";
            propStemFrench[6] = "J'AI SOUVENT UN DOMICILE";
            propStemFrench[7] = "JE N'AI PAS SOUVENT DE DOMICILE";
            propStemFrench[8] = "J'AVAIS SOUVENT UN DOMICILE";
            propStemFrench[9] = "JE N'AVAIS PAS SOUVENT DE DOMICILE";
        }

    }
}
