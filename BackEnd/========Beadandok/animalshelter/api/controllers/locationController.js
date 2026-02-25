const db = require("../db");
const { locationService } = require("../services")(db);

exports.getAll = async (req, res, next) => {
    try { res.status(200).json(await locationService.getAll()); } 
    catch (error) { next(error); }
};

exports.getById = async (req, res, next) => {
    try { res.status(200).json(await locationService.getById(req.locationID)); } 
    catch (error) { next(error); }
};

exports.create = async (req, res, next) => {
    try { res.status(201).json(await locationService.create(req.body)); } 
    catch (error) { next(error); }
};

exports.update = async (req, res, next) => {
    try { res.status(200).json(await locationService.update(req.body, req.locationID)); } 
    catch (error) { next(error); }
};

exports.delete = async (req, res, next) => {
    try { res.status(200).json(await locationService.delete(req.locationID)); } 
    catch (error) { next(error); }
};
