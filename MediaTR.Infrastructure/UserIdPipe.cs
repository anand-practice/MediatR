using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MediatR;
using System.Security.Claims;

namespace MediaTR.Infrastructure
{
    public class UserIdPipe<TIn, TOut> : IPipelineBehavior<TIn, TOut>
    {
        private HttpContext httpContext;

        public UserIdPipe(IHttpContextAccessor contextAccessor)
        {
            httpContext = contextAccessor.HttpContext;
        }
        public async Task<TOut> Handle(TIn request, CancellationToken cancellationToken, RequestHandlerDelegate<TOut> next)
        {
            //var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (request is BaseRequest baseRequest)
            {
                baseRequest.UserId = "JUNK";
            }
            var result = await next();
            var type = result.GetType();

            if (result is Response<Car> carResponse)
            {
                carResponse.Data.Name += " intervene";
            }

            return result;
        }
    }
}
