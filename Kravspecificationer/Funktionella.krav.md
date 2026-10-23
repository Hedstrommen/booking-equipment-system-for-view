
# Funktionella krav

**FK01 – Visa utrustningsmodeller**
Koppling: K01
Systemet ska visa en lista över utrustningsmodeller med namn, beskrivning, bild, kategori och dagspris.

**FK02 – Visa modellinformation i detalj (Från hans svar)**
Koppling: K01
Systemet ska visa detaljerad information om en vald modell, inklusive pris, beskrivning, bild, kända problem och skador samt tillverkaren 

**FK03 – Kontrollera tillgänglighet för vald period**
Koppling: K02
Systemet ska kunna kontrollera om det finns minst ett ledigt exemplar av en modell under en vald period.

**FK04 – Skapa kundkonto**
Koppling: K03
Systemet ska låta kunden skapa ett konto med namn, organisationsnummer, e‑post och telefonnummer.

**FK05 – Kundinloggning**
Koppling: K03
Kunder ska kunna logga in i systemet med sitt skapade användarkonto.

**FK06 – Skapa bokning**
Koppling: K04
Systemet ska låta en inloggad kund boka ett exemplar av en modell under en sammanhängande period och generera ett bokningsnummer.

**FK07 – Visa kundens bokningar**
Koppling: K05
Systemet ska visa den inloggade kundens kommande och tidigare bokningar.

**FK08 – Avboka bokning**
Koppling: K06
Systemet ska låta kunden avboka en bokning fram till dagen före första hyresdagen.

**FK09 – Personalbokning**
Koppling: K07
Personal ska kunna söka efter bokningar via bokningsnummer eller kunders e-post och skapa bokningar åt kunder.

**FK10 – Registrera utlämning**
Koppling: K08
Systemet ska låta personal registrera att ett specifikt exemplar har lämnats ut, inklusive vem som utförde registreringen.

**FK11 – Registrera återlämning**
Koppling: K08
Systemet ska låta personal registrera att ett exemplar har återlämnats.

**FK12 – Markera exemplar som otillgängligt**
Koppling: K09
Systemet ska låta personal markera ett exemplar som otillgängligt och ange orsak.

**FK13 – Visa berörda bokningar vid otillgänglighet**
Koppling: K10
Systemet ska visa vilka framtida bokningar som påverkas när ett exemplar blir otillgängligt.

**FK14 – Tilldela nytt exemplar**
Koppling: K10
Systemet ska låta personal tilldela ett annat ledigt exemplar av samma modell.

**FK15 – Hantera utrustningsmodeller och exemplar**
Koppling: K11
Administratörer ska kunna lägga till, uppdatera och ta bort utrustningsmodeller och exemplar.

**FK16 – Hantera dagspriser**
Koppling: K11
Administratörer ska kunna uppdatera dagspriser för modeller.

**FK17 – Visa totalpris före bekräftelse**
Koppling: K12
Systemet ska visa totalpris för bokningen innan kunden bekräftar.

**FK18 – Spara pris vid bokningstillfället**
Koppling: K12
Systemet ska spara det överenskomna priset även om dagspriset ändras senare.