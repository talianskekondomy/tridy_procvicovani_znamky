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
            Student s1 = new Student(); //implicitní konstruktor
            s1.Jmeno = Console.ReadLine();
            Student s2 = new Student();
            Student s3 = new Student();

            Console.WriteLine("Zadejte 5 známek:");
            s1.ZadejZnamky();
            s1.kontrolaPrumeru();


            Student.ZobrazPrumerVsechStudentu();
            Student.KontrolaPoctuStudentu();

            Console.WriteLine("Chcete smazat a zadat nové známky? (ano/ne)");
            if (Console.ReadLine().ToLower() == "ano")
            {
                s1.ObnovZnamky();
                s1.kontrolaPrumeru();
            }

            Console.ReadKey();

  
        }
    }
    public class Student
    {
        //atributy
        public string Jmeno;
        public double PrumernaZnamka;
        public List<int> znamky;
        public static int pocetStudentu;
        //static = vztahocě nezávislá, nezodpovídá se ničemu nadřazenému
        public static List<Student> seznamStudentu = new List<Student>();

        //konstruktor
        public Student()
        {
            znamky = new List<int>();
            pocetStudentu++;
            seznamStudentu.Add(this);
        }

        //metody
        public void ZobrazInfo()
        {
            Console.WriteLine("Jmeno stuenta: " + Jmeno + "\nJeho prumer: " + PrumernaZnamka);
        }


        public void kontrolaPrumeru()
        {
           
            try
            {
                if (znamky.Count == 0)
                {
                    Console.WriteLine("Žádné známky nebyly zadány. Nelze vypočítat průměr.");
                    return;
                }

                double prumer = znamky.Average();
                if (prumer < 1.5)
                {
                    Console.WriteLine("Nárok na stipendium");
                }
                else
                {
                    Console.WriteLine("Nemá nárok na stipendium");
                }
                PrumernaZnamka = prumer;
            }
            catch (Exception e)
            {
                Console.WriteLine("Chyba: " + e.Message);
            }

            
        }
         public void ZadejZnamky()
        {
            try
            {
                for (int i = 0; i < 5; i++)
                {
                    int znamka;
                    do
                    {
                        Console.Write($"Zadejte známku {i + 1} (1-5): ");
                        znamka = Convert.ToInt32(Console.ReadLine());

                        if (znamka < 1 || znamka > 5)
                        {
                            Console.WriteLine("Neplatná známka! Zadejte číslo mezi 1 a 5.");
                        }
                    } while (znamka < 1 || znamka > 5);

                    znamky.Add(znamka);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Chyba při zadávání známek: " + e.Message);
            }
        }
        public static void ZobrazVsechnyy()
        {
            Console.WriteLine("Seznm Studentů: ");
            foreach (var student in seznamStudentu)
            {
                Console.WriteLine("Jmeno: " + student.Jmeno);
            }
        }

        public void MazatZnamky()
        {
            znamky.Clear();
            Console.WriteLine( "Všechny známky byly smazány");
        }

        public void ObnovZnamky()
        {
            MazatZnamky();
            Console.WriteLine("Zadejte nové známky:");
            ZadejZnamky();
        }

        public static void KontrolaPoctuStudentu()
        {
            if (pocetStudentu == 0)
            {
                Console.WriteLine("V systému není žádný student.");
            }
            else
            {
                Console.WriteLine("Počet studentů: " + pocetStudentu);
            }
        }


        public static void ZobrazPrumerVsechStudentu()
        {
            if (seznamStudentu.Count == 0)
            {
                Console.WriteLine("Žádní studenti nejsou k dispozici.");
                return;
            }

            double soucetPrumeru = 0;
            int pocetStudentuSeZnamkami = 0;

            Console.WriteLine("\n Průměrné známky jednotlivých studentů:");
            foreach (var student in seznamStudentu)
            {
                if (student.znamky.Count > 0)
                {
                    double prumer = student.znamky.Average();
                    Console.WriteLine($" {student.Jmeno}: {prumer:F2}");
                    soucetPrumeru += prumer;
                    pocetStudentuSeZnamkami++;
                }
                else
                {
                    Console.WriteLine($" {student.Jmeno} zatím nemá žádné známky.");
                }
            }

            if (pocetStudentuSeZnamkami > 0)
            {
                double celkovyPrumer = soucetPrumeru / pocetStudentuSeZnamkami;
                Console.WriteLine($"\n Celkový průměr všech studentů: {celkovyPrumer:F2}");
            }
            else
            {
                Console.WriteLine("\n Žádný student zatím nemá zadané známky, nelze spočítat průměr.");
            }
        }

    }
}