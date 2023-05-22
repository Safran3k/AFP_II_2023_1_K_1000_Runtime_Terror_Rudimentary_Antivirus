# Tesztjegyzőkönyv

Teszteléseket végezte: Bálint Ádám

Operációs rendszer: Windows 11

Ebben a dokumentumban lesz felsorolva az elvégzett tesztek elvárásai és eredményei, illetve időpontjai (Alfa, Béta és Végleges verzió).

## Alfa teszt

| Vizsgálat | Tesztelés időpontja | Elvárás | Eredmény | Hibák |
| :---: | --- | --- | --- | --- |
| A1-Regisztráció | 2023.05.02 | Helyes formátumú adatok bevitele során megtörténik a regisztráció | Sikeres a regisztráció | Nincs |
| A2-Regisztráció | 2023.05.02 | Felhasználónév üresen hagyása után hibaüzenet megjelenése | Hibaüzenet megjelenik | Nincs |
| A3-Regisztráció | 2023.05.02 | Jelszó üresen hagyása után hibaüzenet megjelenése | Hibaüzenet megjelenik | Nincs |
| A4-Regisztráció | 2023.05.02 | Mindhárom mező üresen hagyása után hibaüzenet megjelenése | Hibaüzenet megjelenik | Nincs |
| A5-Regisztráció | 2023.05.02 | Eltérő jelszavak beírása után hibaüzenet megjelenése | Hibaüzenet megjelenik | Nincs |
| A6-Bejelentkezés| 2023.05.02 | Regisztrált felhasználó megfelelő adatok beírása során be tud jelentkezni | A bejelentkezés sikeres| Nincs |
| A7-Bejelentkezés| 2023.05.02 | Regisztrált felhasználó helytelen felhasználónév beírása során hibaüzenet megjelenése | Hibaüzenet megjelenik | Nincs |
| A8-Bejelentkezés| 2023.05.02 | Regisztrált felhasználó helytelen jelszó beírása során hibaüzenet megjelenése | Hibaüzenet | Nincs |
| A9-Vendég | 2023.05.02 | "Folytatás vendégként" opció választásakor MainWindow megjelenése | MainWindow megjelenik | Nincs |

Az Alfa tesztelés során a vizsgált elemek mind hibátlanul működtek mindenféle fennakadások nélkül.

## Béta teszt

| Vizsgálat | Tesztelés időpontja | Elvárás | Eredmény | Hibák |
| :---: | --- | --- | --- | --- |
| B1-Vendég(Task) | 2023.05.21. | Vendégként való bejelentkezés után nem jelennek meg az éppen futó fájlok | Az éppen futó programok nem jelennek meg | Nincs |
| B2-Bejelentkezés(Task) | 2023.05.21. | Sikeres bejelentkezés után megjelennek az éppen futó programok a listboxban | Az éppen futó programok megjelennek | Nincs |
| B3-Bejelentkezés(Task) | 2023.05.21. | Feladat befejezése gombra kattintva a kijelölt fájl bezáródik | Sikeresen bezáródik a kijelölt elem | Nincs |
| B4-Bejelentkezés(Scanner) | 2023.05.21. | Az "Ellenőrzés" gombra kattintva megnyílik a fájlkezelő | A fájlkezelő megnyílik | Nincs |
| B5-Bejelentkezés(Scanner) | 2023.05.21. | Gyanús fájl gombra kattintva megnyílik a fájlkezelő | A fájlkezelő megnyílik | Nincs |
| B6-Bejelentkezés(Scanner) | 2023.05.21. | Gyanús fájl kiválasztása után elhelyezi a hash kódját a db-ben | A hash kód elhelyeződik a db-ben | Nincs |
| B7-Scanner | 2023.05.21. | A "Scanner" fülre kattintva átvált a Scannerre | Sikeresen átvált | Nincs |
| B8-Scanner | 2023.05.21. | A vizsgálandó mappa kiválasztása után a vírusirtó jelzi annak biztonságosságát | Sikeresen jelzi | Nincs |
| B9-Scanner | 2023.05.21. | Kilépés gombra kattintva a vírusirtó kijelentkezik a felhasználóból | Sikeres kilépés | Nincs |
| B10-Scanner | 2023.05.22. | Az ellenőrzés gombra kattintva a progress bar működésbe lép | Elindul a progress bar | Nincs |


