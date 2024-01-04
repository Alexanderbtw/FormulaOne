using FormulaOne.Entities.DTOs.Requests;
using FormulaOne.Entities.DTOs.Responses;
using MediatR;

namespace FormulaOne.API.Commands
{
    public class CreateDriverCommand : IRequest<GetDriverResponse>
    {
        public CreateDriverRequest DriverRequest { get; }

        public CreateDriverCommand(CreateDriverRequest driverRequest)
        {
            DriverRequest = driverRequest;
        }
    }
}
