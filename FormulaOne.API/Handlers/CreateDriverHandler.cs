using AutoMapper;
using FormulaOne.API.Commands;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.DTOs.Responses;
using FormulaOne.Services.Interfaces;
using MediatR;

namespace FormulaOne.API.Handlers
{
    public class CreateDriverHandler : IRequestHandler<CreateDriverCommand, GetDriverResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IDriverNotificationPublisherService _notificationService;

        public CreateDriverHandler(IUnitOfWork unitOfWork, IMapper mapper, IDriverNotificationPublisherService notificationService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _notificationService = notificationService;
        }

        public async Task<GetDriverResponse> Handle(CreateDriverCommand request, CancellationToken cancellationToken)
        {
            var driver = _mapper.Map<Driver>(request.DriverRequest);

            await _unitOfWork.Drivers.AddAsync(driver);
            await _unitOfWork.CompleteAsync();

            var response = _mapper.Map<GetDriverResponse>(driver);
            
            await _notificationService.SentNotification(response.DriverId, response.FullName);
            return response;
        }
    }
}
