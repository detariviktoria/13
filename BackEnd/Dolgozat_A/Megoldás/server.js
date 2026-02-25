const app = require("./app");

const PORT = 4567;

app.listen(PORT, () => 
{
    console.log(`http://localhost:${PORT}/watches`);
})