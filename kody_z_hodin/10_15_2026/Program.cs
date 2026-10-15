namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1 - predstaveni");
                Console.WriteLine("2 - Vykresleni ctverce podle velikosti");
                Console.WriteLine("3 - Vypsani cisel 1 az X");
                Console.WriteLine("Q - konec");
                char volba = Console.ReadKey().KeyChar;
                if (volba == '1')
                {
                    Console.WriteLine("Jak se jmenuješ?");
                    string name = Console.ReadLine();
                    Console.WriteLine("Jaký rok ses narodil?");
                    int birthYear = int.Parse(Console.ReadLine());
                    Console.WriteLine("Kde bydlíš?");
                    string address = Console.ReadLine();
                    int vek = 2026 - birthYear;
                    string stav;
                    if (vek >= 18)
                    {
                        stav = "dospělý";
                    }
                    else
                    {
                        stav = "mladistvý";
                    }
                    Console.WriteLine($"{name} je {vek} let starý a bydlí v {address}, je {stav}");


                }
                else if (volba == '2')
                {
                    Console.WriteLine("Zadej velikost ctverce:");
                    int velikost = int.Parse(Console.ReadLine());
                    for (int i = 0; i < velikost; i++)
                    {
                        for (int j = 0; j < velikost; j++)
                        {
                            Console.Write("# ");
                        }
                        Console.WriteLine();
                    }
                }
                else if (volba == '3')
                {
                    Console.WriteLine("Zadej číslo X:");
                    int x = int.Parse(Console.ReadLine());
                    for (int i = 1; i <= x; i++)
                    {
                        Console.WriteLine(i);
                    }
                }
                else if (volba == 'Q' || volba == 'q')
                {
                    break;
                }

            }
        }
    }
}
