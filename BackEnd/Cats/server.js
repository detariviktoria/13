// Behívjuk az appot
const app = require("./app");

const PORT = 3000;

app.listen(PORT, () => 
{
    console.log(`http://localhost:${PORT}`);
})