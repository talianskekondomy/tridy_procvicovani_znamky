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


            /*Třída Student
            Atributy: Jméno (string), PrůměrnáZnámka (double)
             Metody: ZobrazInfo() , která vypíše jméno a průměrnou známku. 
            Přidej metodu KontrolaPrumeru() , která zkontroluje, jestli student má průměrnou 
            známku vyšší než 2.0.
             */

            //(Kdyby array objektů)
            //TODO:
            //-uživatel zadává jména a známky
            //-průměr vychází z několika známek (array, list - (rozdíl - array má ststický počet prvků))
            //ukázat TRY CATCH FINALLY
            //ukázat vytvoření list
            //ukázat STATIC + přidělení více studentů

            Console.WriteLine("Zadejte jméno studenta:");
            Student s1 = new Student(); //implicitní konstruktor?
            s1.Jmeno = Console.ReadLine();
            Student s2 = new Student();
            Student s3 = new Student();

            Console.WriteLine("Zadejte 5 známek:");
            
            try //zkusím jestli rizikový kód funguje
            {
                //rizikový kód
                for (int i = 0; i < 5; i++)
                {

                    s1.znamky.Add(Convert.ToInt32(Console.ReadLine()));

                }
            }
            catch (FormatException e)
            {
                Console.WriteLine("Chyba formátování");
            }
            catch (Exception e)
            {

                Console.WriteLine("Něco se pokzilo");

            }
            finally
            {
                Console.WriteLine("Program bude ukončen");
            }

            //Console.WriteLine(s1.seznamStudentu);

            
            s1.kontrolaPrumeru();
            Console.WriteLine( "Počet studentů" + Student.seznamStudentu);
            Console.ReadKey();
            //TODO:
            //přidáním známky přepište na vlastní metodu(v rámci třídy) class student - > přidat metodu která bude přidávat známky
            //-přidejte metodu, která zobrazuje jména všech studentů
            //- přidejte metodu, která bude známky upravovat (mazat, editovat,...)



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
        //static = vztahocě nezávislá, nezodpovídá se ničemu nadřazenému
        public static int seznamStudentu;
        public Student() 
        { 
            znamky = new List<int>();
            seznamStudentu++;
        }
       
        //metody
        //zobraz informace; kontrola prumeru

        public void ZobrazInfo()
        {
            Console.WriteLine("Jmeno stuenta: " + Jmeno + "\nJeho prumer: " + PrumernaZnamka);

        }

        public void kontrolaPrumeru()
        {
            double prumer = znamky.Average();
            try
            {
                if (prumer <  1.5)
                {
                    Console.WriteLine("Nárok na stipendium");
                }
                else
                {
                    Console.WriteLine("Nemá nárok na stipendium");
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(  "něco se pokazilo");
            }
            
            Console.ReadKey();
        }
        
    }
}
