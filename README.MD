# Parking APp

## specs
Ohjelmistovaatimukset:
Käyttöliittymä, joka simuloi sisääntuloporttia ja pysäköintiin tulevaa autoa.
Auton syöttäminen portille (rekisterinumero).
Backend API kertoo, onko halli täynnä
Valitaan paikka, johon auto pysäköidään, esim. pysäköintipaikka numero 50.
Backend API kertoo, onko paikka vapaa
Syötä auto ulos hallista (rekisterinumero).
Käyttöliittymä ilmoittaa, kuinka paljon pysäköinti maksoi (katso alla olevat hintatiedot).
Backend, joka tallentaa pysäköintitiedot (rekisterinumero, pysäköintipaikka, aika).
Parkkihallin kapasiteetti ja pysäköintihinnat
Kapasiteetti 5 pysäköintipaikkaa
Ensimmäinen 3h, 50snt/alkava 10min.
Seuraavat tunnit 30snt/alkaen 10min.
Erillinen hallintakäyttöliittymä, jossa luetellaan vapaiden paikkojen määrä ja tiedot pysäköidyistä autoista (pysäköintipaikka, rekisterinumero, pysäköintiaika). Tämän tekeminen on vapaaehtoista.




## pohdintoja.
Parempi olisi että heti näkyisi jos halli on täynnä ennen kuin mitään syötetään.
- työjärjestys on outo.

tietokanta -> sqllite
Miksi? kevyt ja säilyttää datan toisin kuin esim inmemory, ja jos tulee katkos palvelussa.

Hinnat configeistalistana:
lista on helppo ylläpitää, ja conffeista helppo vetää. voidaan korvata helposti.
mites jos halutaan päivittää hinta-aikatauluja?

Indexmodel-> service -> repository
indexmodel käsittelee käyttöliittymän kutsut, service sisältää businesslogiikan ja repository hoitaa tietokantahaut.

Parempi olisi että heti näkyisi jos halli on täynnä ennen kuin mitään syötetään.
- työjärjestys on outo.

Listojen vertailu on hidasta, joten jos määrä nousee isoksi käytetään hashmappeja.

Desimaalit koska:
1. Exact Representation of Decimal Numbers

## priorisoitu    
Missä mikäkin data säilytetään.
Yksikkötestaus.
Mikä teknologia on mihinkin käyttöön hyvä.

## Intro
Initialize database by running in root directory:
dotnet tool install --global dotnet-ef
dotnet ef database update

