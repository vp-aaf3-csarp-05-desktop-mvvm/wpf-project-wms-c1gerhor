# Grafikus alkalmazás és MVVM

Amikor egy grafikus alkalmazást készítünk, **mindig két különböző dologgal dolgozunk egyszerre**:

- **mit lát a felhasználó** (gombok, szövegek, listák),

- **milyen adatokkal dolgozik az alkalmazás** (változók, objektumok, állapot).

Kezdőként csábító lehet mindent **egyetlen fájlban** megírni:

- a gomb kinézetét,

- a kattintás logikáját,

- az adatokat is.

Ez azonban hamar problémákhoz vezet:

- a kód **átláthatatlanná válik**,

- nehéz módosítani a kinézetet úgy, hogy a logika ne sérüljön,

- az üzleti logika **nem újrahasznosítható**,

- tesztelni szinte lehetetlen.

Ezért ipari környezetben **szétválasztjuk a felelősségeket**.

---

## A felelősségek szétválasztásának gondolata

Az MVVM (Model–View–ViewModel) minta lényege, hogy:

- **View** → csak a megjelenítésért felel

- **ViewModel** → az alkalmazás állapotát és működését írja le

- **Model** → az adatokat reprezentálja

👉 A View **nem tudja**, honnan jönnek az adatok  
👉 A ViewModel **nem tudja**, hogyan néz ki a felület

A két réteg **nem hívja egymást közvetlenül**, hanem egy köztes mechanizmuson keresztül kommunikál.

Ez a mechanizmus a **binding**.

---

## Miért nem közvetlen kódból állítjuk a feliratokat?

Képzeljük el ezt a gondolkodásmódot:

> „Van egy `Label`, annak a szövegét kódból állítom.”

Ez technikailag működik, de:

- a View **függ a kódtól**,

- minden változásnál kézzel kell frissíteni a felületet,

- az adatok és a megjelenítés **összekeveredik**.

Az MVVM ehelyett ezt mondja:

> „A View csak *megfigyeli* az adatot, és automatikusan frissül, ha az adat változik.”

Ehhez kell a **binding**.

---

## Mi a binding röviden?

A **binding** egy kapcsolat a View (XAML) és a ViewModel (C#) között.

- a ViewModel tartalmazza az adatot (pl. `string Name`)

- a View megmondja:  „Ezt a feliratot ehhez az adathoz kötöm”

Ha az adat megváltozik:

- **nem írunk UI-kódot**

- a felület **magától frissül**

Ez az MVVM egyik legfontosabb ereje.

---

## ViewModel kód

```csharp
public class EmployeeViewModel
{
    public string Name { get; } = "Nagy Anna";
}
```

Ez egy **ViewModel**, vagyis:

- **nem UI elem** (nem Label, nem TextBox),

- **adatot szolgáltat** a View számára.

A View **nem változókat lát**, hanem **property-ket**.

Lehetne ez is:

```csharp
public string Name = "Nagy Anna";
```

Ez C#-ban teljesen helyes, **de MVVM-ben nem használjuk**.

**Miért?**

- a binding **property-re működik**, nem mezőre,

- a XAML nem mezőket figyel, hanem property-ket,

- a property mögött később **logika is lehet**.

👉 **Szabály:**  **Binding = property**

## A DataContext szerepe az MVVM-be

```csharp
<Window.DataContext>
    <local:EmployeeViewModel />
</Window.DataContext>
```

Ez a kódrészlet azt mondja ki, hogy:

> **„Ez az ablak ebből a ViewModelből olvassa az adatait.”**

A `DataContext` a **binding kiindulópontja**.

---

## Mit jelent a `DataContext` szó szerint?

A `DataContext` jelentése:

- „adatkörnyezet”

- „adatforrás”

## A Binding

```csharp
<StackPanel Orientation="Vertical">
    <Label>Név:</Label>
    <TextBlock Text="{Binding Name}" />
</StackPanel>
```

Ez a kód azt mondja ki:

> **„A `TextBlock` szövege a ViewModel `Name` nevű adatából jöjjön.”**

**Binding**

- egy **adatkapcsolat** a View és a ViewModel között,

- nem egy metódushívás,

- nem direkt változóelérés.

A `Binding Name` mindig ezt jelenti:

> „Keresd meg a DataContext-ben a `Name` property-t.”

## TextBlock és Label használata WPF-ben

WPF-ben **két hasonló kinézetű, de eltérő célú vezérlő** létezik szöveg megjelenítésére: `TextBlock` és `Label`.

### `TextBlock`

A `TextBlock` **szöveg megjelenítésére szolgál**, tipikusan:

- adatok,

- változó értékek,

- ViewModelből érkező tartalom.

Jellemzői:

- könnyű, egyszerű vezérlő,

- jól használható **bindinggel**,

- nincs fókusza, nincs interakciós szerepe.

👉 **MVVM-ben az adatokat általában `TextBlock`-kal jelenítjük meg.**

---

### `Label`

A `Label` **felirat**, amely:

- egy másik vezérlőt „megnevez”,

- UI-elemhez kapcsolódik (pl. TextBox).

Jellemzői:

- tartalmazhat `Target`-et,

- billentyűzettel fókuszt adhat át,

- inkább **statikus szöveg**.

👉 **Űrlapoknál, mezők megnevezésére használjuk.**

---

## Gyakorlati szabály

> **Ha adatot mutatsz → `TextBlock`**  
> **Ha egy mezőt nevezel el → `Label`**
