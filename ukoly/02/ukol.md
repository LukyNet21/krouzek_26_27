# Úkol: Refaktorování kódu pomocí metod

**Cíl úkolu:** 
Naučit se zpřehlednit a zjednodušit dlouhý kód (tzv. refaktorování) rozdělením do menších, logických celků – **metod**. 

Aktuálně je veškerá logika programu napsaná uvnitř jednoho velkého bloku `switch` v hlavní metodě `Main`. Vaším úkolem je tento kód vzít a pro každou volbu z menu vytvořit samostatnou metodu.

---

## 1. Výchozí kód

Zkopírujte si následující blok kódu do vašeho nově vytvořeného projektu (např. do souboru `Program.cs` v Console App):

```csharp
using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n--- MENU ---");
                Console.WriteLine("1 - Představení");
                Console.WriteLine("2 - Vykreslení čtverce podle velikosti");
                Console.WriteLine("3 - Vypsání čísel 1 až X");
                Console.WriteLine("Q - Konec");
                Console.Write("Vaše volba: ");

                char volba = Console.ReadKey().KeyChar;
                Console.WriteLine(); // Odsazení na nový řádek po stisknutí klávesy

                switch (volba)
                {
                    case '1':
                        Console.WriteLine("Jak se jmenuješ?");
                        string name = Console.ReadLine();

                        Console.WriteLine("Jaký rok ses narodil?");
                        if (!int.TryParse(Console.ReadLine(), out int birthYear))
                        {
                            Console.WriteLine("Neplatný rok!");
                            break;
                        }

                        Console.WriteLine("Kde bydlíš?");
                        string address = Console.ReadLine();

                        int vek = DateTime.Now.Year - birthYear; // Počítá věk podle aktuálního roku
                        string stav = (vek >= 18) ? "dospělý" : "mladistvý";

                        Console.WriteLine($"{name} je {vek} let starý a bydlí v {address}, je {stav}.");
                        break;

                    case '2':
                        Console.WriteLine("Zadej velikost ctverce:");
                        if (int.TryParse(Console.ReadLine(), out int velikost))
                        {
                            for (int i = 0; i < velikost; i++)
                            {
                                for (int j = 0; j < velikost; j++)
                                {
                                    Console.Write("# ");
                                }
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Musíš zadat číslo!");
                        }
                        break;

                    case '3':
                        Console.WriteLine("Zadej číslo X:");
                        if (int.TryParse(Console.ReadLine(), out int x))
                        {
                            for (int i = 1; i <= x; i++)
                            {
                                Console.Write(i + (i < x ? ", " : ""));
                            }
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Musíš zadat číslo!");
                        }
                        break;

                    case 'q':
                    case 'Q':
                        Console.WriteLine("Ukončuji program...");
                        return;

                    default:
                        Console.WriteLine("Neznámá volba, zkus to znovu.");
                        break;
                }
            }
        }
    }
}
```

---

## 2. Zadání a postup práce

Váš úkol se skládá z následujících kroků:

1. **Vytvoření metod:** Pod metodou `Main` (ale stále uvnitř třídy `Program`) vytvořte tři nové metody. 
   - Všechny metody budou mít návratový typ `void` (nebudou vracet žádnou hodnotu).
   - Pojmenujte je smysluplně, například:
     - `Predstaveni()`
     - `VykresliCtverec()`
     - `VypisCisla()`
2. **Přesun logiky:** Vezměte kód, který je aktuálně uvnitř `case '1'`, `case '2'` a `case '3'`, a přesuňte ho do příslušných nově vytvořených metod.
3. **Volání metod ze switche:** V metodě `Main` uvnitř bloku `switch` už nebude dlouhý kód. Místo něj tam zbyde jen zavolání vaší nové metody a příkaz `break;`. 

Příklad, jak by měl vypadat první případ po úpravě:
```csharp
case '1':
    Predstaveni();
    break;
```
