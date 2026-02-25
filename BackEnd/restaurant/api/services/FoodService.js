class FoodService
{
    constructor(repository)
    {
        this.repository = repository;
    }

    async getFoods()
    {
        return await this.repository.getFoods();
    }

    async addFood(food)
    {
        if(!food) throw new Error("Missing payload");

        return await this.repository.addFood(food);
    }
}