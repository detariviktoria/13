const { AppError, NotFoundError } = require("../errors");

function notFound(req, res, next)
{
    next(new NotFoundError());
}

function showError(error, req, res, next)
{
    if(!(error instanceof AppError))
    {
        error = new AppError("Unexpected Error happened", 
        {
            isOperational: false,
            details: error.message,
        });
    }

    res.status(error.statusCode).json(
    {
        message: error.message,
        ...error,
    });
}

module.exports = { notFound, showError };