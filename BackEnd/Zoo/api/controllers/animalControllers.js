const animals =
[
    {
        ID: 129348,
        name: "Majom1",
        species: "Majom",
        color: "brown",
    },
    {
        ID: 178924,
        name: "Majom2",
        species: "Majom",
        color: "light-brown",
    },
    {
        ID: 12489928943,
        name: "Majom3",
        species: "Majom",
        color: "brown",
    },
    {
        ID: 127312948,
        name: "Elefánt1",
        species: "Elefánt",
        color: "gray",
    },
    {
        ID: 13748232,
        name: "Pingvin1",
        species: "Pingvin",
        color: "black",
    },
]

exports.getAnimals = (req, res, next) =>
{
    const { id, name, species, color } = req.query || {};

    let tempAnimals = JSON.parse(JSON.stringify(animals));

    if(id)
    {
        tempAnimals = tempAnimals.find(item => item.ID == id);

        return res.status(200).json(tempAnimals);
    }

    if(name)
    {
        tempAnimals = tempAnimals.find(item => item.name == name);

        return res.status(200).json(tempAnimals);
    }

    if(species)
    {
        tempAnimals = tempAnimals.filter(item => item.species == species);
    }

    if(color)
    {
        tempAnimals = tempAnimals.filter(item => item.color == color);
    }

    res.status(200).json(tempAnimals);
}



// 1. Feladat
// Legyen egy createAnimal metódus, ami a kérés törzséből kapja az adokat és inicializál
// egy új tömb elemet
// /animals
// Válasz: 201 és az animal adatai

exports.createAnimal = (req, res, next) =>
{
    const { animalID, animalName, animalSpecies, animalColor } = req.body;
    
    const newAnimal = {
        ID: animalID,
        name: animalName,
        species: animalSpecies,
        color: animalColor
    }
        
        animals.push (newAnimal)

        res.status(201).json(newAnimal);
    }


// 2. Feladat
// same thing, csak updateAnimal-el (id alapján keressük és url paraméterből)
// /animals/<animalID>
// updatelt animal adatai 200-al

exports.updateAnimal = (req, res, next) =>
{
    const animalID = req.animalID;

    const filteredAnimal = animal.find(item => item.ID == req.animalID);

    filteredAnimal.name = animalName || filteredAnimal.name;

    filteredAnimal.species = animalSpecies || filteredAnimal.species;

    filteredAnimal.color = animalColor || filteredAnimal.color;

    
    res.status(200).json(animals);
}

// get kérés ,body, middleware, controlleres részig amit vettünk
