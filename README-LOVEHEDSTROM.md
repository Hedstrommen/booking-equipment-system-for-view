# 1. Välj och avgränsa funktionalitet
Jag valde user stories och feature som en kollega skrivit: user story 22 och user story 23. De ingick i feature 13. Jag tyckte både US22 och US23 flöden hade så pass mycket med varandra att göra med varandra att jag valde att hantera båda i denna uppgift och således hela featuren.

## F-13 = Bokning - Visa totalpris före bekräftelse
### Beskrivning och syfte
Hanterar beräkning och visning av bokningens totalpris inann kunden bekräftar bokningen. Det ska säkerställa att kunden får veta den totala kostnaden innan bokningen bekräftas. 

### Omfattning
Hämta dagspris för vald utrustning
Beräkna antal hyresdagar utifrån vald hyresperiod
Beräkna totalpriset utifrån dagspris och antal hyresdagar
Visa totalpriset innan kunden bekräftar bokningen

### Avgränsningar
Genomföra betalningar
Skapa fakturor
Ändra dagspriser
Spara det överenskomna priset på bokningen

### Kundkrav / Verksamhetskrav / Kvalitetskrav
K12, VR01, KK01

## US22 = "Som kund vill jag att totalpriset för min bokning beräknas utifrån utrustningens dagspris och vald hyresperiod så att jag vet vad uthyrningen kommer att kosta."

### Acceptanskriterier
#### AC1
**Given** att kunden har valt en utrustningsmodell med ett registrerat dagspris
**When** kunden väljer en giltig hyresperiod med startdatum och slutdatum
**Then** ska systemet beräkna totalpriset genom att multiplicera dagspriset med antalet hyresdagar.

#### AC2
**Given** att kunden har valt en hyresperiod
**When** systemet beräknar antalet hyresdagar
**Then** ska både startdatum och slutdatum räknas som hyresdagar.

#### AC3
**Given** att kunden har valt utrustning och en hyresperiod
**When** kunden ändrar startdatum eller slutdatum
**Then** ska systemet beräkna om totalpriset utifrån den nya hyresperioden.

### Verksamhetsregler och kvalitetskrav
VR01, KK01

## US23 = "US-23 - Som kund vill jag kunna se totalpriset innan jag bekräftar min bokning så att jag kan ta ställning till kostnaden."

### Acceptanskriterier
#### AC1
**Given** att kunden har valt utrustning och hyresperiod
**When** systemet har beräknat totalpriset
**Then** ska totalpriset visas för kunden innan bokningen bekräftas.

#### AC2
**Given** att kunden har valt en utrustningsmodell och en hyresperiod
**When** totalpriset visas
**Then** ska beloppet motsvara det beräknade totalpriset för den valda hyresperioden.

#### AC3
**Given** att kunden ser totalpriset för sin bokning
**When** kunden ändrar hyresperioden till en annan giltig hyresperiod
**Then** ska det uppdaterade totalpriset visas innan kunden bekräftar bokningen.

### Verksamhetsregler och kvalitetskrav
VR01, KK01




# 2. Modellera funktionaliteten
Samtliga klass- och varibalenamn är preliminära då jag vet att när jag väl börjar skriva koden kommer jag säket att upptäcka behov av förändring, likaså med diagrammen. Jag försöker hålla mig till dom men tar mig friheten att justera om funktionaliteten/logiken/läsbarheten kräver det. 

## Ansvarsfördelning -TODO

## Koppling diagram - TODO
(Hur motsvaras aktiviteter och beslut i aktivitetsdiagrammet av samverkan mellan objekten i sekvensdiagrammet?)

## Inledande aktivitetsdiagram

### UML kod Inledande aktivitetsdiagram:

@startuml PrisvisningForeBekraftelse_Aktivitet
title F-12 US-22 US-23 Beräkna och visa totalpris före bekräftelse
skinparam monochrome true
skinparam shadowing false

start
repeat
  :Välj utrustningsmodell;
  :Hämta dagspris för vald modell;

  if (Finns registrerat dagspris?) then (ja)
    :Välj hyresperiod med startdatum och slutdatum;
    :Anropa CalculateTotalPrice(dailyPrice, startDate, endDate);
    :Validera indata: dagspris och period;

    if (Är perioden giltig?) then (ja - giltig)
      :Beräkna antal hyresdagar som slutdatum minus startdatum plus 1;
      :Beräkna totalpris som dagspris gånger antal hyresdagar;
      :Avrunda till 2 decimaler;
      :Visa modell, dagspris, period, antal dagar och totalpris;
      :Ställ bekräftelsefrågan J eller N;
      :Kunden läser totalpriset och svarar J eller N;
    else (nej - ogiltig)
      :Visa felmeddelande om ogiltig hyresperiod;
    endif
  else (nej - saknas)
    :Visa felmeddelande om saknat dagspris;
  endif
