const app = require("./app"); // importálom az appot

const PORT = 3000;

app.listten(PORT, () =>
{
    console.log(`http://local`)
})