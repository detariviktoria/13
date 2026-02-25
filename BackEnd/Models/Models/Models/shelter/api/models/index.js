module.exports = (sequelize) =>
{
    const Animals = require("./Animal")(sequelize);

    return { Animals };
}