using AutoMapper;
using FormulaOne.API.Commands;
using FormulaOne.DataService.Repositories.Interfaces;
using MediatR;

namespace FormulaOne.API.Handlers
{
    public class DeleteAchievementHandler : IRequestHandler<DeleteAchievementCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteAchievementHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteAchievementCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Achievements.DeleteAsync(request.AchieveId);

            if (!result)
            {
                return false;
            }

            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}
