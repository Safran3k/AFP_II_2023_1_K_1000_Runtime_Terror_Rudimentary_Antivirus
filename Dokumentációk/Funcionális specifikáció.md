# Funkcionális specifikáció

## Készítette

- Futó Richárd

## 1. Jelenlegi helyzet leírása

Egy olyan kezdetleges vírusirtót fejlesztünk megrendelőnk részére, amely segítségével könnyedén feltudja mérni hogy az adott rendszerén fellelhető-e bárminemű fenyegetés (vírusok, kártékony programok). Illetve, nem titkolt célja ezen alkalmazásnak, hogy későbbiekben a továbvbfejlesztést követően egy teljes értékű és megbízható vírusirtó szolgáltatást nyújtson a megrendelő részére. Másik pozitívum az alkalmazást illetően hogy többféle eszközön elérhető lesz, későbbiekben mobil eszközökre is szeretnénk az alkalmazást lefejleszteni. A megrendelő részére lehetőséget biztosít az alkamazás adott mappák illetve, a különböző precesszek (folyamatok) átvizsgálására.

## 2. Vágyálomrendszer leírása

Az ügyfél célja, hogy olyan hatékony és megbízható vírusirtó rendszert használjon, amely megvédi számítógépeit a vírusoktól és kártevőktől. Ügyfelünk ragaszkodott hozzá hogy .NET framework-öt használjunk, és a fejlesztést C# nyelven valósítsuk meg, ami a nagymértékű támogatottságának, és az objektum orientáltságának köszönhetően lehetővé teszi hogy az alkalmazást későbbiekben tovább fejlesszük. A vágyálomrendszernek tartalmaznia kell a következőket:

 - Automatikus vírusdefiníciók frissítés
 - Hatékony fájlanalízis és víruskeresés
 - Éppen futó folyamatok ellenőrzése
 - Egyszerű használat és felhasználóbarát felület
 - Megfelelő támogatás és karbantartás a hibák és problémák gyors megoldása érdekében

A vágyálomrendszer megvalósítása jelentős mértékben hozzájárulna az ügyfél üzleti folyamatainak hatékonyságához és eredményességéhez.

## 3. Jelenlegi üzleti folyamatok modellje

A jelenlegi üzleti folyamatok modellje szerint a felhasználóknak nincs lehetőségük arra, hogy vírusirtó alkalmazást használjanak. Ennek hiánya nagy kockázatot jelent a vállalat számára, mivel a különböző vírusok, malware-ek és egyéb rosszindulatú programok könnyen megfertőzhetik a számítógépeket és a hálózatot, és ezáltal veszélyeztetik az üzleti folyamatok zavartalan működését, valamint a fontos üzleti adatok biztonságát. A vírusok és más fenyegetések elleni védelem hiánya komoly pénzügyi veszteséget okozhat a vállalatnak, és negatív hatással lehet a vállalat hírnevére is. Ezért elengedhetetlen, hogy bevezessünk egy hatékony vírusvédelmi szoftvert a vállalat számára, amely megfelelően képes védeni a számítógépeket és az adatokat a különböző fenyegetésekkel szemben.

## 4. Igényelt üzleti folyamatok modellje

Az igényelt üzleti folyamatok modellje szerint az alkalmazás lehetővé teszi a felhasználóknak, hogy manuálisan átvizsgálják az állományokat a vírusok és más fenyegetések észlelése érdekében. Az alkalmazás azonosítja a gyanús állományokat, és jelzi a felhasználóknak, ha fenyegetést észlel. A felhasználóknak lehetőségük van arra, hogy kiválasszák az átvizsgálandó mappákat vagy fájlokat, majd az alkalmazás elvégzi az átvizsgálást, és jelzi, ha talált valamilyen fenyegetést. Az alkalmazás ezenkívül képesek lesznek vírusdefiníciókat frissíteni, hogy mindig naprakész legyen a vírusok és más fenyegetések észlelésében. A folyamat egyszerűsödik, így a felhasználók hatékonyabban tudnak védekezni a különböző fenyegetések ellen.
