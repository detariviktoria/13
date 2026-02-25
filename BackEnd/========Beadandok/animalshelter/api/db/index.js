const { Sequelize } = require("sequelize");
const { DbError } = require("../errors");

require("dotenv").config();

const sequelize = new Sequelize(
  process.env.DB_NAME,
  process.env.DB_USER,
  process.env.DB_PASSWORD,
  {
    host: process.env.DB_HOST,
    dialect: process.env.DB_DIALECT,
    logging: false,
  }
);

// Ellenőrizzük a kapcsolatot
(async () => {
  try 
  {
    await sequelize.authenticate();

    console.log("Database connected");
  } catch (error) 
  {
    throw new DbError("Failed to connect to database",
         {
      details: error.message,
    });
  }
})();

// Betöltjük a modelleket
const models = require("../models")(sequelize);

const db = {
  sequelize,
  Sequelize,
  ...models,
};

// Szinkronizáljuk a táblákat
(async () => {
  try {
    console.log("Database synchronization started");
    await db.sequelize.sync({ alter: true });
    console.log("Database synchronization OK");
  } catch (error) {
    throw new DbError("Failed to synchronize database", {
      details: error.message,
    });
  }
})();

module.exports = db;
