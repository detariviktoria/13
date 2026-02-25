jest.mock("../api/db");

const request = require("supertest");

const app = require("../app");

const db = require("../api/db");

/*
TODO:
    Írd meg a post route-ot a /api/shelters endpointra.
    A bodyban használd a következő kulcsokat:
    {
        name,
        capacity,
    }

    Controllerben is írd meg a createShelter metódusát.
    Használd a Service layerben megírt metódust.

    End goal: Legyen pass a POST test case.
*/

describe("API Tests", () => 
{
    beforeAll(async () => 
    {
        await db.sequelize.sync();
    });

    describe("/api/shelters", () => 
    {
        const shelters = 
        [
            { name: "A", capacity: 56 },  
            { name: "B", capacity: 67 },  
            { name: "C", capacity: 78 },  
        ];

        beforeEach(async () => 
        {
            await db.Shelters.bulkCreate(shelters);
        });

        afterEach(async () => 
        {
            await db.Shelters.destroy({ where: {} });
        });

        describe("GET", () => 
        {
            test("should return all the shelters", async () => 
            {
                const res = await request(app).get("/api/shelters")
                .set("Accept", "application/json");

                expect(res.status).toBe(200);

                expect(res.type).toMatch(/json/);

                expect(res.body).toMatchObject(shelters);
            });
        });

        describe("POST", () => 
        {
            test("should create a shelter", async () => 
            {
                // AAA
                
                //#region Arrange

                const shelter = { name: "D", capacity: 89 };
                
                //#endregion

                //#region Act

                const res = await request(app).post("/api/shelters").send(shelter);

                //#endregion

                // NOTE: TDD - Test Driven Development

                //#region Assert

                expect(res.status).toBe(201);
                expect(res.type).toMatch(/json/);
                expect(res.body).toMatchObject(shelter);

                const foundShelter = await db.Shelters.findOne(
                {
                    where:
                    {
                        name: "D",
                    }
                });

                expect(foundShelter).toBeDefined();
                expect(foundShelter.name).toEqual("D");
                expect(foundShelter.capacity).toBe(89);

                //#endregion

            });
        });

        describe("DELETE", () => 
        {
            test("should delete shelter", async () => 
            {
                const res = await request(app).delete("/api/shelters/B");

                const foundShelter = await db.Shelters.findOne(
                {
                    where:
                    {
                        name: "B",
                    }
                });

                expect(res.status).toBe(200);
                expect(res.type).toMatch(/json/);


                expect(foundShelter).not.toBeDefined();
                expect(db.Shelters.length).toBe(2);
            });
        });
    });
});