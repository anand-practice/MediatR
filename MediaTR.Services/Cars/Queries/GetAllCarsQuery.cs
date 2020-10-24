using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

public class GetAllCarsQuery : BaseRequest, IRequest<IEnumerable<Car>>
{

}


public class GetAllCarsQueryHandler : IRequestHandler<GetAllCarsQuery, IEnumerable<Car>>
{
    public async Task<IEnumerable<Car>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(new[] {
        new Car{ Name = $"Ford {request.UserId}" },
        new Car{ Name = "BMW" },
        });
    }
}

