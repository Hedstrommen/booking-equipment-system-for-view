# Azure DevOps-mallar för bokningssystem

## Projektstruktur

```text
Epic
└── Feature
    └── User Story
        └── Task
```

---

# Epic-mall

## Titel

```text
[EP-XX] Namn på affärsområde
```

## Beskrivning

### Affärsmål

Beskriv det övergripande verksamhetsområdet eller den större delen av systemet som denna Epic omfattar.

### Affärsvärde

Beskriv vilket värde området ger för verksamheten.

### Omfattning

Beskriv vilka funktioner som ingår.

### Koppling till kundkrav

```text
K01, K02, K03
```

---

## Exempel

### Titel

```text
EP-01 Kundbokningar
```

### Affärsmål

Omfattar funktioner relaterade till sökning, bokning och administration av kunders bokningar.

### Affärsvärde

Minskar manuellt arbete och gör det möjligt för kunder att själva boka utrustning.

### Koppling till kundkrav

```text
K02, K03, K04, K05, K06
```

---

# Feature-mall

## Titel

```text
[Område] - [Funktion]
```

## Beskrivning

### Syfte

Beskriv vilken nytta funktionen ger.

### Omfattning

Beskriv vad som ingår.

### Ej inkluderat

Beskriv vad som inte ingår.

### Kundkrav

```text
Kxx, Kxx
```

### Verksamhetsregler

```text
VRxx, VRxx
```

---

## Exempel

### Titel

```text
Bokningar - Skapa bokning
```

### Syfte

Ge kunder möjlighet att boka utrustning online.

### Omfattning

Kunden ska kunna välja modell, period och genomföra en bokning.

### Ej inkluderat

Betalning och fakturering.

### Kundkrav

```text
K02, K03, K04, K12
```

### Verksamhetsregler

```text
VR01, VR04, VR06
```

---

# User Story-mall

## Titel

```text
US-XX Som [roll] vill jag [mål] så att [nytta].
```

## Beskrivning

```text
Som [roll]
vill jag [funktion]
så att [affärsnytta].
```

---

## Acceptance Criteria

### AC1

```gherkin
Given att ...
When ...
Then ...
```

### AC2

```gherkin
Given att ...
When ...
Then ...
```

### AC3

```gherkin
Given att ...
When ...
Then ...
```

---

## Definition of Done

- [ ] Implementerad
- [ ] Kodgranskad
- [ ] Testad
- [ ] Dokumenterad
- [ ] Godkänd av gruppen

---

## Story Points

```text
1 | 2 | 3 | 5 | 8 | 13
```

---

## Prioritet

```text
Låg | Medel | Hög
```

---

## Spårbarhet

### Kundkrav

```text
Kxx
```

### Verksamhetsregler

```text
VRxx
```

---

## Exempel

### Titel

```text
US-05 Som kund vill jag kunna boka en utrustningsmodell så att jag kan reservera utrustning för mitt projekt.
```

### Beskrivning

```text
Som kund
vill jag boka en utrustningsmodell
så att jag kan säkerställa att utrustning finns tillgänglig
när jag behöver den.
```

### Acceptance Criteria

#### AC1

```gherkin
Given att kunden är inloggad
When kunden väljer en ledig modell
Then ska bokning kunna genomföras
```

#### AC2

```gherkin
Given att utrustningen är upptagen
When kunden försöker boka perioden
Then ska systemet visa ett tydligt felmeddelande
```

#### AC3

```gherkin
Given att bokningen genomförs
When kunden bekräftar bokningen
Then ska ett bokningsnummer skapas
```

### Definition of Done

- [ ] Implementerad
- [ ] Testad
- [ ] Dokumenterad

### Story Points

```text
5
```

### Prioritet

```text
Hög
```

### Kundkrav

```text
K02, K04
```

### Verksamhetsregler

```text
VR05, VR06
```

---

# Task-mall

## Titel

```text
[Frontend/Backend/Databas/Test] Kort beskrivning
```

## Beskrivning

### Vad ska göras?

Beskriv uppgiften.

### Varför ska det göras?

Beskriv syftet.

### Beroenden

Beskriv eventuella beroenden.

### Ansvarig

```text
Namn
```

### Uppskattning

```text
Antal timmar
```

---

## Checklista

- [ ] Kod skriven
- [ ] Tester skrivna
- [ ] Tester godkända
- [ ] Pull Request skapad
- [ ] Merge genomförd

---

## Exempel

### Titel

```text
Backend - Implementera bokningslogik
```

### Vad ska göras?

Implementera logik som reserverar ett exemplar när en bokning bekräftas.

### Varför ska det göras?

För att förhindra dubbelbokningar.

### Beroenden

```text
Booking-tabellen måste finnas.
```

### Ansvarig

```text
Anton
```

### Uppskattning

```text
6 timmar
```

### Checklista

- [ ] Kod skriven
- [ ] Enhetstester
- [ ] Integrationstester
- [ ] Pull Request skapad
- [ ] Merge genomförd

---

# Story Point-skala

| Story Points | Beskrivning |
|-------------|-------------|
| 1 | Mycket liten ändring |
| 2 | Enkel uppgift |
| 3 | Liten funktion |
| 5 | Normal funktion |
| 8 | Komplex funktion |
| 13 | Stor eller osäker funktion |

> Om en User Story känns som 21+ bör den delas upp i flera mindre stories.

---

# Namngivningsstandard

## Epics

```text
EP-01 Kundbokningar
EP-02 Lagerhantering
EP-03 Administration
```

## Features

```text
Bokningar - Skapa bokning
Bokningar - Avboka bokning
Utrustning - Tillgänglighetskontroll
```

## User Stories

```text
US-01
US-02
US-03
```

## Tasks

```text
Backend - Skapa BookingService
Frontend - Bygg bokningsformulär
Databas - Skapa Booking-tabell
Test - Integrationstester för bokningar
```

---

# Rekommenderat arbetsflöde

```text
Kundkrav
    ↓
Epic
    ↓
Feature
    ↓
User Story
    ↓
Task
    ↓
Kod & Test
```

Detta säkerställer full spårbarhet från kundens kravspecifikation hela vägen till implementation.