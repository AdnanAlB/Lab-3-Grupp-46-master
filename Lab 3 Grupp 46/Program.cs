using System;

namespace Lab_3_Grupp_46
{
    internal class Program
    {
        // Skapar en instans av klassen TemperatureCalculator som används för att hantera temperaturberäkningar.
        static TempratureCalculator tempApp = new TempratureCalculator();
        static void Main(string[] args)  
        {
            while (true) { 
                /* Programmet startar och användaren får
                 en meny med olika alternativ. */
            Console.WriteLine("");
            Console.WriteLine("Hej Disa Dagg! \n\nVälkommen till temperaturkalkylator");
            Console.WriteLine("****************************************************");
            Console.WriteLine("Välj ett alternativ: \n");
            Console.WriteLine("A. Få en lista över temperaturdata för varje dag i maj");
            Console.WriteLine("B. Se medeltemperaturen för maj");
            Console.WriteLine("C. Se den varmaste dagen");
            Console.WriteLine("D. Se den kallaste dagen");
            Console.WriteLine("E. Få mediantemperaturen för maj");
            Console.WriteLine("F. Sortera temperaturerna");
            Console.WriteLine("G. Filtrera majdagar med temperatur över en tröskel");
            Console.WriteLine("H. Få temperaturen för den, dagen före och dagen efter");
            Console.WriteLine("I. Få ut den vanligast förekommande temperaturen i maj");

                // Läser in användarens val och konverterar det till versaler.
                string choice = Console.ReadLine().ToUpper();

                try
                {
                    switch (choice)
                    {

                        case "A":
                            tempApp.PrintTemperatureList();
                            break;
                        case "B":
                            tempApp.GetAverageTemperature();
                            break;
                        case "C":
                            tempApp.FindHottestDay();
                            break;
                        case "D":
                            tempApp.FindColdestDay();
                            break;
                        case "E":
                            tempApp.FindMedian();
                            break;
                        case "F":
                            tempApp.PrintSortedTemperatures();
                            break;
                        case "G":
                            tempApp.FindAfterThreshold();
                            break;
                        case "H":
                            tempApp.SearchTemp();
                            break;
                        case "I":
                            tempApp.FindMostFrequentTemp();
                            break;
                        default:
                            // Hanterar om användaren matar in ett ogiltigt alternativ.
                            Console.WriteLine("Ogiltigt val. Försök igen.");
                            break;
                    }
                    // Ber användaren trycka på valfri tangent för att återgå till menyn.
                    Console.WriteLine("\nTryck på valfri tangent för att återgå till menyn...");
                    Console.ReadKey();
                }
                catch (FormatException x)
                {
                    Console.WriteLine("Invalid format. Please enter a valid option.");
                    Console.WriteLine($"Error message: {x.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An unexpected error occurred.");
                    Console.WriteLine($"Error message: {ex.Message}");
                }

            }
        }
    }
}