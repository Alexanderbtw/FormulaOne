using FormulaOne.Entities.DTOs.Requests;
using MediatR;

namespace FormulaOne.API.Commands
{
    public class UpdateDriverCommand : IRequest<bool>
    {
        public UpdateDriverRequest DriverRequest { get; }
        public UpdateDriverCommand(UpdateDriverRequest driverRequest)
        {
            DriverRequest = driverRequest;
        }
    }
}
