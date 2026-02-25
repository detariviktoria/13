const db = require("../db");
const { vetService } = require("../services")(db);

exports.getAll = async (req, res, next) => {
    try { res.status(200).json(await vetService.getAll()); } 
    catch (error) { next(error); }
};

exports.getById = async (req, res, next) => {
    try { res.status(200).json(await vetService.getById(req.vetID)); } 
    catch (error) { next(error); }
};

exports.create = async (req, res, next) => {
    try { res.status(201).json(await vetService.create(req.body)); } 
    catch (error) { next(error); }
};

exports.update = async (req, res, next) => {
    try { res.status(200).json(await vetService.update(req.body, req.vetID)); } 
    catch (error) { next(error); }
};

exports.delete = async (req, res, next) => {
    try { res.status(200).json(await vetService.delete(req.vetID)); } 
    catch (error) { next(error); }
};
