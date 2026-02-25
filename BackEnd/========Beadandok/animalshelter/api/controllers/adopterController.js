const db = require("../db");
const { adopterService } = require("../services")(db);

exports.getAll = async (req, res, next) => {
    try { res.status(200).json(await adopterService.getAll()); } 
    catch (error) { next(error); }
};

exports.getById = async (req, res, next) => {
    try { res.status(200).json(await adopterService.getById(req.adopterID)); } 
    catch (error) { next(error); }
};

exports.create = async (req, res, next) => {
    try { res.status(201).json(await adopterService.create(req.body)); } 
    catch (error) { next(error); }
};

exports.update = async (req, res, next) => {
    try { res.status(200).json(await adopterService.update(req.body, req.adopterID)); } 
    catch (error) { next(error); }
};

exports.delete = async (req, res, next) => {
    try { res.status(200).json(await adopterService.delete(req.adopterID)); } 
    catch (error) { next(error); }
};
