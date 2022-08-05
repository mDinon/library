# Microblink Library

Microblink web developer - zadatak

## TODO

**U ovoj sekciji popisano je što bi se još sve trebalo odraditi i popraviti.**

1.  Testovi - potrebno je još dodati projekt s testovima i napisati testove.
2.  Sakriti osjetljive podatke poput connection stringa iz appsettings.json u neki security vault.
3.  Postaviti pipeline za CI/CD.
4.  U web projektu dodati not found page, kod koji se ponavlja izdvojiti u servise, http komunikaciju prebaciti u servise, dodati validacije, srediti css

## Opis rješenja

Baza se kreira pomoću migracija.

Repository i Unit of Work patterni nisu implementirani. EF Core DbContext je sam po sebi Unit of Work tako da je teoretski taj sloj sad suvišan.
Možemo ga koristiti ako želimo ili vidimo potrebnu da jednog dana zamijenimo ORM ili eventualno volimo tako organizirati projekt.
Prednost korištenja DbContexta direktno u servisnom sloju je mogućnost projiciranja direktno u DTO i s time postižemo bolje performanse. Projekcije su moguće i s Repository patternom, ali bi mogli imati puno metoda u pojedinim repozitorijima i dodavali nepotreban overhead.
Ako bi se išlo u implementaciju tih patterna onda bi se trebao kreirati abstraktni RepositoryBase s generičkim metodama. Zatim da bi izbjegli definiranje svih dodatnih repozitorija u UoW klasi možemo dodati repository dictionary i metodu kojom bismo pojedini repozitorij ovisno o entitetu.

## Upute za pokretanje

1.  Otvoriti solution Microblink.Library u Visual Studiu.
2.  Napraviti rebuild solutiona.
3.  Otvoriti Package Manager Console i upisati Update-Database. To će kreirati bazu podataka na lokalnoj instanci SQL servera. (Log tablica se automatski generira kad se pokrene API prvi put)
4.  Pokrenuti Web (npm start) i API projekte. Web projekt je novi .esproj pa ga možete pokrenuti preko Visual Studia 2022 tako da se klikne desni klik na solution i odabere "Set Startup Projects..." opcija i postavi se na "Multiple startup projects" i odabere akcija Start na API i Web projekte. Prije pokretanja treba pokrenuti naredbu npm ci kako bi se instalirale biblioteke.
5.  Ako se nije browser sam pokrenuo potrebno je pokrenuti browser i otići na URL: https://localhost:3000/ i na https://localhost:44321/swagger/index.html kako bi se pokrenuo swagger.
6.  Ako se API nije pokrenuo na portu 44321 potrebno je provjeriti na kojem se portu pokrenuo i otvoriti u Web projektu /src/config.json i promijeniti port.
