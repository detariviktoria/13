const watches = 
[
    {
        price: 9999,
        materials: ["fa"],
        owner: "Szabó Dániel",
        brand: "Rolex",
        termesz: true,
        hoscincer: true,
    },
    {
        price: 16451,
        materials: ["acél"],
        owner: "Kássa Gergő",
        brand: "Rolex",
    },
    {
        price: 94709,
        materials: ["acél"],
        owner: "Szabó Emánuel",
        brand: "Patek Philippe",
    },
    {
        price: 21812,
        materials: ["acél"],
        owner: "Szabó Emánuel",
        brand: "Patek Philippe",
    },
    {
        price: 1636,
        materials: ["arany", "acél"],
        owner: "Szabó Dániel",
        brand: "TAG Heuer",
    },
    {
        price: 1636,
        materials: ["arany", "acél"],
        owner: "Kássa Gergő",
        brand: "TAG Heuer",
    },
    {
        price: 37687,
        materials: ["platinum"],
        owner: "Farkas Norbert Levente",
        brand: "Cartier",
    },
]

// Készíts egy GET metódust megvalósító függvényt a 
//controlleredben.
exports.getWatches = (req, res, next) =>
{
    res.status(200).json(watches);
}

// Készíts egy paraméteres GET metódust, amiben 
// válaszolni fogunk a kérés paramétereiben található
// márkájú órákkal.
exports.getWatchesByBrand = (req, res, next) => 
{
    res.status(200).json(watches.filter(item => item.brand == req.watchBrand));
}

// Készíts egy DELETE metódust megvalósító metódust a 
// controlleredben, amiben töröljük a kérés törzsében
// megadott adatok alapján az órákat.
// A metódus neve legyen: deleteWatch
exports.deleteWatch = (req, res, next) => 
{
    try
    {
        const { watchOwnerName, watchBrandName } = req.body || {};

        if(!watchOwnerName || !watchBrandName)
        {
            const error = new Error("A kereséshez mindkét adat szükséges!");

            error.status = 404;

            throw error;
        }

        const filteredWatch = watches.filter(item => item.owner == watchOwnerName && item.brand == watchBrandName).pop();

        if(!filteredWatch)
        {
            const error = new Error("Nem található ilyen óra!");

            error.status = 404;

            throw error;
        }

        watches.splice(watches.findIndex(item => item === filteredWatch), 1);

        res.status(200).json(filteredWatch);
    }
    catch(error)
    {
        next(error);
    }
}