using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace Fahrgemeinschaftsapp
{
    public class Personen
    {
        public int Id { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Himmelsrichtung { get; set; }
        public int Entfernung { get; set; }
        public bool Fahrer { get; set; }

        public Personen(int id, string vorname, string nachname, string himmelsrichtung, int entfernung, bool fahrer)
        {
            Id = id;
            Vorname = vorname;
            Nachname = nachname;
            Himmelsrichtung = himmelsrichtung;
            Entfernung = entfernung;
            Fahrer = fahrer;
        }
        public override string ToString()
        {
            return $"{Id};{Vorname};{Nachname};{Himmelsrichtung};{Entfernung};{Fahrer}";
        }

        public static void BenutzerAnlegen()
        {
            string datei = "Person.csv";

            if (File.Exists(datei) == true)
            {
                Console.WriteLine("Welche Id hast du?");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Wie lautet dein Vorname?");
                string vorname = Console.ReadLine();
                Console.WriteLine("Wie lautet dein Nachname?");
                string nachname = Console.ReadLine();
                Console.WriteLine("Aus welcher Himmelsrichtung kommst du?");
                string himmelsrichtung = Console.ReadLine();
                Console.WriteLine("Wie weit hast du es bis Weikersheim?");
                int entfernung = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("bist du ein fahrer? true/ false");
                bool fahrer = bool.Parse(Console.ReadLine());

                List<Personen> List_Person = new List<Personen>() { new Personen(id,vorname,nachname,himmelsrichtung,entfernung,fahrer) };

                File.AppendAllLines(datei, List_Person.Select(e => e.ToString()));
            }

            else if (File.Exists(datei) == false)
            {
                Console.WriteLine("Welche Id hast du?");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Wie lautet dein Vorname?");
                string vorname = Console.ReadLine();
                Console.WriteLine("Wie lautet dein Nachname?");
                string nachname = Console.ReadLine();
                Console.WriteLine("Aus welcher Himmelsrichtung kommst du?");
                string himmelsrichtung = Console.ReadLine();
                Console.WriteLine("Wie weit hast du es bis Weikersheim?");
                int entfernung = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("bist du ein fahrer? true/ false");
                bool fahrer = bool.Parse(Console.ReadLine());

                List<Personen> List_Person = new List<Personen>() { new Personen(id,vorname,nachname,himmelsrichtung,entfernung,fahrer) };

                File.WriteAllLines(datei, List_Person.Select(e => e.ToString()));
            }
            Console.ReadLine();
            Console.WriteLine("Du wirst zum Hauptmenü weitergeleitet");
            Thread.Sleep(1000);
            Csv.Hauptmenue();
        }

        public static void BenutzerAusgeben()
        {
            int id;
            string datei = "Person.csv";

            List<string> testlist = File.ReadAllLines(datei).ToList();
            List<string[]> users = new List<string[]>();

            foreach (string test in testlist)
            {
                users.Add(test.Split(';'));
            }

            bool keineFehler = false;
            do
            {
                try
                {
                    Console.WriteLine("Nach welchem Nutzer möchtest du suchen? Bitte gebe mir die Id");
                    id = Convert.ToInt32(Console.ReadLine());
                    List<string> eigenschaften = new List<string> { "Id", "Vorname", "Nachname", "Himmelsrichtung", "Km nach Weikersheim", "Fahrer" };
                    string[] user = users.First(e => Convert.ToInt32(e[0]) == id);
                    int counter = 0;
                    foreach (string test in user)
                    {
                        Console.WriteLine();
                        Console.WriteLine(eigenschaften[counter]);
                        Console.WriteLine(test);
                        counter++;
                    }
                    keineFehler = true;
                }
                catch
                {
                    Console.WriteLine("Den User gibts hier nüsch, versuchs nochmal.");
                }
            } while (keineFehler== false);
            Console.ReadLine();
            Console.WriteLine("Du wirst zum Hauptmenü weitergeleitet");
            Thread.Sleep(1000);
            Csv.Hauptmenue();
        }
    }
}
