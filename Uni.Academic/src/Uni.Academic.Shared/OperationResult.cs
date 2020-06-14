using System;
using System.Threading.Tasks;

namespace Uni.Academic.Shared
{
    public struct OperationResult<T>
    {
        public T Result { get; set; }
        public Exception Exception { get; }
        public bool IsSuccess { get; }

        public OperationResult(T result)
        {
            IsSuccess = true;
            Exception = null;
            Result = result;
        }

        public OperationResult(Exception exception)
        {
            Exception = exception;
            IsSuccess = false;
            Result = default;
        }

        public static implicit operator OperationResult<T>(T result)
            => new OperationResult<T>(result);

        public static implicit operator OperationResult<T>(Exception exception)
            => new OperationResult<T>(exception);

        public OperationResult<TEnd> ChangeInAnotherResult<TEnd>(Func<T, TEnd> converter)
            => IsSuccess
                ? new OperationResult<TEnd>(converter(Result))
                : new OperationResult<TEnd>(Exception);

        public OperationResult ChangeInNoResult()
            => IsSuccess
                ? new OperationResult(true)
                : new OperationResult(Exception);

        public void Deconstruct(out bool success, out T result)
            => (success, result) = (IsSuccess, Result);

        public void Deconstruct(out bool success, out T result, out Exception exception)
            => (success, result, exception) = (IsSuccess, Result, Exception);

        public static implicit operator bool(OperationResult<T> operationResult)
            => operationResult.IsSuccess;

        public static implicit operator Task<OperationResult<T>>(OperationResult<T> operationResult)
            => operationResult.AsTask;

        public Task<OperationResult<T>> AsTask => Task.FromResult(this);
    }

    public struct OperationResult
    {
        public Exception Exception { get; }
        public bool IsSuccess { get; }

        public OperationResult(bool success)
        {
            IsSuccess = success;
            Exception = null;
        }

        public OperationResult(Exception exception)
        {
            Exception = exception;
            IsSuccess = false;
        }

        public bool ErrorIs<TException>()
            where TException : Exception
            => Exception is TException;

        public static OperationResult Success()
            => new OperationResult(true);

        public static OperationResult Error(Exception exception)
            => new OperationResult(exception);

        public static OperationResult<T> Success<T>(T result)
            => new OperationResult<T>(result);

        public static OperationResult<T> Error<T>(Exception exception)
            => new OperationResult<T>(exception);

        public static implicit operator OperationResult(Exception exception)
            => new OperationResult(exception);

        public static implicit operator bool(OperationResult operationResult)
            => operationResult.IsSuccess;

        public static implicit operator Task<OperationResult>(OperationResult operationResult)
            => operationResult.AsTask;

        public void Deconstruct(out bool success, out Exception exception)
            => (success, exception) = (IsSuccess, Exception);

        public Task<OperationResult> AsTask => Task.FromResult(this);
    }
}