A Béta teszt sikeresen zajlott.
Az Béta tesztelés során a vizsgált elemek mind hibátlanul működtek mindenféle fennakadások nélkül.

A végleges tesztelés során az összes fent felsorolt vizsgálati elem újra ellenőrzésre kerül. Ezzel együtt az új funkciók is tesztelésre kerültek.

## Végleges teszt
| Vizsgálat | Tesztelés időpontja | Elvárás | Eredmény | Hibák |
| :---: | --- | --- | --- | --- |
| V1-Regisztráció | 2023.05.22 | Helyes formátumú adatok bevitele során megtörténik a regisztráció | Sikeres a regisztráció | Nincs |
| V2-Regisztráció | 2023.05.22 | Felhasználónév üresen hagyása után hibaüzenet megjelenése | Hibaüzenet megjelenik | Nincs |
| V3-Regisztráció | 2023.05.22 | Jelszó üresen hagyása után hibaüzenet megjelenése | Hibaüzenet megjelenik | Nincs |
| V4-Regisztráció | 2023.05.22 | Mindhárom mező üresen hagyása után hibaüzenet megjelenése | Hibaüzenet megjelenik | Nincs |
| V5-Regisztráció | 2023.05.22 | Eltérő jelszavak beírása után hibaüzenet megjelenése | Hibaüzenet megjelenik | Nincs |
| V6-Bejelentkezés| 2023.05.22 | Regisztrált felhasználó megfelelő adatok beírása során be tud jelentkezni | A bejelentkezés sikeres| Nincs |
| V7-Bejelentkezés| 2023.05.22 | Regisztrált felhasználó helytelen felhasználónév beírása során hibaüzenet megjelenése | Hibaüzenet megjelenik | Nincs |
| V8-Bejelentkezés| 2023.05.22 | Regisztrált felhasználó helytelen jelszó beírása során hibaüzenet megjelenése | Hibaüzenet | Nincs |
| V9-Vendég | 2023.05.22 | "Folytatás vendégként" opció választásakor MainWindow megjelenése | MainWindow megjelenik | Nincs |
| V10-Vendég(Task) | 2023.05.21. | Vendégként való bejelentkezés után nem jelennek meg az éppen futó fájlok | Az éppen futó programok nem jelennek meg | Nincs |
| V11-Bejelentkezés(Task) | 2023.05.22. | Sikeres bejelentkezés után megjelennek az éppen futó programok a listboxban | Az éppen futó programok megjelennek | Nincs |
| V12-Bejelentkezés(Task) | 2023.05.22. | Feladat befejezése gombra kattintva a kijelölt fájl bezáródik | Sikeresen bezáródik a kijelölt elem | Nincs |
| V13-Bejelentkezés(Scanner) | 2023.05.22. | Az "Ellenőrzés" gombra kattintva megnyílik a fájlkezelő | A fájlkezelő megnyílik | Nincs |
| V14-Bejelentkezés(Scanner) | 2023.05.22. | Gyanús fájl gombra kattintva megnyílik a fájlkezelő | A fájlkezelő megnyílik | Nincs |
| V15-Bejelentkezés(Scanner) | 2023.05.22. | Gyanús fájl kiválasztása után elhelyezi a hash kódját a db-ben | A hash kód elhelyeződik a db-ben | Nincs |
| V16-Scanner | 2023.05.22. | A "Scanner" fülre kattintva átvált a Scannerre | Sikeresen átvált | Nincs |
| V17-Scanner | 2023.05.22. | A vizsgálandó mappa kiválasztása után a vírusirtó jelzi annak biztonságosságát | Sikeresen jelzi | Nincs |
| V18-Scanner | 2023.05.22. | Kilépés gombra kattintva a vírusirtó kijelentkezik a felhasználóból | Sikeres kilépés | Nincs |
| V19-Scanner | 2023.05.22. | Az ellenőrzés gombra kattintva a progress bar működésbe lép | Elindul a progress bar | Nincs |

A Végleges teszt lezajlott és minden funkció rendesen működik, esztétikailag is megfelelő a program.

Átadásra készen áll a megrendelőnek.

Tesztelést végezte és írta: Bálint Ádám

Befejezve: 2023.05.22.
