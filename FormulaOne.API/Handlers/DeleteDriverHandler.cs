using AutoMapper;
using FormulaOne.API.Commands;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using MediatR;

namespace FormulaOne.API.Handlers
{
    public class DeleteDriverHandler : IRequestHandler<DeleteDriverCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteDriverHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteDriverCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Drivers.DeleteAsync(request.DriverId);

            if (!result)
            {
                return false;
            }

            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}
