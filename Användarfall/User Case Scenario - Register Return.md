# Syfte + Huvudsaklig aktör

## Syfte:
Att låta personal registrera att ett specifikt exemplar har återlämnats av kunden, inklusive vem som utförde registreringen, så att exemplaret frigörs för nya bokningar och uthyrningen kan avslutas.

## Huvudsaklig aktör
Personal (inloggad med personalbehörighet)

## Sekundära aktörer
Kund (som lämnar tillbaka utrustningen vid uthyrningsdisken)

# Förutsättningar
- Personal är inloggad med personalbehörighet
- Det finns en bokning där utrustningen har lämnats ut (utlämning är registrerad, FK10)
- Bokningen kan lokaliseras via bokningsnummer eller kundens e-postadress (FK09)
- Systemet kan identifiera vilket specifikt exemplar som lämnats ut (VR03)

# Huvudflöde
1. Kunden anländer till uthyrningsdisken med utrustningen som ska återlämnas
2. Personal söker fram bokningen via bokningsnummer eller kundens e-postadress (FK09)
3. Systemet visar bokningen med status "utlämnad" och vilket exemplar som är kopplat (FK07, FK10)
4. Personal kontrollerar att återlämnat exemplar matchar det utlämnade exemplaret (inventarienummer)
5. Personal registrerar återlämningen i systemet (FK11)
6. Systemet loggar vem som registrerade återlämningen och tidpunkten (KK04)
7. Systemet uppdaterar bokningens status till "genförd/avslutad"
8. Systemet frigör exemplaret för nya bokningar enligt tillgänglighetsreglerna (VR06, VR07)

# Alternativa flöden

## A1 - Exemplaret återlämnas tidigare än planerat
1. Kunden lämnar tillbaka utrustningen före bokningens slutdatum
2. Personal registrerar återlämningen (FK11)
3. Systemet ändrar inte automatiskt bokningens pris - det överenskomna priset kvarstår (VR09)
4. Exemplaret frigörs och kan bokas av nya kunder enligt fredag-måndag-regeln (VR02, VR06)

## A2 - Återlämnat exemplar matchar inte bokningen
1. Inventarienumret på det återlämnade exemplaret stämmer inte med bokningens exemplar
2. Systemet visar en varning och vilken typ av avvikelse som upptäckts (KK02)
3. Personal klarlägger situationen med kunden innan registrering sker
4. Vid behov söker personal upp rätt bokning och flödet återupptas från steg 3

## A3 - Exemplaret återlämnas skadat
1. Personal upptäcker skada på utrustningen vid återlämningen
2. Personal registrerar återlämningen (FK11)
3. Personal markerar exemplaret som otillgängligt med orsaken "skada" (FK12, VR12)
4. Systemet visar vilka framtida bokningar som berörs (FK13)
5. Exemplaret kan inte användas för nya bokningar (VR12)

## A4 - Bokning hittas inte
1. Bokningsnumret eller e-postadressen ger ingen träff (FK09)
2. Systemet visar ett tydligt felmeddelande (KK02)
3. Personal kan söka på nytt eller klarlägger uppgifterna med kunden
4. Flödet återupptas från steg 2

# Resultat efter genomförandet

## Lyckat fall
- Återlämningen är registrerad med tidpunkt och vem som utförde registreringen (KK04)
- Bokningens status är uppdaterad till genomförd/avslutad
- Exemplaret är frigjort för nya bokningar (VR06, VR07)
- Det överenskomna priset på bokningen är bevarat, även vid tidig återlämning (VR09, VR13)

## Misslyckat fall
- Ingen återlämning har registrerats
- Bokningen har kvar status "utlämnad"
- Exemplaret är fortfarande spärrat för nya bokningar
- Personal har fått ett tydligt felmeddelande som förklarar orsaken (KK02)

# Koppling till krav och user stories

## Koppling till user stories
   User Story | Formulering | Koppling |
 |------------|-------------|----------|
 | **US06** | Som **personal** vill jag kunna registrera att utrustning har återlämnats, **för att** få en aktuell bild av vad som är uthyrt och tillgängligt | Steg 5–8 |
 | **US07** | Som **personal** vill jag att det loggas vem som registrerade återlämningen, **för att** vi ska kunna spåra vem som gjorde vad i systemet | Steg 6, KK04 |
 | **US08** | Som **personal** vill jag kunna markera ett skadat exemplar som otillgängligt vid återlämning, **för att** undvika att vi lovar bort trasig utrustning | A3 |
 | **US09** | Som **personal** vill jag kunna söka fram bokningar via bokningsnummer eller kundens e-post, **för att** snabbt kunna hjälpa kunden vid disken | Steg 2, A4 |
 | **US10** | Som **företag** vill vi att det överenskomna priset kvarstår även vid tidig återlämning, **för att** prisbilden ska vara förutsägbar för både oss och kunden | A1 |

## Koppling till krav
 | Krav | Beskrivning | Var i flödet |
 |------|-------------|--------------|
 | **K08** | Registrera utlämning och återlämning, vem som registrerade | Steg 5–6 |
 | **K09** | Markera exemplar som otillgängligt, ange orsak | A3 |
 | **K10** | Visa berörda bokningar vid otillgänglighet | A3 |
 | **FK09** | Söka bokningar via nummer/e-post | Steg 2, A4 |
 | **FK11** | Registrera återlämning | Steg 5 |
 | **FK12** | Markera exemplar som otillgängligt | A3 |
 | **FK13** | Visa berörda bokningar vid otillgänglighet | A3 |
 | **VR02** | Fredag→måndag, helgdagar spärrtid | A1 |
 | **VR06** | Inga överlappande aktiva bokningar | Steg 8 |
 | **VR07** | Avslutad uthyrning frigör exemplar | Steg 8 |
 | **VR09** | Tidig återlämning ändrar inte priset | A1 |
 | **VR12** | Otillgängliga exemplar kan ej bokas | A3 |
 | **VR13** | Överenskommet pris bevaras | A1 |
 | **KK02** | Tydliga felmeddelanden | A2, A4 |
 | **KK04** | Spårbarhet - logga vem som registrerat | Steg 6 |

(Behöver här också hantera att det valda exemplaret hinner bli upptaget innan boknignen bekräftas.)  