const db = require("../db");
const { speciesService } = require("../services")(db);

exports.getAll = async (req, res, next) => {
    try { res.status(200).json(await speciesService.getAll()); } 
    catch (error) { next(error); }
};

exports.getById = async (req, res, next) => {
    try { res.status(200).json(await speciesService.getById(req.speciesID)); } 
    catch (error) { next(error); }
};

exports.create = async (req, res, next) => {
    try { res.status(201).json(await speciesService.create(req.body)); } 
    catch (error) { next(error); }
};

exports.update = async (req, res, next) => {
    try { res.status(200).json(await speciesService.update(req.body, req.speciesID)); } 
    catch (error) { next(error); }
};

exports.delete = async (req, res, next) => {
    try { res.status(200).json(await speciesService.delete(req.speciesID)); } 
    catch (error) { next(error); }
};
