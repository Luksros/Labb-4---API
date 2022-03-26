# Labb-4---API

_Hämta alla personer i systemet:_

GET: https://localhost:44354/api/person

_Hämta alla intressen som är kopplade till en specifik person
Hämta alla länkar som är kopplade till en specifik person_

GET: https://localhost:44354/api/person/1

_Koppla en person till ett nytt intresse_
POST: https://localhost:44354/api/hobby

Raw, JSON

{
        "hobbyName": "Birdwatching",
        "description": "Birdwatching, or birding, is the observing of birds, either as a recreational activity or as a form of citizen science.",
        "webLinks": null,
        "personID": 1
    }

_Lägga in nya länkar för en specifik person och ett specifikt intresse_

POST: https://localhost:44354/api/weblink

Raw, JSON

{
        "url": "https://en.wikipedia.org/wiki/Birdwatching",
        "hobbyID": 9
    }
