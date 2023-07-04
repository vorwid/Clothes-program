using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lukasz_Koscielniak_Kol
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Ubrania> ubrania = new List<Ubrania>();


            using (StreamReader reader = new StreamReader("C:\\Users\\Student\\Desktop\\ubrania.csv."))
            {
                string line;
                reader.ReadLine();

                while ((line = reader.ReadLine()) != null)
                {
                    string[] columns = line.Split(';');

                    if (columns.Length == 6 && int.TryParse(columns[0], out int id) && decimal.TryParse(columns[3], out decimal cena))
                    {
                        Ubrania ubranie = new Ubrania
                        {
                            id = id,
                            Nazwa = columns[1],
                            Producent = columns[2],
                            Cena = cena,
                            Kategoria = columns[4],
                            Podkategoria = columns[5]
                        };

                        ubrania.Add(ubranie);
                    }
                }
            }

            // Wybór ubrania z id 17771
            Ubrania ubranieId17771 = ubrania.FirstOrDefault(ubranie => ubranie.id == 17771);
            if (ubranieId17771 != null)
            {
                Console.WriteLine("Ubranie o id 17771:");
                Console.WriteLine($"Nazwa: {ubranieId17771.Nazwa}");
                Console.WriteLine($"Producent: {ubranieId17771.Producent}");
                Console.WriteLine($"Cena: {ubranieId17771.Cena}");
                Console.WriteLine($"Kategoria: {ubranieId17771.Kategoria}");
                Console.WriteLine($"Podkategoria: {ubranieId17771.Podkategoria}");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Ubranie o id 17771 nie zostało znalezione.");
            }


            List<Ubrania> ubraniaYNS = ubrania.Where(ubranie => ubranie.Producent == "YNS").ToList();
                Console.WriteLine("Ubrania od producenta YNS:");
                PrintUbraniaTable(ubraniaYNS);
            


            List<Ubrania> ubraniaREDOX = ubrania.Where(ubranie => ubranie.Producent == "REDOX").Where(ubranie => ubranie.Podkategoria =="DRESY").ToList();

                PrintUbraniaTable(ubraniaREDOX);


            static void PrintUbraniaTable(List<Ubrania> ubrania)
            {
                Console.WriteLine("{0,-10} {1,-20} {2,-15} {3,-10} {4,-15} {5,-15}",
                    "Id", "Nazwa", "Producent", "Cena", "Kategoria", "Podkategoria");

            }





        }    
    }
}
