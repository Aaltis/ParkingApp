# Parking App

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

