const { AppError, NotFoundError } = require("../errors");

function notFound(req, res, next)
{
    next(new NotFoundError());
}

function showError(error, req, res, next) {
    res.status(error).json();
}

module.exports = { notFound };