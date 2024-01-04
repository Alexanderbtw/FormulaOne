using FormulaOne.Entities.DTOs.Responses;
using MediatR;

namespace FormulaOne.API.Queries
{
    public class GetDriverAchievementsQuery : IRequest<IEnumerable<DriverAchievementResponse>>
    {
        public Guid DriverId { get; }

        public GetDriverAchievementsQuery(Guid driverId)
        {
            DriverId = driverId;
        }
    }
}
