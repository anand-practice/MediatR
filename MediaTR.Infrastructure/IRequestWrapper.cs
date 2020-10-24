using MediatR;

public interface IRequestWrapper<T> : IRequest<Response<T>> { }

public interface IHandleWrapper<TIn, TOut> : IRequestHandler<TIn, Response<TOut>> where TIn : IRequestWrapper<TOut> { }