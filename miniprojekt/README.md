Plemiona

wioska:
- zawierają budynki

klasa abstrakcyjna budynek:

klasy dziedziczące:
- tartak
- koszary
- zbrojownia
- farma
- kopalnia kamienia
- kopalnia żelaza
- ratusz (na środku)
- mury obronne
- silos (kamienia, żelaza, zboża)
- stajnia


klasa gracz z atrybutami:
- nazwa
- level
- ilość doświadczenia
- klasa surowce
- nazwa plemienia
- jednostki

plemie:
- lista graczy

ekspedycja:
- level
- doświadczenie 
- stopień obrony
- jednostki
- surowce

surowce zawieraja:
- drewno
- kamień
- zboże
- żelazo

jednostka - klasa abstrakcyjna
level
hp
max ph
energia
max energia
attack speed
obrażenia - type enum [wręcz, range]
odporności

dziedziczą:
- łucznik
- wojownik
- kamikadze
- katapulta
- koń trojański
- husaria
