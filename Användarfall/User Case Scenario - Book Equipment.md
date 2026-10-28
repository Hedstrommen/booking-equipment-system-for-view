# Syfte + Huvudsaklig aktör
## Syfte:
Att låta en inloggad kund boka ett tillgängligt exemplar av en utrustningsmodell under en sammanhängande period, få ett unikt bokningsnummer samt se bokningens totalpris innan bekräftelse. 

## Huvudsaklig aktör
Inloggad kund

## Sekundära aktörer
Personal (som kan skapa bokningar åt kunder enligt samma regler)

#Förustättningar
- kunden har skapat konto (FK04) och är inloggad (KK05)
- Det finns minst en utrustningsmodell med registrerade exemplar och dagspris i systemet
- Kunden har valt modell och period för bokningens
- Systemet kan identifiera exemplar som är bokad, uttagna eller markerade som ottillgängliga (VR06, VR12)

#Huvudflöde
1. Kunden navigerar till bokningsflödet och väljer en utrustningsmodell
2. Kunden väljer startdatum och slutdatum för hyresperioden
3. Systemet kontrollerar att perioden är giltig - startdatum får inte ligga bakåt i tiden (VR04)
4. Systemet kontrollerar tillgången - att minst ett exemplar av modellen är ledigt hela perioden, med hänsyn till:
    - befintliga aktiva bokningar (VR06)
    - fredag-måndag-regeln med helgdagar som spärrtid (VR02)
    - Exemplar markerade som otillgängliga (VR12)
5. Systemet beräknar totalpriset: antal hyresdagar (båda första och sista dagen räknas, VR01 * dagspris (FK17))
6. Systemet visar totalpris och bokningsöversökt för kunden innan bekräftelse (FK17)
7. Kunden bekräftar bokningen
8. Systemet reserverar ett specifikt exemplar (VR05), med skydd mot samtidiga bokningsförsök (KK03, KK07, VR06)
9. Systemet sparar det överenskomna priset på bokningen (VR13, FK18)
10. Systemet genererar ett unikt bokningsnummer (FK06)
11. Systemet bekräftar bokningen och visar den direkt i kundens bokningslista (FK06, FK07)

#Alternativa flöden
## A1 - Kunden är inte inloggad
1. Kunden försöker påbörja bokningen utan att vara inloggad
2. Systemet hänvisar till inloggning/skapa konto (FK05, KK05)
3. Flödet återupptas efter inloggning

## A2 - Ogiltig 
1. Startdatum ligger i dåtid (VR04) eller slutdatum föregår startdatum
2. Systemet visar ett tydligt felmeddelande som förklarar varför bokningen inte kan genomföras (KK02)
3. Kunden får möjlighet att ändra perioden

## A3 - Inget exemplar tillgängligt
1. Alla exemplar av modellen är bokade eller otillgängliga under vald period (VR06, VR12)
2. Systemet informerar kunden tydligt om att modellen inte är tillgänglig (KK02)
3. Kunden kan välja en annan period eller modell

## A4 - Exemplaret blir upptaget under pågågende bokning (samtidighetskonflikt)
1. Ett annat bokningsförsök reserverar sista lediga exemplaret mellan steg 4 och 8
2. Systemet upptäcker konflikten vid reserveringen (KK03, KK07)
3. Kunden informeras och kan välja ny period eller modell

## A5 - Bokning skapas av personal åt kund
1. Personal söker fram kunden via e-postadress (FK09)
2. Personal skapar bokningen åt kunden enligt exakt samma tillgänglighetsregler som kundens egen bokning (VR06, K07)
3. Bokningen registreras på kunden med bokningsnummer

#Resultat efter genomförandet

## Lyckat fall
- En bokning finns registrerad med unikt bokningsnummer, kopplad till kunden och ett reserverat exemplar (VR05)
- Bokningens pris är sparat och påverkas inte av framtida dagsprisändringar (VR13, FK18)
- Bokningen är synlig i kundens lista över kommande bokningar (FK07)
- Exemplaret är spärrat för överlappande bokningar under perioden (VR06, KK03)

## Misslyckat fall
- Ingen bokning har skapats
- Inget exemplar har reserverats
- Kunden har fått ett tydligt felmeddelande som förklarar orsaken (KK02)

#Koppling till krav och user stories
## Koppling till user stories
   User Story | Formulering | Koppling |
 |------------|-------------|----------|
 | **US01** | Som **kund** vill jag se om en utrustningsmodell är tillgänglig under en vald period, **för att** slippa boka något som redan är upptaget | Steg 4, A3 |
 | **US02** | Som **kund** vill jag se bokningens totalpris innan jag bekräftar, **för att** veta vad jag betalar | Steg 5–6 |
 | **US03** | Som **kund** vill jag få ett bokningsnummer när jag bokat, **för att** enkelt kunna hänvisa till min bokning | Steg 10–11 |
 | **US04** | Som **kund** vill jag få ett tydligt felmeddelande om bokningen inte kan genomföras, **för att** förstå vad jag behöver ändra | A2–A4 |
 | **US05** | Som **personal** vill jag kunna skapa bokningar åt kunder enligt samma regler, **för att** kunna hjälpa kunder som kontaktar oss | A5 |


## Koppling till krav
   Krav | Beskrivning | Var i flödet |
 |------|-------------|--------------|
 | **K02** | Kontrollera tillgänglighet för vald period | Steg 4 |
 | **K04** | Boka exemplar, få bokningsnummer | Steg 7–11 |
 | **K07** | Personal bokar åt kund, samma regler | A5 |
 | **K12** | Totalpris före bekräftelse, sparat pris | Steg 5–6, 9 |
 | **FK03** | Kontrollera tillgänglighet | Steg 4 |
 | **FK06** | Skapa bokning + bokningsnummer | Steg 8–11 |
 | **FK09** | Personalbokning | A5 |
 | **FK17** | Visa totalpris före bekräftelse | Steg 6 |
 | **FK18** | Spara pris vid bokningstillfället | Steg 9 |
 | **VR01** | Hela kalenderdagar, båda dagarna räknas | Steg 5 |
 | **VR02** | Fredag→måndag, helgdagar spärrtid | Steg 4 |
 | **VR04** | Startdatum ej bakåt i tiden | Steg 3 |
 | **VR05** | Exemplar reserveras vid bekräftelse | Steg 8 |
 | **VR06** | Inga överlappande aktiva bokningar | Steg 4, 8, A4 |
 | **VR12** | Otillgängliga exemplar kan ej bokas | Steg 4, A3 |
 | **VR13** | Överenskommet pris bevaras | Steg 9 |
 | **KK02** | Tydliga felmeddelanden | A2, A3, A4 |
 | **KK03** | Inga överlappande bokningar (dataintegritet) | Steg 8, A4 |
 | **KK05** | Endast inloggad kund kan boka | Förutsättning, A1 |
 | **KK07** | Robusthet vid samtidiga bokningar | Steg 8, A4 |


(Behöver här också hantera att det valda exemplaret hinner bli upptaget innan boknignen bekräftas.)  