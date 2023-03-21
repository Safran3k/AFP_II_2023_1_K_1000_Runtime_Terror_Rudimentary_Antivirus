# Követelmény specifikáció

## Készítette

- Bálint Ádám

## 1. Áttekintés

#### A mai világunkban, főként az informatika világában elengedhetetlen a különböző programok letöltése és telepítése. Sajnos azonban a technika fejlődésével egyre több kártékony programvírust készítenek az adataink megszerzésének céljából. Erre megoldásként rengeteg vírusirtó született/születik. Némelyik gyorsabban elkészül kevésbé figyelembe véve magát a kinézetet, mások pedig több időt beletöltve fejlesztenek, így jobban odafigyelve hatékonyságra és funkcióra egyaránt. Ezek persze magukban az értékeléseikben is tükröződnek. Csapatunk célja, hogy készítsünk egy kezdetleges vírusirtó alkalmazást, amely könnyen átlátható és a felhasználók minél egyszerűbben tudják ellenőrizni mappáikat, programjaikat, munkafolyamataikat. Tehát egy vírusirtó fejlesztése a feladatunk, amely megfelel mind kinézetileg, mind funkcionálisan a vezetőségnek.

## 2. Jelenlegi helyzet

#### Az alkalmazás célja, hogy segítséget nyújtson a rendszerben található esetleges fenyegetések (vírusok, kártékony programok) felderítésében, és hosszabb távon egy teljes értékű és megbízható vírusirtó szolgáltatást nyújtson a megrendelőnek. A későbbiekben a terveink szerint többféle platformon is elérhető lesz az alkalmazás, például androidra és IOS- re. A megrendelő részére lehetőséget biztosít mappák, illetve a különböző precesszek (folyamatok) átvizsgálására.

## 3. Vágyálom rendszer

#### Az ügyfél célja, hogy olyan hatékony és megbízható vírusirtó rendszert használjon, amely megvédi számítógépeit a vírusoktól és kártevőktől. Ügyfelünk ragaszkodott hozzá hogy .NET framework-öt használjunk, és a fejlesztést C# nyelven valósítsuk meg, ami a nagymértékű támogatottságának, és az objektum orientáltságának köszönhetően lehetővé teszi hogy az alkalmazást későbbiekben tovább fejlesszük. A vágyálomrendszer megvalósítása jelentős mértékben hozzájárulna az ügyfél üzleti folyamatainak hatékonyságához és eredményességéhez.

## 4. Funkcionális követelmények

1. Regisztrációs felület
2. Bejelentkezési felület
3. Vizsgálandó fájl kiválasztás
 - a felhasználó kitudja választani azt hogy mely mappáit, alkalmazásait szeretné átvizsgálni.
4. Beállítások menüpont
 - a felhasználó szerkesztheti az adatait

Jogosultságok: Felhasználó, vendég

## 5. Jelenlegi üzleti folyamatok modellje

#### A jelenlegi modell szerint a felhasználóknak nincs lehetőségük vírusirtó programok használatára. Ennek hiánya nagy pénzügyi kockázatot jelent a vállalat számára, mivel a különböző vírusok, malware-ek és egyéb rosszindulatú programok könnyen megfertőzhetik a számítógépeket és a hálózatot, ezáltal veszélyeztetik az üzleti folyamatok zavartalan működését, valamint a fontos üzleti adatok biztonságát. Ezért elengedhetetlen, hogy a különböző fenyegetésekkel szemben bevezessünk egy hatékony vírusvédelmi szoftvert a vállalat számára, amely megfelelően képes védeni a számítógépeket.

## 6. Igényelt üzleti folyamatok modellje

## 7. Követelménylista

| Id | Modul | Név | Leírás |
| :---: | --- | --- | --- |
| K1 | Felhasználói rendszer | Bejelentkezés | A felhasználó be tud jelentkezni az alkalmazásba |
| K2 | Felhasználói rendszer | Jelszó változtatás | A regisztrált felhasználók módosíthatják a jelszavukat |
| K3 | Megjelenítés | Folyamatok megjelenítése | A felhasználók láthatják az aktuálisan futó folyamatokat |
| K4 | Leállítás | Folyamat leállítása | A felhasználó leállíthatja a kiválasztott folyamatot |
| K5 | Tallózás | Fájlok és mappák megjelenítése | A felhasználók böngészhetnek a fájlok és mappák között |
| K6 | Vizsgálat | Fájlok és mappák ellenőrzése | A felhasználók átvizsgálhatják a kiválasztott fájlokat vagy mappákat |
| K7 | Frissítés | Vírusdefiníciók frissítése | Az alkalmazás frissíti a vírusdefiníciókat, hogy mindig naprakész legyen a védelem |
| K8 | Értesítés | Felhasználói értesítések | A rendszer értesíti a felhasználókat, ha káros állományt találtak a rendszerben |
