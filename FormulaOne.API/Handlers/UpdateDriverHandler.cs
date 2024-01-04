using AutoMapper;
using FormulaOne.API.Commands;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using MediatR;

namespace FormulaOne.API.Handlers
{
    public class UpdateDriverHandler : IRequestHandler<UpdateDriverCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateDriverHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateDriverCommand request, CancellationToken cancellationToken)
        {
            var driver = _mapper.Map<Driver>(request.DriverRequest);

            if (await _unitOfWork.Drivers.UpdateAsync(driver))
            {
                await _unitOfWork.CompleteAsync();
                return true;
            }

            return false;
        }
    }
}
