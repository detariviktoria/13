const {Sequelize} = require("sequelize");

const sequelize = new Sequelize
(
    process.env.DB_NAME,
    process.env.DB_USER,
    process.env.DB_PASSWORD,
    {
        dialect: process.env.DB_DIALECT,
        host: process.env.DB_HOST,
        logging:false,
    },
);

const models = require("../models")(sequelize);

const db={
    sequelize,
    Sequelize,
    ...models,
};

(async () =>{

    try{
        await sequelize.authenticate();
    }
    catch(error){
        next(error);    
    }

    
})();

(async () =>{

    try{
        db.sequelize.sync({alter:true});
    }
    catch(error){
        next(error);    
    }

    
})();

module.exports = db;