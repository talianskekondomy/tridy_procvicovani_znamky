using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tridy_procvicovani
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Zadejte jméno studenta:");
            Student s1 = new Student(); // implicitní konstruktor
            s1.Jmeno = Console.ReadLine();

            Student s2 = new Student();
            Console.WriteLine("Zadejte jméno druhého studenta:");
            s2.Jmeno = Console.ReadLine();

            Student s3 = new Student();
            Console.WriteLine("Zadejte jméno třetího studenta:");
            s3.Jmeno = Console.ReadLine();

            s1.kontrolaPrumeru();
            s2.kontrolaPrumeru();
            s3.kontrolaPrumeru();


            Console.WriteLine("Počet studentů: " + Student.seznamStudentu);

            // Zavolání metody pro zobrazení všech studentů
            Student.ZobrazVsechnyStudenty();

            // Možnost upravit známky
            Console.WriteLine("Zadejte jméno studenta, kterému chcete upravit známky: ");

            string hledJmeno = Console.ReadLine();

            Student uprStudent = Student.seznamVsechStudentu.FirstOrDefault(s => s.Jmeno == hledJmeno);

            if (uprStudent != null)
            {
                uprStudent.UpravZnamky();
            }
            else
            {
                Console.WriteLine("Student nenalezen.");
            }

            Console.ReadKey();
        }
    }

    public class Student
    {
        // Atributy
        public string Jmeno;
        public double PrumernaZnamka;
        public List<int> znamky = new List<int>();

        // Statická proměnná pro počet studentů
        public static int seznamStudentu;

        // Statický seznam pro uchování všech studentů
        public static List<Student> seznamVsechStudentu = new List<Student>();

        public Student()
        {
            seznamStudentu++;
            seznamVsechStudentu.Add(this);
        }

        public void PridatZnamku(int znamka)
        {
            Console.WriteLine("Zadejte 5 známek:");
            try
            {
                for (int i = 0; i < 5; i++)
                {
                    znamky.Add(Convert.ToInt32(Console.ReadLine()));
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Chyba formátování");
            }
            catch (Exception)
            {
                Console.WriteLine("Něco se pokazilo");
            }
            finally
            {
                Console.WriteLine("Program bude ukončen");
            }
        }

        // Metoda pro zobrazení informací o studentovi
        public void ZobrazInfo()
        {
            Console.WriteLine("Jméno studenta: " + Jmeno + "\nJeho průměr: " + PrumernaZnamka);
        }

        public void kontrolaPrumeru()
        {
            if (znamky.Count == 0)
            {
                Console.WriteLine("Žádné známky nebyly zadány.");
                return;
            }

            double prumer = znamky.Average();
            try
            {
                if (prumer < 1.5)
                {
                    Console.WriteLine("Nárok na stipendium");
                }
                else
                {
                    Console.WriteLine("Nemá nárok na stipendium");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Něco se pokazilo");
            }
        }

        // Metoda pro zobrazení jmen všech studentů
        public static void ZobrazVsechnyStudenty()
        {
            Console.WriteLine("Seznam všech studentů:");
            foreach (var student in seznamVsechStudentu)
            {
                Console.WriteLine(student.Jmeno);
            }
        }

        // Nová metoda pro úpravu známek (mazání, editace)
        public void UpravZnamky()
        {
            if (znamky.Count == 0)
            {
                Console.WriteLine("Tento student nemá žádné známky k úpravě.");
                return;
            }

            while (true)
            {
                Console.WriteLine("\nAktuální známky studenta " + Jmeno + ": " + string.Join(", ", znamky));
                Console.WriteLine("Vyberte akci:");
                Console.WriteLine("1 - Smazat známku");
                Console.WriteLine("2 - Upravit známku");
                Console.WriteLine("3 - Přidat novou známku");
                Console.WriteLine("4 - Ukončit úpravy");
                string volba = Console.ReadLine();

                switch (volba)
                {
                    case "1":
                        Console.WriteLine("Zadejte index známky k odstranění (0-" + (znamky.Count - 1) + "):");
                        if (int.TryParse(Console.ReadLine(), out int indexSmazani) && indexSmazani >= 0 && indexSmazani < znamky.Count)
                        {
                            znamky.RemoveAt(indexSmazani);
                            Console.WriteLine("Známka byla odstraněna.");
                        }
                        else
                        {
                            Console.WriteLine("Neplatný index.");
                        }
                        break;

                    case "2":
                        Console.WriteLine("Zadejte index známky k úpravě (0-" + (znamky.Count - 1) + "):");
                        if (int.TryParse(Console.ReadLine(), out int indexUpravy) && indexUpravy >= 0 && indexUpravy < znamky.Count)
                        {
                            Console.WriteLine("Zadejte novou hodnotu známky:");
                            if (int.TryParse(Console.ReadLine(), out int novaZnamka))
                            {
                                znamky[indexUpravy] = novaZnamka;
                                Console.WriteLine("Známka byla upravena.");
                            }
                            else
                            {
                                Console.WriteLine("Neplatná hodnota.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Neplatný index.");
                        }
                        break;

                    case "3":
                        Console.WriteLine("Zadejte novou známku:");
                        if (int.TryParse(Console.ReadLine(), out int novaZnamkaPridat))
                        {
                            znamky.Add(novaZnamkaPridat);
                            Console.WriteLine("Známka byla přidána.");
                        }
                        else
                        {
                            Console.WriteLine("Neplatná hodnota.");
                        }
                        break;

                    case "4":
                        Console.WriteLine("Úpravy ukončeny.");
                        return;

                    default:
                        Console.WriteLine("Neplatná volba.");
                        break;
                }
            }
        }
    }
}
