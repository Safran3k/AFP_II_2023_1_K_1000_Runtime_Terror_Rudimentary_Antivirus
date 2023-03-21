# Rendszerterv
## 1. A rendszer célja
A rendszer egy kezdetleges vírusírtó software, ahol a regisztrált felhasználók nagyobb mappákat, akár teljes meghajtókat is tudnak vizsgáltatni, míg a vendég felhasználó csak egyes fájlokat, és a regisztrált felhasználók törölni, illetve karanténba helyezni is tudják a fertőzött fájlokat. A projekt kizárólag ablakos alkalmazásként készül.

## 2. Projektterv

### 2.1 Projektszerepkörök, felelőségek:
   * Scrum masters: Prokaj Kristóf
   * Product owner: Prokaj Kristóf
   * Üzleti szereplő: Futó Richárd, Bálint Ádám, Biesz Dávid
   * Megrendelő: Bagoly Gábor
     
### 2.2 Projektmunkások és felelőségek:
   * Frontend: Futó Richárd, Bálint Ádám, Biesz Dávid
   * Backend: Futó Richárd, Bálint Ádám, Biesz Dávid
   * Tesztelés: Futó Richárd, Bálint Ádám, Biesz Dávid
     
### 2.3 Ütemterv:

|Funkció                  | Feladat                                | Prioritás | Becslés (nap) | Aktuális becslés (nap) | Eltelt idő (nap) | Becsült idő (nap) |
|-------------------------|----------------------------------------|-----------|---------------|------------------------|------------------|---------------------|
|Követelmény specifikáció |Megírás                                 |         1 |             1 |                      1 |                1 |                   1 |             
|Funkcionális specifikáció|Megírás                                 |         1 |             1 |                      1 |                1 |                   1 |
|Rendszerterv             |Megírás                                 |         1 |             1 |                      1 |                1 |                   1 |
|Program                  |Képernyőtervek elkészítése              |         2 |             1 |                      1 |                1 |                   1 |
|Program                  |Prototípus elkészítése                  |         3 |             8 |                      8 |                8 |                   8 |
|Program                  |Alapfunkciók elkészítése                |         3 |             8 |                      8 |                8 |                   8 |
|Program                  |Tesztelés                               |         4 |             2 |                      2 |                2 |                   2 |

### 2.4 Mérföldkövek:
   * Prototípus átadása

## 3. Üzleti folyamatok modellje
![uzletimodel](https://i.imgur.com/j4IZcXH.png)

## 4. Követelmények

### Funkcionális követelmények

Lásd: Funckionális követelmények
### Nemfunkcionális követelmények

| ID | Megnevezés | Leírás |
| --- | --- | --- |
| K1 | Adat hozzáférés | Egy felhasználó/vendég nem férhet hozzá más felhasználóknak az adataihoz 
| K2 | Vendég szerepkör | Egy vendég nem használhatja a regisztrált felhasználók előnyeit |

### Támogatott eszközök
Csak windows operációs rendszert támogatja jelen pillanatban, később mobil alkalmazásként is elérhető lesz a vírusírtó szoftverünk.

## 5. Funkcionális terv

### 5.1 Rendszerszereplők
Vendég: Egyesével tud fájllokat vizsgáltatni
Felhasználó: Több fájlt/mappát/meghajtót is tud egyszerre vizsgáltatni, emellett a folyamatokat is be tudja záratni.

### 5.2 Menühierarchiák
- Bejelentkezés
  - Bejelentkezés
  - Regisztráció
- Főmenü
  - Több fájl/mappa/meghajtó vizsgálata
  - Fertőzött fájlok törlése/karanténba helyezése
  - Folyamatok leállítása


## 6. Fizikai környezet
A projekt kizárólag ablakos alkalmazásként elérhető, windows operációs rendszeren

### Vásárolt softwarekomponensek és külső rendszerek
Nincsenek megvásárolt softwarekomponenseink és külső rendszereink

### Fejlesztő eszközök
- Notepad++
- Visual Studio 2022
- Visual Studio Code
- MySql Workbench
- .NET Framework
- JavaScript

## 10. Tesztterv

A tesztelések célja a rendszer és komponensei funkcionalitásának teljes vizsgálata,
ellenőrzése a rendszer által megvalósított üzleti szolgáltatások verifikálása.
A teszteléseket a fejlesztői csapat minden tagja elvégzi.
Egy teszt eredményeit a tagok dokumentálják külön fájlokba.
