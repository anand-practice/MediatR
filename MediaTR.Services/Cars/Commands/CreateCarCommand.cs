using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

public class CreateCarCommand : BaseRequest, IRequestWrapper<Car>
{

}


public class CreateCarCommandHandler : IHandleWrapper<CreateCarCommand, Car>
{
    public Task<Response<Car>> Handle(CreateCarCommand request, CancellationToken cancellationToken)
    {
        if (false)
        {
            return Task.FromResult(Response.Fail<Car>("Error creation"));
        }

        return Task.FromResult(Response.Ok<Car>(new Car { Name = "Mercedes" }, "Car created"));
    }
}
