# Zadání projektu: Jednoduchá CLI uživatelská databáze

## 1. Cíl projektu
Vytvořit konzolovou (CLI) aplikaci pro správu jednoduché uživatelské databáze se základními operacemi CRUD (Create, Read/Find, Update, Delete) a perzistentním ukládáním dat do souboru při řádném ukončení.

Veškeré příkazy se zadávají na jeden řádek. **Aplikace musí být odolná vůči chybám** – žádný neplatný vstup, chybějící parametr ani neplatná hodnota nesmí způsobit pád nebo předčasné ukončení programu.

---

## 2. Datový model uživatele

Každý uživatel má následující atributy:

| Pole | Datový typ | Popis |
| :--- | :--- | :--- |
| `id` | Celé číslo (`int`) | Unikátní numerický identifikátor (generuje se automaticky) |
| `jmeno` | Text (`string`) | Křestní jméno |
| `prijmeni` | Text (`string`) | Příjmení |
| `rok_n` | Celé číslo (`int`) | Rok narození (např. `2008`) |
| `mesic_n` | Celé číslo (`int`) | Měsíc narození (`1`–`12`) |
| `den_n` | Celé číslo (`int`) | Den narození (`1`–`31`) |

---

## 3. Načtení a ukládání dat (Perzistence)
- **Start aplikace:** Načtou se data ze souboru (např. `users.json` nebo `users.csv`). Pokud soubor zatím neexistuje, vytvoří se prázdná databáze.
- **Ukončení programu:** Aplikace se ukončuje **výhradně** příkazem `exit` nebo `quit`. Při tomto příkazu dojde k uložení všech záznamů do souboru.
- **Generování ID:** Počítadlo ID musí navazovat na nejvyšší existující `id` v načtených datech (nesmí vzniknout duplicity ani po restartu programu).

---

## 4. Příkazové rozhraní (CLI) a syntaxe

Příkazy se zadávají v interaktivní smyčce jako jeden řádek:

### 1. `insert <pole=hodnota ...>`
Vloží nového uživatele. Musí obsahovat všech 5 povinných parametrů v libovolném pořadí. ID se nezadává.

```text
> insert jmeno=Josef prijmeni=Veliký rok_n=2008 mesic_n=5 den_n=14
Uživatel úspěšně vytvořen s ID: 10
```

### 2. `update <id> <pole=hodnota ...>`
Upraví zadaná pole u existujícího uživatele podle jeho `id`.

```text
> update 10 jmeno=josef prijmeni=veliký
Uživatel s ID 10 byl aktualizován.
```

### 3. `delete <id>`
Smaže uživatele se zadaným ID.

```text
> delete 10
Uživatel s ID 10 byl smazán.
```

### 4. `find [pole=hodnota ...]`
Vyhledá uživatele splňující **všechny** zadané filtry (logické AND). Lze filtrovat i podle `id`. Pokud se nezadají žádné parametry, vypíše všechny uživatele.

```text
> find jmeno=josef rok_n=2008
Nalezené záznamy:
[ID: 10] Josef Veliký (14.5.2008)

> find id=10
Nalezené záznamy:
[ID: 10] Josef Veliký (14.5.2008)
```

### 5. `help` a `exit` / `quit`
- `help`: Vypíše syntaxi příkazů a jejich parametry.
- `exit` / `quit`: Uloží data a korektně ukončí program.

---

## 5. Odolnost proti chybám (Error Handling)

Program **nesmí za žádných okolností spadnout** v důsledku špatného vstupu. Při chybě vypíše srozumitelnou zprávu s předponou `Chyba:` a čeká na další příkaz.

| Situace | Požadované chování | Příklad výstupu |
| :--- | :--- | :--- |
| **Chybějící pole při `insert`** | Záznam se nevytvoří, program pokračuje | `Chyba: Chybí povinná pole: mesic_n, den_n.` |
| **Neznámý parametr** | Operace se zamítne | `Chyba: Neznámý parametr 'vek'.` |
| **Neplatný datový typ** | Odmítnutí nečíselné hodnoty pro ID/datum | `Chyba: 'rok_n' musí být celé číslo.` |
| **Datum mimo rozsah** | Validace měsíce (1–12) a dne (1–31) | `Chyba: 'mesic_n' musí být v rozmezí 1 až 12.` |
| **ID nenalezeno** | Pokus o `update` / `delete` neexistujícího ID | `Chyba: Uživatel s ID 42 neexistuje.` |
| **Neznámý příkaz** | Upozornění uživatele na špatný příkaz | `Chyba: Neznámý příkaz. Zadejte 'help' pro nápovědu.` |
