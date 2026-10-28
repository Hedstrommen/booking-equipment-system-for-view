# Syfte + Huvudsaklig aktör
## syfte:
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


FYLLER PÅ MER SEN /LOVE

#Resultat efter genomförandet

#Koppling till krav och user stories

(Behöver här också hantera att det valda exemplaret hinner bli upptaget innan boknignen bekräftas.)  