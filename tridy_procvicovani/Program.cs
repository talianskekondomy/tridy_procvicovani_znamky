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
            Student s1 = new Student(); //implicitní konstruktor?
            s1.Jmeno = Console.ReadLine();
            Student s2 = new Student();
            Student s3 = new Student();
            Console.WriteLine("Zadejte 5 známek:");

            s1.ZadejZnamky();
            s1.kontrolaPrumeru();
            Console.WriteLine("Počet studentů" + Student.seznamStudentu);
            Console.ReadKey();

      /*
          Student s1 = new Student("Lukáš", 1.5); 
          Student s2 = new Student("Adík", 2.3);
          Student s3 = new Student("Petr", 1.2);
          s1.kontrolaPrumeru();
          s2.kontrolaPrumeru();
          s3.kontrolaPrumeru();
            */
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
            Console.WriteLine("Zadejte 5 známek");
            try
            {
                for (int i = 0; i < 5; i++)
                {
                    znamky.Add(Convert.ToInt32(Console.ReadLine()));
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("Chyba: " + e.Message); ;
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
    }
}