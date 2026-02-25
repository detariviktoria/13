require("dotenv").config({ quiet: true });

const app = require("./app");

const PORT = process.env.PORT || 8000;

const db = require("./api/db");

(async () => 
{
    db.sequelize.sync({ force: true });
})();

app.listen(PORT, () => 
{
    console.log(`http://localhost:${PORT}`);
});