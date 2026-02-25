const fs = require("fs");

const request = require("supertest");

let app = require("../app") || {};

const total = 29;

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

describe("Dolgozat [29p]", () => 
{
    let pont = 0;
    
    afterAll(async () => 
    {
        fs.writeFileSync("pont.txt", `Elért pontod: ${Math.round(pont)}\nÖsszpontszám: ${total}\nSzázalék: ${Math.round(pont / total * 100)}%\nOsztályzat: ${getGrade(pont)}`);
    })

    describe("\n1. Feladat [5p]", () => 
    {
        describe("\tFileokhoz tartozó feladatok", () => 
        {
            test("App és server.js file létezik", async () => 
            {
                const rootFolder = fs.readdirSync("./").map(item => item.toLowerCase());

                expect(rootFolder).toContain("app.js");

                expect(rootFolder).toContain("server.js");

                pont += 1;
            })
        })

        describe("\n\tArchitektúrának megfelelő mappaszerkezet", () => 
        {
            let rootFolder, apiFolder;

            let rootSet, apiSet;

            beforeAll(async () => 
            {
                rootFolder = fs.readdirSync("./").map(item => item.toLowerCase());;
                
                rootSet = new Set(rootFolder);

                if(rootSet.has("api"))
                {
                    apiFolder = fs.readdirSync("./api").map(item => item.toLowerCase()) || fs.readdirSync("API").map(item => item.toLowerCase());

                    apiSet = new Set(apiFolder);
                }
            });

            test("api folder létezik", async () => 
            {
                expect(rootSet).toContain("api");
                
                pont += 1 / 4;
            });

            test.each(
            [
                "routes",
                "middlewares",
                "controllers"
            ])
            ("api folderen belül létezik a %s mappa", (folderName) => 
            {
                expect(apiSet).toContain(folderName);

                pont += 1/4;
            });
        });
        describe("\n\tAz errorHandlerhez tartozó feladatok", () => 
        {
            test("Az errorHandler.js file megfelelő helyen van", () => 
            {
                const middlewareSet = new Set(fs.readdirSync("./api/middlewares").map(item => item.toLowerCase())
                || fs.readdirSync("./API/MIDDLEWARES").map(item => item.toLowerCase()) );

                expect(middlewareSet).toContain("errorhandler.js");

                pont += 1;
            });

            test.each(
            [
                "notFound",
                "showError"
            ])
            ("Az alkalmazás használja az errorHandler.js file %s metódusát", (methodName) => )
            {
                expect(app.router.stack.some(item => item.name == methodName)).toBeTruthy();

                pont += 1;
            });
        })
    });

    describe("\n2. Feladat [3p]", () => 
    {
        const watchController = tryRequireMultiple(
        [
            "../api/controllers/watchController",
            "../API/CONTROLLERS/watchController",
        ]);

        describe("\tFileokhoz kapcsolódó műveletek", () => 
        {
            test("Exportálható a router object", () => 
            {
                const watchRoutes = tryRequireMultiple(
                [
                    "../api/routes/watchRoutes",
                    "../API/ROUTES/watchRoutes",
                ]);

                expect(watchRoutes).toBeDefined();

                pont += 1;
            });

            test("Létezik a controller", () => 
            {
                expect(watchController).toBeDefined();

                pont += 1;
            });
            
            test("A controller exportál metódusokat", () => 
            {
                expect(Object.keys(watchController).length).toBeGreaterThan(0);

                pont += 1;
            });
        })
    });

    describe("\n3. Feladat [7p]", () => 
    {
        const watchController = tryRequireMultiple(
        [
            "../api/controllers/watchController",  
            "../API/CONTROLLERS/watchController",  
        ])

        describe("\tController tesztelése a getWatches metódusra", () => 
        {
            test("A controllerben exportálható a getWatches nevű metódus", () => 
            {
                expect(Object.keys(watchController)).toContain("getWatches");

                pont += 1;
            });

            test("A getWatches metódus a 200-as státuszkóddal tér vissza", () => 
            {
                const res =
                {
                    status: jest.fn().mockReturnThis(),
                    json: jest.fn(),
                };

                watchController.getWatches({}, res, jest.fn());

                expect(res.status).toHaveBeenCalledWith(200);

                pont += 1;
            });

            test("A getWatches metódus a statikus tömb adataival tér vissza", () => 
            {
                const res =
                {
                    status: jest.fn().mockReturnThis(),
                    json: jest.fn(),
                };

                watchController.getWatches({}, res, jest.fn());

                expect(res.json).toHaveBeenCalledWith(watches);

                pont += 1;
            });
        });

        describe("\n\tRouter tesztelése a GET metódusú /watches endpointon",  () => 
        {
            let res;

            beforeAll(async () => 
            {
                res = await request(app).get("/watches");
            });

            test("Érkezik válasz a szervertől", () => 
            {
                expect(res.headers["content-type"]).toMatch(/json/);
                
                pont += 1/2;
            });

            test("200-as státuszkóddal válaszol a szerver", () => 
            {
                expect(res.status).toBe(200);

                pont += 1/2;
            });

            test("A statikus tömb adathalmazával válaszol json formátumban", () => 
            {
                expect(res.headers["content-type"]).toMatch(/json/);

                pont += 1;

                expect(res.body).toEqual(watches);

                pont += 2;
            });
        });
    });

    describe("\n4. Feladat [5p]", () => 
    {
        const watchController = tryRequireMultiple(
        [
            "../api/controllers/watchController",  
            "../API/CONTROLLERS/watchController",  
        ])

        describe("\tController tesztelése a getWatchesByBrand metódusra", () => 
        {
            test("A controllerben exportálható a getWatchesByBrand nevű metódus", () => 
            {
                expect(Object.keys(watchController)).toContain("getWatchesByBrand");

                pont += 1;
            });

            test("A getWatchesByBrand metódus a 200-as státuszkóddal tér vissza", () => 
            {
                const res =
                {
                    status: jest.fn().mockReturnThis(),
                    json: jest.fn(),
                };

                watchController.getWatchesByBrand({watchBrand: "Rolex"}, res, jest.fn());

                expect(res.status).toHaveBeenCalledWith(200);

                pont += 1;
            });

            test.each(
            [
                {
                    id: "#1",
                    brand: "Rolex"
                },
                {
                    id: "#2",
                    brand: "Patek Philippe"
                },
                {
                    id: "#3",
                    brand: "TAG Heuer"
                },
                {
                    id: "#4",
                    brand: "Cartier"
                },

            ])
            ("A getWatchesByBrand metódus megfelelő adatokkal tér vissza $id", ({id, brand}) => 
            {
                const res =
                {
                    status: jest.fn().mockReturnThis(),
                    json: jest.fn(),
                };

                watchController.getWatchesByBrand({watchBrand: brand}, res, jest.fn());

                const filteredWatches = watches.filter(item => item.brand == brand);

                expect(res.json).toHaveBeenCalledWith(filteredWatches);

                pont += 1/4
            });
        })

        describe("\n\tRouter tesztelése a paraméteres GET metódusú /watches endpointon", () => 
        {
            let res;

            beforeAll(async () => 
            {
                res = await request(app).get("/watches/Rolex");
            });

            test("Érkezik válasz a szervertől", () => 
            {
                expect(res.headers["content-type"]).toMatch(/json/);

                pont += 1/2;
            });

            test("200-as státuszkóddal válaszol a szerver", () => 
            {
                expect(res.status).toBe(200);

                pont += 1/2;
            });
        });

        describe("\n\tMegfelelő működéshez vizsgálatok", () => 
        {
            test.each(
            [
                "Rolex",
                "Patek Philippe",
                "TAG Heuer",
                "Cartier",
            ])
            ("Megfelelő adatokkal válaszol a /watches/%s endpointon", async (brandName) => 
            {
                const res = await request(app).get(`/watches/${brandName}`);

                const filteredWatches = watches.filter(item => item.brand == brandName);

                expect(res.body).toEqual(filteredWatches);

                expect(res.body.length).toEqual(filteredWatches.length);

                pont += 1/4;
            });
        });
    });

    describe("\n5. Feladat [9p]", () => 
    {
        describe("\tController tesztelése a deleteWatch metódushoz", () => 
        {

            const watchController = tryRequireMultiple(
            [
                "../api/controllers/watchController",  
                "../API/CONTROLLERS/watchController",  
            ]);

            test("A controllerben exportálható a deleteWatch nevű metódus", () => 
            {
                expect(Object.keys(watchController)).toContain("deleteWatch");

                pont += 1;
            });

            test.each(
            [
                {
                    id: "#1",
                    watchOwnerName: "Szabó Dániel",
                    watchBrandName: "Rolex",
                },
                {
                    id: "#2",
                    watchOwnerName: "Kássa Gergő",
                    watchBrandName: "Rolex",
                },
                {
                    id: "#3",
                    watchOwnerName: "Szabó Emánuel",
                    watchBrandName: "Patek Philippe",
                },
                {
                    id: "#4",
                    watchOwnerName: "Szabó Dániel",
                    watchBrandName: "TAG Heuer",
                },
                {
                    id: "#5",
                    watchOwnerName: "Kássa Gergő",
                    watchBrandName: "TAG Heuer",
                },
                {
                    id: "#6",
                    watchOwnerName: "Farkas Norbert Levente",
                    watchBrandName: "Cartier",
                },
            ])
            ("A deleteWatch metódus megfelelő adatokkal tér vissza $id", ({id, watchOwnerName, watchBrandName}) => 
            {
                const res =
                {
                    status: jest.fn().mockReturnThis(),
                    json: jest.fn(),
                };

                const mockArray = JSON.parse(JSON.stringify(watches));

                watchController.deleteWatch({body: { watchOwnerName: watchOwnerName, watchBrandName: watchBrandName }}, res, jest.fn());

                const filteredItem = mockArray.filter(item => item.owner == watchOwnerName && item.brand == watchBrandName).pop();

                expect(res.json).toHaveBeenCalledWith(filteredItem);

                pont += 1/6;
            })
        });

        describe("\n\tRouter tesztelése a DELETE metódusú /watches endpointon", () => 
        {
            beforeEach(() => 
            {
                Object.keys(require.cache).forEach(k => delete require.cache[k]);
                
                jest.resetModules();
                
                app = require("../app");
            });

            test("200-as státuszkóddal válaszol a szerver, ha a törlés sikeres", async () => 
            {
                const res = await request(app).delete("/watches").send({ watchOwnerName: "Kássa Gergő", watchBrandName: "Rolex" });

                expect(res.status).toBe(200);

                pont += 1;
            })

            test.each(
            [
                {
                    id: "#1",
                    watchOwnerName: "Szabó Dániel",
                    watchBrandName: "Rolex",
                },
                {
                    id: "#2",
                    watchOwnerName: "Kássa Gergő",
                    watchBrandName: "Rolex",
                },
                {
                    id: "#3",
                    watchOwnerName: "Szabó Emánuel",
                    watchBrandName: "Patek Philippe",
                },
                {
                    id: "#4",
                    watchOwnerName: "Szabó Dániel",
                    watchBrandName: "TAG Heuer",
                },
                {
                    id: "#5",
                    watchOwnerName: "Kássa Gergő",
                    watchBrandName: "TAG Heuer",
                },
                {
                    id: "#6",
                    watchOwnerName: "Farkas Norbert Levente",
                    watchBrandName: "Cartier",
                },
            ])
            ("Megfelelő adatokkal válaszol a /watches endpointon $id", async ({id, watchOwnerName, watchBrandName}) => 
            {
                const mockArray = JSON.parse(JSON.stringify(watches));

                const resDelete = await request(app).delete("/watches").send({ watchOwnerName, watchBrandName });

                const filteredWatch = mockArray.filter(item => item.owner == watchOwnerName && item.brand == watchBrandName).pop();

                expect(resDelete.body).toEqual(filteredWatch);

                pont += 1/2;

                mockArray.splice(mockArray.findIndex(item => item === filteredWatch), 1);

                const resAll = await request(app).get("/watches");

                expect(resAll.body).toEqual(mockArray);

                pont += 1/2;
            });
        });
    });
})

function tryRequireMultiple(paths)
{
    for(let path of paths)
    {
        try
        {
            return require(path);
        }
        catch(error)
        {

        }
    }
}

function getGrade(pont)
{
    const percentage = Math.round(pont / total * 100);

    if(percentage <= 39)
    {
        return 1;
    }
    else if(percentage >= 40 && percentage <= 54)
    {
        return 2;
    }
    else if(percentage >= 55 && percentage <= 69)
    {
        return 3;
    }
    else if(percentage >= 70 && percentage <= 84)
    {
        return 4;
    }
    else if(percentage >= 85 && percentage <= 100)
    {
        return 5;
    }
}