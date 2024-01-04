using MediatR;

namespace FormulaOne.API.Commands
{
    public class DeleteAchievementCommand : IRequest<bool>
    {
        public Guid AchieveId;

        public DeleteAchievementCommand(Guid achieveId)
        {
            AchieveId = achieveId;
        }
    }
}