repeat while (Dagspris saknas, perioden ogiltig eller kunden svarade N?) is (ja - nytt val) not (nej - bokning bekräftad)

:Fortsätt till bokningsskapande som ägs av annan feature;
stop
@enduml

### Bild:
Se bifogad bild: Inledande Aktivitetsdiagram    

## Slutgiltigt aktivitetsdiagram - TODO

### UML kod slutgiltigt aktivitetsdiagram: - TODO

### Bild slutgiltigt aktivitetsdiagram: -TODO
Se bifogad fil: Slutgiltigt Aktivitetsdiagram.png

## Inledande sekvensdiagram

### UML kod inledande sekvensdiagram:
@startuml ShowTotalPriceBeforeConfirmation_Sequence
title Calculate and display total price before confirmation
hide footbox
autonumber
skinparam monochrome true
skinparam shadowing false

actor Customer
participant "ConsoleUI" as UI <<boundary>>
participant "EquipmentModel" as Model <<entity>>
participant "PriceCalculation" as PC <<control>>

loop [Until booking is confirmed]
  Customer -> UI : SelectModel()
  activate UI
  UI -> Model : GetDailyPrice()
  activate Model
  Model --> UI : dailyPrice
  deactivate Model

  Customer -> UI : SelectOrChangePeriod(startDate, endDate)
  UI -> PC : CalculateTotalPrice(dailyPrice, startDate, endDate)
  activate PC
  PC -> PC : ValidateInput(dailyPrice, startDate, endDate)

  alt [c Validation successful]
    PC -> PC : CalculateRentDays(startDate, endDate)
    note right of PC
      Both startDate and endDate are
      counted as rental days (VR01)
    end note
    PC -> PC : RoundToTwoDecimals(totalPrice)
    PC --> UI : totalPrice
    deactivate PC
    UI --> Customer : DisplayPriceSummary(model, dailyPrice, period, rentDays, totalPrice)
    UI --> Customer : AskForConfirmation()
    Customer -> UI : answer Yes or No
  else [c Validation failed]
    PC --> UI : error: ArgumentException
    deactivate PC
    UI --> Customer : DisplayErrorMessage()
  end
end

UI --> Customer : ContinueToBookingCreation()
@enduml

### Bild inledande sekvensdiagram:
Se bifogad bild: Inledande Sekvensdiagram

## Slutgiltigt sekvensdiagram - TODO

### UML kod slutgiltigt sekvensdiagram: -TODO

### Bild slutgiltigt sekvensdiagram: -TODO

# 3. Implementera och verifiera designen
- [ ] Innehåller klasser, objekt och metoder som behövs för att genomför valt flöde
- [ ] Ansvarsfördelning ska gå att följa mellan koden och sekvensdiagrammet
- [ ] Objektens samverkan ska gå att följa mellan koden och sekvensdiagrammet
- [ ] Minst 1 scenario där huvudflödet genomförs ska verifieras
- [ ] Minst 1 scenario där alternativt flöde inträffar
- [ ] Välj manuell körning, automatiserade tester eller kombination
- [ ] Lämnas in på publik GitHub (har gjort allt i DevOps - koll med Hans: ok, bjud in honom bara)

# 4. Analysera resultatet
Beskriv
- [ ] Hur verifiering visar att funktionaliteten följer aktivitetsdiagrammet
- [ ] Hur implementationsens objekt och metodanrop motsvarar sekvensdiagrammet
- [ ] Om ansvarsfördelningen fungerar som tänkt
- [ ] Vilka förändringar du gjorde i designen och varför



# Tankar: 
- Mina tasks var lite för stora. Jag hade flera steg inuti dom men när jag började arbeta med koden insåg jag att jag inte kunde följa tasken helt och hållet. Jag hade ett annat flow med att skapa arkitekturen och sedan jobba utifrån domainlagret och utåt. 
- Jag lade till mer specifika tasks efterhand för att synliggöra och öva på att skriva task i en mer balanserad storlek. 

- Efter att ha påbörjat själva koden insåg jag också att flödet som jag gjort i aktivitetsdiagrammet och sekvensdiagrammet inte riktigt sätmde överens med flödet i min kod. Vissa validertingar behövdes egentligen inte medan andra lades till. 

- Jag hann med mer än vad jag trodde i iteration 1. 

- Det jag ska göra under iteration 2:
- Skriva klart grundkoden
- Granska om jag har onödiga valideringar
- Granska så koden följer tasks+user stories
- Lägga till mer specifika tasks
- uppdatera diagrammen