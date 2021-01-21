1) Preuzeti projekat i otvoriti pomocu Visual Studia.
2) Promijeniti Connection string u appsettings.json
3) Otvoriti Package Manager Console i otkucati: update-database
4) Pokrenuti projekat i pomocu Swagger UI napraviti prvo Device Type sa zeljenim Featurima (pratiti Sample request umijesto Example Value)
5) Napraviti Device

-----------BITNO--------------

-Sample request je samo primjer pravljenja/udpdejtovanja jer nisam uspio da maknem Example Value koji swagger defaultno generise.
 Za kreiranje podtipa dodati "parentId" (ne stoji u Sample request-u).
-Za kreiranje novog rekorda ne salje se Id, a ako zelimo da izmijenimo neki rekord u bazi saljemo zeljeni id unutar request body-a.
-Posto zadatak ne trazi da se prave metode za Osobine (DeviceFeatures) napravio sam da mogu da se dodaju ili updejtuju preko DeviceType kontrolera.