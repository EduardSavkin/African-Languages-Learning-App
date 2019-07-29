using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgboNumbers
{
    class RangeAndValue
    {
        private string range;
        private int myVal;

        public string propRange
        {
            set { range = value; }
            get { return range; }
        }

        public int propMyVal
        {
            set { myVal = value; }
            get { return myVal; }
        }

        public void setNumberValue()
        {
            Random rnd = new Random();
            myVal = 0;
            if (range == "1, 2, 3,...., 9")
            {
                myVal = rnd.Next(1, 10);
            }

            if (range == "10, 20, 30,...., 90")
            {
                myVal = 10 * (rnd.Next(1, 10));
            }

            if (range == "11, 12, 13,...., 21, 22,...., 97, 98, 99")
            {
                myVal = (10 * (rnd.Next(1, 10))) + rnd.Next(1, 10);
            }

            if (range == "100, 200, 300,...., 900")
            {
                myVal = 100 * (rnd.Next(1, 10));
            }

            if (range == "101, 102, 103,...., 997, 998, 999")
            {
                myVal = (100 * (rnd.Next(1, 10))) + (10 * (rnd.Next(1, 10))) + rnd.Next(1, 10);
            }

        }

        public Number generatedNumber()
        {
            Number result = null;

            if (range == "1, 2, 3,...., 9")
            {
                UnitN unit = new UnitN();
                unit.propValue = myVal;
                result = unit;
            }

            if (range == "10, 20, 30,...., 90")
            {
                FullTenth fullTen = new FullTenth();
                fullTen.propValue = myVal;
                result = fullTen;
            }

            if (range == "11, 12, 13,...., 21, 22,...., 97, 98, 99")
            {
                HalfTenth halfTen = new HalfTenth();
                halfTen.propValue = myVal;
                result = halfTen;
            }

            if (range == "100, 200, 300,...., 900")
            {
                FullHundred fullHun = new FullHundred();
                fullHun.propValue = myVal;
                result = fullHun;
            }

            if (range == "101, 102, 103,...., 997, 998, 999")
            {
                HalfHundred halfHun = new HalfHundred();
                halfHun.propValue = myVal;
                result = halfHun;
            }
            return (result);
        }

        public Number generatedNumber(int n)
        {
            Number result = null;

            if ((n >= 1) && (n <= 9))
            {
                UnitN unit = new UnitN();
                unit.propValue = n;
                result = unit;
            }

            if (((n % 10) == 0) & (n >= 10) & (n <= 99))
            {
                FullTenth fullTen = new FullTenth();
                fullTen.propValue = n;
                result = fullTen;
            }

            if (((n % 10) != 0) & (n >= 10) & (n <= 99))
            {
                HalfTenth halfTen = new HalfTenth();
                halfTen.propValue = n;
                result = halfTen;
            }

            if (((n % 100) == 0) & (n >= 100) & (n <= 999))
            {
                FullHundred fullHun = new FullHundred();
                fullHun.propValue = n;
                result = fullHun;
            }

            if (((n % 100) != 0) & (n >= 100) & (n <= 999))
            {
                HalfHundred halfHun = new HalfHundred();
                halfHun.propValue = n;
                result = halfHun;
            }
            return (result);
        }

    }
}
