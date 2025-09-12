const weapons = [
    {
        name:"AK-47",
        price: 700,
    },
    {
        name:"Deagle",
        price: 700,
    },
    {
        name:"AWP",
        price: 4500,
    },
]

// benne lesz!!
exports.getWeapons = (req, res, next) =>
{
    res.status(200).json(weapons);
}

// hogy kell megtalálni (ez is lehet lelsz vagy delete)
exports.updateWeapon = (req, res, next) =>
{

    const {weaponName, weaponPrice} = req.body;

    if(!weaponName || !weaponPrice)
    {
        return res.status(404).send("Hiányzó paraméter");
    }
    const weapon = weapons.find(item => item.name == VALUE);

    if(weapon)
    {
        weapon.price = Number(weaponPrice);
    }

    res.status(200).json(weapons);
}
