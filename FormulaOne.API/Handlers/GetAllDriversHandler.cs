using AutoMapper;
using FormulaOne.API.Queries;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DTOs.Responses;
using MediatR;

namespace FormulaOne.API.Handlers
{
    public class GetAllDriversHandler : IRequestHandler<GetAllDriversQuery, IEnumerable<GetDriverResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllDriversHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetDriverResponse>> Handle(GetAllDriversQuery request, CancellationToken cancellationToken)
        {
            var drivers = await _unitOfWork.Drivers.GetAllAsync();
            return _mapper.Map<IEnumerable<GetDriverResponse>>(drivers);
        }
    }
}
