const db = require("../db");
const { adoptionService } = require("../services")(db);

exports.getAll = async (req, res, next) => {
    try { res.status(200).json(await adoptionService.getAll()); } 
    catch (error) { next(error); }
};

exports.getById = async (req, res, next) => {
    try { res.status(200).json(await adoptionService.getById(req.adoptionID)); } 
    catch (error) { next(error); }
};

exports.create = async (req, res, next) => {
    try { res.status(201).json(await adoptionService.create(req.body)); } 
    catch (error) { next(error); }
};

exports.update = async (req, res, next) => {
    try { res.status(200).json(await adoptionService.update(req.body, req.adoptionID)); } 
    catch (error) { next(error); }
};

exports.delete = async (req, res, next) => {
    try { res.status(200).json(await adoptionService.delete(req.adoptionID)); } 
    catch (error) { next(error); }
};
