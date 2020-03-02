using System;
using System.Collections.Generic;
using System.Text;

namespace magisterka
{
    class znak
    {
        private char symbol;
        private int ilosc;
        private double wystepowanie;
        private string kod;

        public znak(char a)
        {
            symbol = a;
            ilosc = 0;
        }

        public char dajZnak()
        {
            return symbol;
        }

        public int dajIlosc()
        {
            return ilosc;
        }

        public double dajWystepowanie()
        {
            return wystepowanie;
        }

        public string dajKod()
        {
            return kod;
        }

        public void podbij()
        {
            ilosc++;
        }

        public void policzWystepowanie(int suma)
        {
            wystepowanie = (double)ilosc / (double)suma;
        }

        public void ustawKod(string a)
        {
            kod = a;
        }

        public int porownaj(znak a)
        {
            if (wystepowanie < a.dajWystepowanie())
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
    }
}
