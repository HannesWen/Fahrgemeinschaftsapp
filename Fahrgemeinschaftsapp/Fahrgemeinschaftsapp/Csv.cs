using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fahrgemeinschaftsapp
{
    public class Csv
    {

        public static void Hauptmenue()
        {
            Console.Clear();
            Console.WriteLine(" 1. Benutzer anlegen");
            Console.WriteLine(" 2. Nach User suchen");
            Console.WriteLine(" 3. Program beenden");

            bool keineFehler = false;
            do
            {
                try
                {
                    int hauptmenueAuswahl = int.Parse(Console.ReadLine());
                    switch (hauptmenueAuswahl)
                    {
                        case 1:
                            Personen.BenutzerAnlegen();
                            break;
                        case 2:
                            Personen.BenutzerAusgeben();
                            break;
                        case 3:
                            ProgrammBeenden();
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Da schreibt man schon zahlen daneben und du gibst trozdem was anderes aus...");
                }
                catch (Exception)
                {
                    Console.WriteLine("Irgendwas lief da richtig schief!");
                }
                finally
                {
                    keineFehler = true;
                }
            } while (keineFehler == false);
        }

        public static void ProgrammBeenden()
        {
            Console.ReadKey();
        }
    }
}
