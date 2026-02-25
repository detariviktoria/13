module.exports = (sequelize) =>
{
    const Students = require("./Student")(sequelize);

    return { Students };
}