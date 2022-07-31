using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//https://www.is.umk.pl/~grochu/wiki/doku.php?id=zajecia:po:csharp_dziedziczenie

// myattempt2 branch zawiera więcej kodu z ze spotkania 05.07

namespace ZadanieFirma
{
    public class Kontrakt
    {
        public decimal Stawka { get; set; }
        public int Nadgodziny { get; set; }

        public Kontrakt() { }

        public Kontrakt(decimal stawka, int nadgodziny)
        {
            Stawka = stawka;
            Nadgodziny = nadgodziny;
        }
        public virtual decimal Pensja()
        {
            return Stawka;
        }
    }

    public class Pracownik
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public Kontrakt Kontrakt { get; set; }

        public Pracownik(string imie, string nazwisko)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Kontrakt = new Staz();

        }
        private decimal DajPensje()
        {
            return Math.Round(Kontrakt.Pensja(), 2);
        }

        public void ZmianaKontraktu()
        {
            Kontrakt = new Etat();
        }

        public override string ToString()
        {
            return $"Imię: {Imie}, Nazwisko: {Nazwisko}, pensja: {DajPensje()}";
        }
    }

    public class Staz : Kontrakt
    {
        public Staz()
        {
            Stawka = 1000;
        }
        public override decimal Pensja() { return Stawka; }
    }
    public class Etat : Kontrakt
    {
        public Etat()
        {
            Stawka = 5000;
            Nadgodziny = 0;
        }

        public override decimal Pensja()
        {
            return (Stawka + Nadgodziny) * (Stawka / 60);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Pracownik pracownik = new Pracownik("Andrzej", "Kotynski");
            Console.WriteLine(pracownik.ToString());
            pracownik.ZmianaKontraktu();
            Console.WriteLine(pracownik.ToString());
        }
    }
}