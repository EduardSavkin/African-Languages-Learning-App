using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgboNumbers
{
    class HalfTenth : Number
    {
        public override string igbo()
        {
            int m = propValue / 10;
            int n = propValue % 10;
            FullTenth ft = new FullTenth();
            UnitN un = new UnitN();
            string prefix = " na ";
            ft.propValue = m * 10;
            un.propValue = n;
            string result = ft.igbo() + prefix + un.igbo();
            return (result);
        }

        public override void setStemSounds()
        {
        }
        public override void play(bool alone)
        {
            int m = propValue / 10;
            int n = propValue % 10;
            FullTenth ft = new FullTenth();
            UnitN un = new UnitN();

            ft.propValue = m * 10;
            un.propValue = n;

            if (alone == true) { ft.play(true); }
            if (alone == false) { ft.play(false); }
            un.play(false);
        }
    }
}
