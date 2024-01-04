using AutoMapper;
using FormulaOne.API.Commands;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using MediatR;

namespace FormulaOne.API.Handlers
{
    public class UpdateAchievementHandler : IRequestHandler<UpdateAchievementCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateAchievementHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateAchievementCommand request, CancellationToken cancellationToken)
        {
            var achievement = _mapper.Map<Achievement>(request.AchievementRequest);

            if (await _unitOfWork.Achievements.UpdateAsync(achievement))
            {
                await _unitOfWork.CompleteAsync();
                return true;
            }
            
            return false;
        }
    }
}
