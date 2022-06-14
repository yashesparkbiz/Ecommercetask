using MediatR;

namespace Ecommercetask.Core.Helper.CarsHelper.Queries.GetAllCars
{
    public class GetAllCarsQuery : IRequest<IEnumerable<Car>> {}
    public class GetAllCarsQueryHandler : IRequestHandler<GetAllCarsQuery, IEnumerable<Car>>
    {
        //ctor for dependendencies
        public GetAllCarsQueryHandler()
        {

        }

        public async Task<IEnumerable<Car>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
        {
            // some buisness logic

            return new[] {
                new Car { Name = "Ford" },
                new Car { Name = "Toyta" },
            };
        }
    }

    public class Car
    {
        public string Name { get; set; }
    }
}
