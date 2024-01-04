using FormulaOne.Entities.DTOs.Responses;
using MediatR;

namespace FormulaOne.API.Queries
{
    public class GetAllDriversQuery : IRequest<IEnumerable<GetDriverResponse>>
    {

    }
}
