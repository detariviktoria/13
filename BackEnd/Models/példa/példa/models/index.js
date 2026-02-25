module.exports = (sequelize) =>
{
    const Cache = require("../models/cache")(sequelize);

    const Log = require("../models/log")(sequelize);

    const User = require("../models/user")(sequelize);

    Cache.hasMany(Log, 
    {
        foreignKey: "láda_id"
    });

    Log.belongsTo(Cache, 
    {
        foreignKey: "láda_id",
        as: "cache",
    });

    User.hasMany(Log, 
    {
        foreignKey: "felhasználó_id",
    });

    Log.belongsTo(User, 
    {
        foreignKey: "felhasználó_id",
        as: "user",
    });

    return { Cache, Log, User };
}