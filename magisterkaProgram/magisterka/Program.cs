using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace magisterka
{
    class Program
    {
        static string sciezkaBazowa;
        static string tekst;
        static List<znak> znaki;
        static List<lisc> liscie;

        static void Main(string[] args)
        {
            var s = new FileInfo(Directory.GetCurrentDirectory());
            var s2 = s.Directory.Parent.Parent;
            sciezkaBazowa = s2.ToString();

            znaki = new List<znak>();
            liscie = new List<lisc>();

            string nazwa = "wiki001";

            wczytajTekst(nazwa);
            policzZnaki();
            policzPrawdopodobienstwa();
            znaki.Sort((x, y) => x.porownaj(y));
            zapiszPrawdopodobienstwa(nazwa);
            wypiszZnaki();
            stworzDrzewo();
            stwozKody();
            zapiszKody(nazwa);
            wypiszKody();

            Console.ReadKey();
        }

        static void wczytajTekst(string nazwa)
        {
            String sciezka = sciezkaBazowa + "\\teksty\\"+ nazwa +".txt";
            tekst = System.IO.File.ReadAllText(sciezka);
        }

        static void zapiszPrawdopodobienstwa(string nazwa)
        {
            String sciezka = sciezkaBazowa + "\\prawdopodobienstwa\\" + nazwa + ".txt";

            using (StreamWriter sw = File.CreateText(sciezka))
            {
                foreach (znak z in znaki)
                {
                    sw.WriteLine(z.dajZnak() + "-" + z.dajWystepowanie());
                }
            }
        }

        static void zapiszKody(string nazwa)
        {
            String sciezka = sciezkaBazowa + "\\kody\\" + nazwa + ".txt";

            using (StreamWriter sw = File.CreateText(sciezka))
            {
                foreach (znak z in znaki)
                {
                    sw.WriteLine(z.dajZnak() + "-" + z.dajKod());
                }
            }
        }

        static void policzZnaki()
        {
            znaki = new List<znak>();

            foreach (char z in tekst)
            {
                bool dodany = false;
                foreach(znak Z in znaki)
                {
                    if (Z.dajZnak() == z) {
                        Z.podbij();
                        dodany = true;
                    }
                }
                if (dodany == false)
                {
                    znak nowy = new znak(z);
                    nowy.podbij();
                    znaki.Add(nowy);
                }
            }
        }

        static void policzPrawdopodobienstwa()
        {
            int suma = 0;
            foreach (znak z in znaki) suma = suma + z.dajIlosc();
            foreach (znak z in znaki) z.policzWystepowanie(suma);
        }

        static void wypiszZnaki() {
            foreach(znak z in znaki)
            {
                Console.WriteLine(z.dajZnak() + " - " + z.dajIlosc() + " - " + z.dajWystepowanie());
            }
        }

        static void wypiszKody()
        {
            foreach (znak z in znaki)
            {
                Console.WriteLine(z.dajZnak() + " - " + z.dajKod());
            }
        }

        static void stworzDrzewo()
        {
            liscie = new List<lisc>();
            List<lisc> drzewo = new List<lisc>();
            foreach (znak z in znaki)
            {
                lisc nowy = new lisc(z.dajZnak(), z.dajWystepowanie());
                liscie.Add(nowy);
                drzewo.Add(nowy);
            }

            while (drzewo.Count > 1)
            {
                drzewo.Sort((x, y) => x.porownaj(y));
                lisc a = drzewo.ElementAt(0);
                lisc b = drzewo.ElementAt(1);
                drzewo.Remove(a);
                drzewo.Remove(b);
                lisc nowy = new lisc(a, b);
                drzewo.Add(nowy);
            }
        }

        static void stwozKody()
        {
            foreach(znak z in znaki)
            {
                foreach(lisc l in liscie)
                {
                    if (z.dajZnak() == l.dajZnak())
                    {
                        z.ustawKod(l.dajKod());
                        break;
                    }
                }
            }
        }
    }
}
