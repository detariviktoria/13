console.log("Hello Világ!");

const express = require('express')  //require 
const app = express()
const port = 3000

//req-kérés, res-válasz
app.get('/', (req, res) => {
  res.send('Hello World!')
})

app.listen(port, () => {
  console.log(`Example app listening on port ${port}`)
})


// C - Create - POST
// R - Read - GET
// U - Update - PATCH
// D - Delete - DELETE