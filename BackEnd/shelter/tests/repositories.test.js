jest.mock("../api/db");

const db = require("../api/db");
const { DbError } = require("../api/errors");

const ShelterRepository = require("../api/repositories/ShelterRepository");

const shelterRepository = new ShelterRepository(db);

describe("Repository tests", () => 
{
    describe("shelterRepository", () => 
    {
        const shelters =
        [
            { name: "A", capacity: 100, animals: [] },
            { name: "B", capacity: 20,  animals: []  },
            { name: "C", capacity: 50,  animals: []  },
            { name: "D", capacity: 67,  animals: []  },
        ];

        /*
        NOTE:
            1. mindenek előtt futtatom
            2. tesztenként futtatok valamit
            3. minden teszt UTÁN futtatom
            4. csak a végén egyszer futtatom    
        */

        let shelterResults;

        beforeAll(async () => 
        {
            await db.sequelize.sync();

            await db.Shelters.bulkCreate(shelters);

            shelterResults = await shelterRepository.getShelters();
        });

        describe("getShelters method tests", () => 
        {
            test("getShelters returns correct values from db", async () => 
            {
                expect(shelterResults).toMatchObject(shelters);
            });

            test("the first shelter name must be A", () => 
            {
                expect(shelterResults[0].name).toEqual("A");
            });

            test("should throw DbError given the database is not setup correctly", async () => 
            {
                const shelterRepository = new ShelterRepository({});

                /* try
                {
                    await shelterRepository.getShelters();
                }
                catch(error)
                {
                    expect(error).toBeInstanceOf(DbError);
                } */

                const promise = shelterRepository.getShelters();

                expect(promise).rejects.toThrow();

                expect(promise).rejects.toThrow("Failed fetching shelters");

                expect(promise).rejects.toThrow(DbError);
            })
        });

        describe("createShelter method tests", () => 
        {
            test("should create a shelter in the database", async () => 
            {
                const shelter = { name: "E", capacity: 123, animals: [] };

                await shelterRepository.createShelter(shelter);

                const shelters = await shelterRepository.getShelters();

                const foundShelter = shelters.find(item => item.name == "E");

                expect(foundShelter).toBeDefined();
            });
        });
    });
})