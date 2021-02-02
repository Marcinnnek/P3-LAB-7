using System;
using System.Collections.Generic;
using System.Linq;

namespace P3_LAB7_interface
{
    class Program
    {
        static void Main(string[] args)
        {
            interfejsy(100);

            //test1();
            //test2();
        }

        static string RandomString(int length, Random rnd) //########################## przenieść poza funkcje (funkacja w funkcji)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[rnd.Next(s.Length)]).ToArray());
        }
        private static void interfejsy(int size)
        {
            int arraySize = size; //###############################################################

            Random rnd = new Random();



            //List<Vault> origin = new List<Vault>();
            Vault[] origin = new Vault[100];
            for (int i = 0; i < arraySize; i++)
            {
                origin[i]=(new Vault(RandomString(((int)rnd.Next() % 15) + 5, rnd))); //wypełnienie tablicy losowymi elementami
            }

            for (int i = 0; i < arraySize; i++) // wypisanie oryginalnej tablicy
            {
                origin[i].Print();
            }


            List<Vault> copyOrigin = new List<Vault>();  // tablica dla kopii obiektów
            for (int i = 0; i < arraySize; i++)
            {
                copyOrigin.Add((Vault)origin[i].Clone()); // kopiowanie obiektu
                for (int j = 0; j < copyOrigin[i].Code.Length; j++)
                {
                    copyOrigin[i].Code[j] = 0; // zerowanie oryginalnej tablicy
                }
                //origin[i] = null; // zerowanie oryginalnej tablicy
            }

            /*for (int i = 0; i < arraySize; i++) // wypisanie wyzerowanej oryginalnej tablicy 
            {
                if(origin[i]==null)
                    Console.WriteLine("Pustka");
            }*/

            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");

            copyOrigin.Sort();      // sortowanie kopii tablicy po nazwie VaultName

            for (int i = 0; i < arraySize; i++)     //wypisanie posortowanej kopii tablicy
            {
                copyOrigin[i].Print();
            }
        }
        #region
        private static void test2()
        {
            List<Vault> lista = new List<Vault>
            {

                new Vault("cd"),
                new Vault("gcc"),
                new Vault("eaa"),
                new Vault("fgh"),
                new Vault("Nietypowy skarbiec nr 23"),
                new Vault("anietypowy skarbiec nr"),
                new Vault("anietypowy skarbiec nr"),
                new Vault("Nietypowy skarbiec nr 1"),
                new Vault("Nietypowy skarbiec nr 42"),
                new Vault("baa"),
                new Vault("aba"),
                new Vault("abc"),
                new Vault("aab"),
                new Vault("Nietypowy skarbiec nr 37"),
                new Vault("Nietypowy skarbiec nr 12"),
                new Vault("Nietypowy skarbiec nr 72")

             };
            lista.ForEach(Console.WriteLine);
            Console.WriteLine();
            lista.Sort();
            lista.ForEach(Console.WriteLine);

            lista[0].Print();
        }

        #endregion
        #region
        private static void test1()
        {
            ICloneable skarbiec1 = new Vault("Jakiś Skarbiec", new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            ICloneable skarbiec2 = new Vault("Jakiś Skarbiec", new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            ICloneable skarbiec3 = new Vault("Jakiś Skarbiec", new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            ICloneable skarbiec4 = new Vault("Jakiś Skarbiec", new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            ICloneable skarbiec5 = new Vault("Nietypowy skarbiec nr 5");
            Console.WriteLine(skarbiec4.Id);

            skarbiec1.CheckCode();
            skarbiec2.CheckCode();
            skarbiec5.CheckCode();
            Console.WriteLine(skarbiec5.Id);

            ICloneable skarbiec6 = (Vault)skarbiec5.Clone();
            skarbiec6.VaultName = "Nietypowy skarbiec nr 6";
            skarbiec5.Code = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Console.WriteLine(skarbiec5.VaultName);

            skarbiec5.CheckCode();

            skarbiec6.CheckCode();
        }
        #endregion
    }
}
