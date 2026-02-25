const db = require("../db");
const { appointmentService } = require("../services")(db);

exports.getAll = async (req, res, next) => {
    try { res.status(200).json(await appointmentService.getAll()); } 
    catch (error) { next(error); }
};

exports.getById = async (req, res, next) => {
    try { res.status(200).json(await appointmentService.getById(req.appointmentID)); } 
    catch (error) { next(error); }
};

exports.create = async (req, res, next) => {
    try { res.status(201).json(await appointmentService.create(req.body)); } 
    catch (error) { next(error); }
};

exports.update = async (req, res, next) => {
    try { res.status(200).json(await appointmentService.update(req.body, req.appointmentID)); } 
    catch (error) { next(error); }
};

exports.delete = async (req, res, next) => {
    try { res.status(200).json(await appointmentService.delete(req.appointmentID)); } 
    catch (error) { next(error); }
};
