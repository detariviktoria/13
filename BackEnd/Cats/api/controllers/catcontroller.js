// ezt a függvényt kivülről is elértjük
exports.getCats = (req, res, next) =>
{
    res.status(200).json(users);
}

exports.creatCat = (req, res, next) =>
{
    const { userName, password } = req.body;

    if(users.some(item => item.name == userName))
    {
        const error = new Error("Ez a nevű felhasználó, már létezik!");

        error.status = 400;

        throw error;
    }
    users.push(
    {
        name: userName,
        password: password,
    });

    res.status(201).send(`${userName} nevű felhasználó regisztrálva lett!`);
}