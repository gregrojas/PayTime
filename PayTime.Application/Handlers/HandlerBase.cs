﻿using CSharpFunctionalExtensions;
using PayTime.Core.Errors;

namespace PayTime.Application.Handlers
{
    public abstract class HandlerBase<TResultValue> where TResultValue : class
    {
        protected static Result<TResultValue, Error> ToResult(TResultValue value)
        {
            value = value ?? throw new ArgumentNullException(nameof(value));
            return Result.Success<TResultValue, Error>(value);
        }

        protected static Result<TResultValue, Error> ToResult(Error error)
        {
            error = error ?? throw new ArgumentNullException(nameof(error));
            return Result.Failure<TResultValue, Error>(error);
        }
    }
}
