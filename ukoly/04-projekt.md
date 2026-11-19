# OOP Uzavírající projekt

Cíl: Vymyslet zadání a následně podle něho programovat konzolovou aplikaci v C#

## Zadání

1. Vymyslete si téma (např. Evidence her, knihovna, banka, deník,...)
2. Vymyslete zadání na dané téma. Úplně dole máte, jak by zhruba mělo vypadat.
   - Musí alespoň obsahovat:
     - Název a o čem to je
     - Jaké budete tvořit třídy (nejméně 2, z toho jedna bude dědit)
     - Ovládání

> [!CAUTION]  
> Vymyslete si zadání, které dokážete za 2-3 hodiny v pohodě naprogramovat.

**Co musí kód splňovat:**

- **Dědičnost:** Minimálně jedna rodičovská třída a jeden potomek (`class Potomek : Rodic`), použití konstruktoru (`: base(...)`).
- **Polymorfismus:** Metoda v rodiči (`virtual`), kterou potomek přepíše po svém (`override`) – typicky výpis informací.
- **Seznam (`List<T>`):** Všechny objekty ukládat do jednoho `List`u rodičovského typu.
- **Ovládání:** Hlavní menu v cyklu `while` řešené přes `switch`.
- **Metody:** Rozdělit kód do vlastních metod (nepsat všechno na jednu hromadu do `Main`).
- **Základní ošetření vstupů:** Aplikace nesmí spadnout, když uživatel napíše místo čísla písmeno (`int.TryParse`).

**Bonus (Nepovinné, pouze, kdybyste se nudili):**

- Uložení dat do souboru při ukončení a načtení při startu (`.txt`, `.csv` nebo `.json`).
- Filtrování nebo vyhledávání v seznamu.

---

## Ukázkové zadání

**Název projektu:** Garáž (Evidence aut)

**O co jde:** Konzolová aplikace v C# na správu aut v garáži. Uživatel může auta přidávat, vypisovat, mazat a upravovat jim stav.

**Třídy a dědičnost:**

- `Auto` (rodič) – `Znacka`, `Model`, `NajetoKm`, metoda `VypisInfo()`
- `ElektroAuto : Auto` (potomek) – přidává `KapacitaBaterie`, přepisuje `VypisInfo()` (`override`)

**Funkce v menu (`while` + `switch`):**

1. Přidat klasické auto
2. Přidat elektroauto
3. Vypsat všechna auta v garáži
4. Smazat auto (podle čísla v seznamu)
5. Najet kilometry (přičte km vybranému autu)
6. Konec

_(Když mi zbyde čas, zkusím uložit všechna vozidla do .json)_
