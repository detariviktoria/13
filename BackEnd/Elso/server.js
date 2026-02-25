const app = require("./app");
const PORT = 3000;

// app.listen(PORT); // EZ IS ELÉG

app.listen(PORT, () => 
{
    console.log(`http://localhost:${PORT}`);
});