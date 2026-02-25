class ShelterService
{
    /*
    TODO:
        ShelterServicebe:
        - Készíts egy createShelter nevű metódust
            - ezt megfelelően hibakezeld
            - hívd meg az osztály repositoryjának a createShelter metódusát.
        
        Tesztek:
        - Hozd létre a services.test.js fájlt a megfelelő helyre
        - Teszteld a ShelterService osztályodat.
    */

    constructor(repository)
    {
        this.repository = repository;
    }

    async getShelters()
    {
        return await this.repository.getShelters();
    }
}

module.exports = ShelterService;