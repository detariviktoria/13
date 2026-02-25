const express = require('express');
const router = express.Router();


router.post('/login', (req, res) => {
  res.status(200).json({ message: 'Bejelentkezés sikeres!' });
});


router.get('/status', (req, res) => {
  res.status(200).json({ loggedIn: true });
});


router.delete('/logout', (req, res) => {
  res.status(200).json({ message: 'Sikeres kijelentkezés!' });
});

module.exports = router;
