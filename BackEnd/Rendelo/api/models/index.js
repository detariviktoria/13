module.exports = (sequelize) => 
{
    const Rendelok = require("./Rendelo")(sequelize);
    const Orvosok = require("./Orvos")(sequelize);
    const Paciensek = require("./Paciens")(sequelize);

    //#region Orvos <> Rendelo

    Orvosok.hasMany(Rendelok, {
            foreignKey : "orvos_id",
            as : "rendelok",
    });

    Rendelok.belongsTo(Orvosok, {
        foreignKey: "orvos_id",
        as : "orvos",
    });

    //#region  Pacines <> Orvos

    Orvosok.hasMany(Paciensek, {
        foreignKey: "orvos_id", 
    });

    Rendelok.belongsTo(Orvosok,{
        foreignKey: "orvos_id"
    });


    //#endregion 

    return {Rendelok, Orvosok, Paciensek};
}