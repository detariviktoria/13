require("dotenv").config({ quiet: true });

const app = require("./app");

const PORT = process.env.PORT || 42069;

app.listen(PORT, () => 
{
    console.log(`http://localhost:${PORT}`);
});