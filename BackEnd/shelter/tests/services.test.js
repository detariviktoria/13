/*
TODO:
    Repository:
    AnimalRepository:
        - get
        - getAnimals
        - create
        - delete
    Service:
    AnimalService:
        - get + hibakezelés
        - getAnimals
        - create + hibakezelés
        - delete + hibakezelés
    Teszt:
    - Hozd létre a services.test.js file-t a megfelelő mappába.
    - Teszteld le az AnimalService getAnimals és getAnimal nevű metódusait.
    - Figyelj arra, hogy az összes esetet teszteld.
*/

const { BadRequestError, ValidationError } = require("../api/errors");

const { shelterService } = require("../api/services")({});

describe("Service tests", () => 
{
    describe("ShelterService", () => 
    {
        beforeAll(() => 
        {
            shelterService.repository.getShelters = jest.fn().mockReturnValue(true);
            shelterService.repository.createShelter = jest.fn().mockReturnValue(true);
        });

        describe("getShelters", () => 
        {
            test("should return all the shelters", async () => 
            {
                const result = await shelterService.getShelters();

                expect(result).toBeTruthy();
            });
        });

        describe("createShelter", () => 
        {
            /*
            NOTE: Tesztesetek
                - Sikeres eset
                Hibák:
                - Hiányos adat
                - Nem megfelelő adat
                SQL hibák:
                - Már létező egyed
                - Validációs hibák
            */

            test("should create a new shelter", async () => 
            {
                const shelterData =
                {
                    name: "TestShelter",
                    capacity: 6769420,
                };

                const result = await shelterService.createShelter(shelterData);

                expect(result).toBeTruthy();
            });

            test("should throw BadRequestError given that there is no data", () => 
            {
                const result = shelterService.createShelter(undefined);

                expect(result).rejects.toThrow(BadRequestError);
            });

            test("should throw BadRequestError given that the data is not correct", () => 
            {
                const shelter = 
                {
                    name: 5,
                    capacity: -500,
                };

                const result = shelterService.create(shelter);

                expect(result).rejects.toThrow(BadRequestError);
            });

            test("should throw BadRequestError given that the shelter already exists", async () => 
            {
                const shelter = 
                {
                    name: "TestShelter",
                    capacity: 100,
                };

                await shelterService.createShelter(shelter);

                const result = shelterService.createShelter(shelter);

                expect(result).rejects.toThrow(BadRequestError);
            });

            test("should throw ValidaionError when the capacity is not a floating point", () => 
            {
                const shelter =
                {
                    name: "TestShelter",
                    capacity: "onehundred",
                }

                const result = shelterService.createShelter(shelter);

                expect(result).rejects.toThrow(ValidationError);
            });

            test("should throw ValidationError when the capacity is less than one", () => 
            {
                const shelter =
                {
                    name: "TestShelter",
                    capacity: -67,
                }

                const result = shelterService.createShelter(shelter);

                expect(result).rejects.toThrow(ValidationError);
            });
        });
    });
});
