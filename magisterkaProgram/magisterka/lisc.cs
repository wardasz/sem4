using System;
using System.Collections.Generic;
using System.Text;

namespace magisterka
{
    class lisc
    {
        private char znak;
        private double prawdopodobienstwo;
        private char bit;
        private lisc ojciec;

        public lisc(char a, double b)
        {
            znak = a;
            prawdopodobienstwo = b;
            ojciec = null;
        }

        //pilnować, a ma niższe prawdopodobieństwo
        public lisc(lisc a, lisc b)
        {
            prawdopodobienstwo = a.dajPrawdopodobienstwo() + b.dajPrawdopodobienstwo();
            a.ustawBit('0');
            b.ustawBit('1');
            a.ustawOjca(this);
            b.ustawOjca(this);
        }

        public char dajZnak()
        {
            return znak;
        }

        public double dajPrawdopodobienstwo()
        {
            return prawdopodobienstwo;
        }

        public int dajBit()
        {
            return bit;
        }

        public lisc dajOjca()
        {
            return ojciec;
        }

        public void ustawBit(char a)
        {
            bit = a;
        }

        public void ustawOjca(lisc a)
        {
            ojciec = a;
        }

        public int porownaj(lisc a)
        {
            if (prawdopodobienstwo < a.dajPrawdopodobienstwo())
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }

        public string dajKod()
        {
            if (ojciec == null)
            {
                return bit.ToString();
            }
            else
            {
                return ojciec.dajKod() + bit.ToString();
            }
            
        }
    }
}
