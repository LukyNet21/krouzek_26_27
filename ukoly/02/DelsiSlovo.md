# Delší slovo

**Cíl cvičení:**
Naučit se vytvářet metody s parametry a návratovou hodnotou, a oddělit logiku výpočtu od výpisu na obrazovku.

## Zadání a postup práce

1. **Vytvoření metody:** Napište novou metodu, která přijme jako parametry dvě slova (datového typu `string`).
2. **Logika porovnání:** Metoda zjistí, které z těchto dvou slov je delší, a toto delší slovo **vrátí** jako svůj výsledek (použijte příkaz `return`). 
3. **Použití v hlavním programu:** V metodě `Main` vyzvěte uživatele k zadání dvou slov. Následně zavolejte vaši novou metodu, předejte jí zadaná slova a výsledek, který metoda vrátí, vypište do konzole.

## Důležité pravidlo (Omezení)

Uvnitř vaší nové metody se **nesmí objevit žádné vypisování na konzoli**! Nepoužívejte zde `Console.Write` ani `Console.WriteLine`. Úkolem metody je pouze data zpracovat a vrátit výsledek, vypisování má na starosti výhradně hlavní program (`Main`).

## Nápověda

Délku textového řetězce (počet znaků) zjistíte pomocí jeho vlastnosti `Length`. 
Pokud se váš textový řetězec jmenuje například `prvniSlovo`, jeho délku získáte zápisem `prvniSlovo.Length`.
