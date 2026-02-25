module.exports = (sequelize) =>
{
    const Users = require("./User")(sequelize);

    const Settings = require("./Setting")(sequelize);

    const Weapons = require("./Weapon")(sequelize);


    return { Users, Settings, Weapons}
}