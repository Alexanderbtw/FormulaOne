using FormulaOne.Entities.DTOs.Requests;
using FormulaOne.Entities.DTOs.Responses;
using MediatR;

namespace FormulaOne.API.Commands
{
    public class CreateAchievementCommand : IRequest<DriverAchievementResponse>
    {
        public CreateDriverAchievementRequest AchievementRequest { get; }

        public CreateAchievementCommand(CreateDriverAchievementRequest request)
        {
            AchievementRequest = request;
        }
    }
}
