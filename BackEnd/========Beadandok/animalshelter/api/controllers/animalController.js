const db = require("../db");
const { animalService } = require("../services")(db);

exports.getAnimals = async (req, res, next) => {
    try {
        const animals = await animalService.getAnimals();
        res.status(200).json(animals);
    } catch (error) {
        next(error);
    }
};

exports.getAnimal = async (req, res, next) => {
    try {
        const animal = await animalService.getAnimal(req.animalID);
        res.status(200).json(animal);
    } catch (error) {
        next(error);
    }
};

exports.createAnimal = async (req, res, next) => {
    try {
        const newAnimal = await animalService.createAnimal(req.body);
        res.status(201).json(newAnimal);
    } catch (error) {
        next(error);
    }
};

exports.updateAnimal = async (req, res, next) => {
    try {
        const updated = await animalService.updateAnimal(req.body, req.animalID);
        res.status(200).json(updated);
    } catch (error) {
        next(error);
    }
};

exports.deleteAnimal = async (req, res, next) => {
    try {
        const deleted = await animalService.deleteAnimal(req.animalID);
        res.status(200).json({ deleted });
    } catch (error) {
        next(error);
    }
};
