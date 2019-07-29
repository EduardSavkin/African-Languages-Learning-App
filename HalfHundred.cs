using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgboNumbers
{
    class HalfHundred : Number
    {
        public override string igbo()
        {
            int m = propValue / 100;
            int n = propValue % 100;
            FullHundred fh = new FullHundred();
            string prefix = "na";
            Number numb = null;
            fh.propValue = m * 100;

            if ((n % 10)==0)
            {
                FullTenth ft = new FullTenth();
                ft.propValue = n;
                numb = ft;
            }
            else
            {
                HalfTenth ht = new HalfTenth();
                ht.propValue = n;
                numb = ht;
            }
            string result = fh.igbo() +" "+ prefix+" " + numb.igbo();
            return (result);
        }

        public override void setStemSounds()
        {
        }
        public override void play(bool alone)
        {
            int m = propValue / 100;
            int n = propValue % 100;
            FullHundred fh = new FullHundred();
            Number numb = null;

            fh.propValue = m * 100;

            if ((n % 10) == 0)
            {
                FullTenth ft = new FullTenth();
                ft.propValue = n;
                numb = ft;
            }
            else
            {
                HalfTenth ht = new HalfTenth();
                ht.propValue = n;
                numb = ht;
            }
            fh.play(true);
            numb.play(false);
        }
    }
}
