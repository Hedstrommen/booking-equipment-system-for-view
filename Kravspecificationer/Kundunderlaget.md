#Kundunderlag - Bokningssystem för SXX Maskiner och Utrustning AB

## Bakgrund

SXX Maskiner och Utrustning AB är ett mindre företag som hyr ut verktyg och maskiner
till byggföretag. Vi har en anläggning med uthyrningsdisk och lager. Hos oss arbetar sex
personer.

Vi hyr bland annat ut borrhammare, golvslipar, städmaskiner och rivningsrobotar. Vi har
ofta flera exemplar av samma modell. Två städmaskiner kan exempelvis vara av samma
modell, men varje exemplar har ett eget inventarienummer och hanteras separat.
I dag tar vi emot bokningar via telefon, e-post och besök. Bokningarna skrivs idag in i en
gemensam kalender och uppgifter om kunder och utrustning finns i olika kalkylblad. Det
fungerar, men det händer att samma utrustning bokas till flera kunder eller att
personalen lovar ut något som är trasigt.

Vi vill därför beställa ett webbaserat system för bokning, utlämning och återlämning.

## Vad vi vill uppnå

Vi vill att kunderna enklare ska kunna boka utrustning och att personalen ska få en
gemensam bild av vad som är bokat, uthyrt och tillgängligt.

Den första versionen ska stödja arbetet vid vår nuvarande anläggning. Vi behöver inte
något avancerat affärssystem.

## Vilka som ska använda systemet
• Kunder ska kunna se utrustning, göra bokningar och hantera sina egna
bokningar.
• Personal ska kunna hjälpa kunder med bokningar och registrera utlämning och
återlämning.
• Administratörer ska dessutom kunna lägga till och uppdatera utrustning samt
hantera personalens behörigheter.

En anställd kan ha både personalbehörighet och administratörsbehörighet.

## Funktioner vi behöver

K01 Besökare ska kunna se vilka utrustningsmodeller vi erbjuder. För varje modell
ska namn, beskrivning, kategori och pris per dag visas.

K02 Kunden ska kunna välja en utrustningsmodell och en period och se om det finns
något tillgängligt exemplar. Kunden behöver inte kunna välja ett särskilt
inventarienummer.

K03 Kunden ska kunna skapa ett konto med namn, orgnr, e-postadress och
telefonnummer. Kunden ska vara inloggad för att göra en bokning.

K04 Kunden ska kunna boka ett exemplar av en modell under en sammanhängande
period. Kunden ska få ett bokningsnummer och kunna se sin bokning direkt i
systemet.

K05 Kunden ska kunna se sina egna kommande och tidigare bokningar. En kund ska
inte kunna se andra kunders bokningar.

K06 Kunden ska kunna avboka en bokning fram till dagen före bokningens första dag.
Därefter måste kunden kontakta personalen.

K07 Personalen ska kunna söka efter bokningar med bokningsnummer eller kundens
e-postadress och skapa bokningar åt kunder. Samma tillgänglighetsregler ska
gälla som vid kundens egen bokning.

K08 Personalen ska kunna registrera att utrustning har lämnats ut och att den har
återlämnats. Det ska framgå vilket exemplar som lämnats ut och vem som
registrerade respektive händelse.

K09 Personalen ska kunna markera ett exemplar som otillgängligt, exempelvis på
grund av skada eller service, och ange en orsak. Exemplaret ska inte kunna
användas för nya bokningar så länge det är otillgängligt.

K10 Om ett exemplar blir otillgängligt ska personalen kunna se vilka framtida
bokningar som berörs. Personalen ska kunna tilldela ett annat ledigt exemplar
av samma modell. Om inget finns hanterar personalen kontakten med kunden
utanför systemet.

K11 Administratören ska kunna lägga till och uppdatera utrustningsmodeller,
exemplar och dagspriser. Utrustning som förekommer i tidigare bokningar ska
kunna tas ur sortimentet utan att bokningshistoriken försvinner.

K12 Kunden ska före bekräftelse kunna se bokningens totalpris. Det överenskomna
priset ska finnas kvar på bokningen även om vi senare ändrar dagspriset.

## Regler för bokningar
• Bokningar görs i hela kalenderdagar. Både första och sista dagen räknas som
hyresdagar.
• Ett exemplar som är bokat till och med fredag kan tidigast bokas av en annan
kund från måndag.
• En bokning gäller ett exemplar av en utrustningsmodell. Kunden får göra flera
separata bokningar om flera saker behövs.
• Bokningens första dag får inte ligga bakåt i tiden.
• Ett exemplar ska reserveras när bokningen bekräftas.
• Samma exemplar får inte ha överlappande aktiva bokningar. Det gäller även om
två kunder försöker boka samtidigt.
• En avbokning ska frigöra exemplaret för nya bokningar.
• En påbörjad uthyrning får inte avbokas.
• En tidig återlämning ändrar inte automatiskt bokningens pris.
• Systemet ska inte automatiskt avboka kundbokningar när utrustning markeras
som otillgänglig.

## Övriga förväntningar
• Kundernas bokningsflöde ska fungera på mobiltelefon och dator.
• Kunden ska kunna förstå varför en bokning inte går att genomföra, exempelvis om perioden är ogiltig eller utrustningen inte längre är tillgänglig.

Betalning, fakturering, depositioner ska inte ingå i detta då vi har detta i andra system som vi inte planerar på att koppla ihop just nu.

Personalen kontrollerar legitimation vid utlämning och hanterar betalningen i vårt
befintliga kassasystem. Systemet behöver inte lagra kopior av legitimationer.

Vi vill först få ett underlag som visar att ni har förstått verksamheten och föreslår ett
genomförbart system. Vi vill sedan diskutera underlaget innan vi bestämmer oss för att
genomföra detta. Så vi vill inte ha ett system precis just nu utan ett underlag.