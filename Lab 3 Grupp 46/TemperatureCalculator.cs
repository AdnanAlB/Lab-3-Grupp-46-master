using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3_Grupp_46
{
    internal class TempratureCalculator
    {
        // En privat array för att lagra temperaturer för maj.
        static int[] temperatures;

        public  TempratureCalculator() 
        {
            temperatures = GenerateTemperature();
        }

        // Metod för att generera temperaturer för 31 dagar
         static int[] GenerateTemperature(int minTemp = -5, int maxTemp = 25)  // Minsta och högsta möjliga temperatur.
        {
            int nuomberOfDays = 31;

            int[] temp = new int[nuomberOfDays];
            Random random = new Random();

            for (int i = 0; i < nuomberOfDays; i++)
                temp[i] = random.Next(minTemp, maxTemp + 1);

            return temp; // Returnerar arrayen med temperaturer.
        }

        // skriva ut temperaturer för varje dag i maj.
        public void PrintTemperatureList()
        {
            Console.WriteLine("Temperaturer för maj:");
            for (int i = 0;i < temperatures.Length;i++)
                Console.WriteLine($"Dag {i + 1}: {temperatures[i]} °C");
        }
        // Beräkna och skriva ut medeltemperaturen.
        public void GetAverageTemperature()
        {
            double average = Math.Round(temperatures.Average(), 1); // Beräknar medeltemperatur och rundar av till 1 decimal.
            Console.WriteLine($"Medeltempraturen för maj är {average} °C.");
        }
        //Hitta den varmaste dagen
        public void FindHottestDay() 
        {
            int maxTemp = temperatures.Max(); // Hittar högsta temperaturen.
            int day = Array.IndexOf(temperatures, maxTemp) + 1;
            Console.WriteLine($"Den varmaste dagen är dag {day} med {maxTemp} °C");
        }
        //Den kallaste dagen
        public void FindColdestDay() 
        {
            int minTemp = temperatures.Min(); // Hittar lägsta temperaturen.
            int day = Array.IndexOf(temperatures, minTemp) + 1;
            Console.WriteLine($"Den kallaste dagen är dag {day} med {minTemp} °C");
        }

        // Få mediantemperaturen för maj
        public void FindMedian()
        {
            var sortedTemps = temperatures.OrderBy(t => t).ToArray();
            double median;
            int mid = sortedTemps.Length / 2; // Hittar mitten av arrayen.
            if (sortedTemps.Length % 2 == 0)
                median = (sortedTemps[mid - 1] + sortedTemps[mid]) / 2.0;
            else
                median = sortedTemps[mid]; // Medianen för udda antal värden.

            Console.WriteLine($"Mediantemperaturen för maj är {median} °C.");
        }
        //Sortera och skriva ut temperaturerna.
        public void PrintSortedTemperatures() 
        {

            Console.WriteLine("Vill du sortera temperaturerna i stigande (A) eller fallande (B) ordning?");
            string sortOrder = Console.ReadLine().ToUpper();

            int[] sortedTemperatures;

            if (sortOrder == "B") // Fallande ordning
            {
                sortedTemperatures = temperatures.OrderByDescending(t => t).ToArray();
                Console.WriteLine("Temperaturer i fallande ordning:");
            }
            else // Stigande ordning som standard
            {
                sortedTemperatures = temperatures.OrderBy(t => t).ToArray();
                Console.WriteLine("Temperaturer i stigande ordning:");
            }

            Console.WriteLine(string.Join(", ", sortedTemperatures));
            
        }

        //Filtrera majdagar med temperatur över en tröskel
        public void FindAfterThreshold()
        {
            Console.Write("Ange tröskeltemperatur: ");
            if (int.TryParse(Console.ReadLine(), out int threshold))
            {
                var filteredTemps = temperatures.Where(t => t > threshold).ToArray();
                if (filteredTemps.Length > 0)
                {
                    Console.WriteLine($"Dagar med temperaturer över {threshold}°C:");
                    foreach (var temp in filteredTemps)
                    {
                        int day = Array.IndexOf(temperatures, temp) + 1;// Hittar dagen för varje temperatur.
                        Console.WriteLine($"Dag {day}: {temp} °C");
                    }
                }
                else
                {
                    Console.WriteLine("Inga dagar har temperaturer över den angivna tröskeln.");
                }
            }
            else
            {
                Console.WriteLine("Ogiltig inmatning. Försök igen.");
            }
        }

        // Få temperaturen för den, dagen före och dagen efter
        public void SearchTemp()
        {
            Console.Write("Ange dag (1-31): ");
            if (int.TryParse(Console.ReadLine(), out int day) && day >= 1 && day <= 31)
            {
                int index = day - 1; // Hittar indexet för vald dag.
                int previousDay = (index - 1 >= 0) ? temperatures[index - 1] : -1;
                int nextDay = (index + 1 < temperatures.Length) ? temperatures[index + 1] : -1;

                Console.WriteLine($"Temperatur för dag {day}: {temperatures[index]} °C");
                if (previousDay != -1)
                {
                    Console.WriteLine($"Temperatur för dagen före (dag {day - 1}): {previousDay} °C");
                }
                if (nextDay != -1)
                {
                    Console.WriteLine($"Temperatur för dagen efter (dag {day + 1}): {nextDay} °C");
                }
            }
            else
            {
                Console.WriteLine("Ogiltig dag. Försök igen.");
            }
        }

        // Få ut den vanligast förekommande temperaturen i maj
        public void FindMostFrequentTemp()
        {
            var mostFrequentTemp = temperatures.GroupBy(t => t) // Grupperar temperaturerna efter värde.
                                               .OrderByDescending(g => g.Count()) // Sorterar grupperna i fallande ordning baserat på antalet element i varje grupp.
                                               .First()  // Hämtar den första gruppen i den sorterade listan, (vanligaste)
                                               .Key; // Hittar temperaturen som förekommer flest gånger.

            Console.WriteLine($"Den vanligast förekommande temperaturen är {mostFrequentTemp} °C.");
        }


    }
}
