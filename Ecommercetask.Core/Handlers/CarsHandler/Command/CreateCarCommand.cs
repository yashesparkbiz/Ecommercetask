using Ecommercetask.Core.Helper.CarsHelper.Queries.GetAllCars;
using MediatR;

namespace Ecommercetask.Core.Handlers.CarsHandler.Command
{
    public class CreateCarCommand : IRequest<string> {

        public CreateCarCommand(Car @in)
        {
            In = @in;
        }

        public Car In { get; }
    }

    //public class CreateCarCommandhandler : IRequestHandler<CreateCarCommand, string>
    //{
    //    public Task<string> Handle(CreateCarCommand request, CancellationToken cancellationToken)
    //    {
            
    //    }
    //}
}