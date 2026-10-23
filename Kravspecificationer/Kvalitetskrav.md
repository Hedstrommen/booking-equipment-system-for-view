# Kvalitetskrav

**KK01 – Tillgänglighet på mobil och dator**
Systemet ska fungera på både mobiltelefon och dator.

**KK02 – Tydliga felmeddelanden**
Systemet ska ge tydliga förklaringar när en bokning inte kan genomföras (t.ex. ogiltig period, otillgänglig utrustning).

**KK03 – Dataintegritet**
Systemet ska säkerställa att bokningar inte kan överlappa för samma exemplar. Gäller även om två kunder försöker boka samtidigt.

**KK04 – Spårbarhet**
Systemet ska logga vem som registrerat utlämning och återlämning.

**KK05 – Säkerhet kund**
Endast inloggade kunder ska kunna se och hantera sina bokningar. Koppling: K03

**KK06 - Redigerbarhet kund**
Endast inloggade kunder ska kunna redigera sina bokningar (minska/utöka sina bokningar, avboka)

**KK07 – Robusthet vid samtidiga bokningar**
Systemet ska hantera samtidiga bokningsförsök utan att skapa överlappande bokningar.