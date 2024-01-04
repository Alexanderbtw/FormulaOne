using AutoMapper;
using FormulaOne.API.Queries;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.DTOs.Responses;
using MediatR;

namespace FormulaOne.API.Handlers
{
    public class GetDriverAchievementsHandler : IRequestHandler<GetDriverAchievementsQuery, IEnumerable<DriverAchievementResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetDriverAchievementsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DriverAchievementResponse>> Handle(GetDriverAchievementsQuery request, CancellationToken cancellationToken)
        {
            var driverAchievements = await _unitOfWork.Achievements.GetDriverAchievementsAsync(request.DriverId);

            if (driverAchievements == null || !driverAchievements.Any())
            {
                return null!;
            }

            return _mapper.Map<IEnumerable<DriverAchievementResponse>>(driverAchievements);
        }
    }
}
