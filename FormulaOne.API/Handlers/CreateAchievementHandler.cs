using AutoMapper;
using FormulaOne.API.Commands;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.DTOs.Responses;
using MediatR;

namespace FormulaOne.API.Handlers
{
    public class CreateAchievementHandler : IRequestHandler<CreateAchievementCommand, DriverAchievementResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateAchievementHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DriverAchievementResponse> Handle(CreateAchievementCommand request, CancellationToken cancellationToken)
        {
            var achieve = _mapper.Map<Achievement>(request.AchievementRequest);

            await _unitOfWork.Achievements.AddAsync(achieve);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<DriverAchievementResponse>(achieve);
        }
    }
}
