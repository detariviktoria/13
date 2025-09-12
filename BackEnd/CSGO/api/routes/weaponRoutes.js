const express = require("express");

const app = express.Router();

const weaponController = require("../controllers/weaponcontrollers");

exports.updateWeapon = (req, res, next) =>
{
    const weapon = getWeapons.find(item => item.name = weaponName);
    if(weapon)
    {
        
    }
}