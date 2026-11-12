# Procvičení: Přechod na objektově orientované programování (OOP)

**Cíl procvičení:**
Pochopit, jak se program správně strukturuje pomocí OOP a vidět změnu z chaosu do uspořádání.
---

## 1. Zadání a postup práce

### Část 0: Příprava

Prvně si založte(případně pokračujte ve stávajícím projektu) nový projekt a zkopírujte tento kód. Nezapomeňte změnit namespace na svůj stávající.

```csharp
using System;

namespace Procviceni
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
                Console.WriteLine();

                switch (volba)
                {
                    case '1':
                        Predstaveni();
                        break;

                    case '2':
                        VykresliCtverec();
                        break;

                    case '3':
                        VypisCisla();
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

        static void Predstaveni()
        {
            Console.WriteLine("Jak se jmenuješ?");
            string name = Console.ReadLine();

            Console.WriteLine("Jaký rok ses narodil?");
            int birthYear;
            while (!int.TryParse(Console.ReadLine(), out birthYear))
            {
                Console.WriteLine("Neplatný rok! Zadej prosím číslo:");
            }

            Console.WriteLine("Kde bydlíš?");
            string address = Console.ReadLine();

            int vek = DateTime.Now.Year - birthYear;
            string stav = (vek >= 18) ? "dospělý" : "mladistvý";

            Console.WriteLine($"{name} je {vek} let starý a bydlí v {address}, je {stav}.");
        }

        static void VykresliCtverec()
        {
            Console.WriteLine("Zadej velikost čtverce:");
            if (int.TryParse(Console.ReadLine(), out int velikost) && velikost > 0)
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
                Console.WriteLine("Musíš zadat kladné číslo!");
            }
        }

        static void VypisCisla()
        {
            Console.WriteLine("Zadej číslo X:");
            if (int.TryParse(Console.ReadLine(), out int x) && x >= 1)
            {
                for (int i = 1; i <= x; i++)
                {
                    Console.Write(i + (i < x ? ", " : ""));
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Musíš zadat číslo větší nebo rovno 1!");
            }
        }
    }
}
```

### Část A: Třída `Osoba` (Zapouzdření a konstruktor)

V první volbě menu aktuálně sbíráme data o uživateli do volných proměnných. Místo toho vytvoříme reprezentaci člověka.

1. Vytvořte novou třídu `Osoba`.
2. Přidejte jí veřejné vlastnosti (`Properties`):

- `Jmeno`
- `RokNarozeni`
- `Bydliste`

**POZNÁMKA POD ČAROU: Bacha na Field vs Property**

3. Vytvořte **konstruktor**, který přijme jméno, rok narození a bydliště jako parametry a uloží je do vlastností.
4. Vytvořte metodu `SpocitejVek()`, která vrátí aktuální věk jako `int` (`DateTime.Now.Year - RokNarozeni`).
5. Vytvořte metodu `VypisInfo()`, která do konzole vypíše celou větu o osobě (včetně toho, zda je dospělý nebo mladistvý).

_Úprava v `Program`:_ V metodě `Predstaveni()` se jen zeptejte na vstupy, vytvořte instanci `Osoba uzivatel = new Osoba(...)` a zavolejte `uzivatel.VypisInfo()`.

---

### Část B: Třída `Ctverec` (Stav objektu a jeho chování)

Čtverec není jen jednorázový výpis znaků, ale geometrický útvar, který má své rozměry a dokáže spočítat svůj obsah nebo se vykreslit.

1. Vytvořte třídu `Ctverec`.
2. Přidejte jí vlastnost `public int Velikost { get; private set; }` (velikost se nastaví při vytvoření a zvenčí už ji nejde náhodně změnit).
3. Vytvořte **konstruktor**, který přijme velikost. _Bonus:_ Pokud někdo zadá číslo menší než 1, konstruktor nastaví výchozí velikost na `1`.
4. Přidejte metody:

- `Vykresli()` – vykreslí čtverec z `#` do konzole (bez parametrů, bere si `this.Velikost`).
- `SpocitejObsah()` – vrátí `int` ($Velikost \times Velikost$).
- `SpocitejObvod()` – vrátí `int` ($4 \times Velikost$).

_Úprava v `Program`:_ Po zadání velikosti vytvořte objekt `Ctverec c = new Ctverec(velikost);`, vykreslete ho a pod něj vypište i jeho obvod a obsah.

---

### Část C: Třída `CiselnaRada` (Práce s rozsahem)

Třetí volba vypisuje čísla. Zabalíme tuto logiku do objektu, který reprezentuje číselnou řadu od 1 do $X$.

1. Vytvořte třídu `CiselnaRada` s vlastností `public int HorniMez { get; set; }`.
2. Vytvořte konstruktor, který přijme horní mez.
3. Přidejte metodu `VypisVse()`, která vypíše čísla oddělená čárkou.
4. Přidejte metodu `VypisSuda()`, která vypíše jen sudá čísla z tohoto rozsahu.

---

## 2. Rozšíření pro pokročilejší (Dědičnost a Polymorfismus)

> **Zadání:** Chceme kromě čtverce umět vykreslovat i **Obdélník** a **Trojúhelník**.
>
> 1. Vytvořte společnou rodičovskou (abstraktní) třídu `GeometrickyUtvar`, která má virtuální/abstraktní metodu `Vykresli()`.
> 2. Třídy `Ctverec` a `Obdelnik` budou z této třídy dědit (`class Ctverec : GeometrickyUtvar`) a každá si přepíše (`override`) metodu `Vykresli()` po svém.
> 3. Vytvořte si v programu `List<GeometrickyUtvar> historieUtvaru`, kam se každý nově vytvořený útvar uloží. Přidejte do menu volbu `4 - Vykreslit všechny uložené útvary`, která projde seznam cyklem `foreach` a na každém objektu zavolá `.Vykresli()`.

---
