using FormulaOne.Entities.DTOs.Requests;
using MediatR;

namespace FormulaOne.API.Commands
{
    public class UpdateAchievementCommand : IRequest<bool>
    {
        public UpdateDriverAchievementRequest AchievementRequest { get; }

        public UpdateAchievementCommand(UpdateDriverAchievementRequest request)
        {
            AchievementRequest = request;
        }
    }
}
