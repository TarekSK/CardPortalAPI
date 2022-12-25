using AutoMapper;
using CardPortal.Application.Helper;
using CardPortal.Domain.AggregateModel.Vendor.Address.Area;
using CardPortal.Domain.Dto.Vendor.Address.Area;
using CardPortal.Domain.Helper.ServiceResponse;
using MediatR;
using System.Net;
using AreaModel = CardPortal.Domain.AggregateModel.Vendor.Address.Area.Area;

namespace CardPortal.Application.Command.Vendor.Address.Area
{
    public record CreateAreaCommand(AreaWriteDto Area) : IRequest<ServiceResponse>;

    public class CreateAreaCommandHandler : IRequestHandler<CreateAreaCommand, ServiceResponse>
    {
        private readonly IAreaRepository _AreaRepository;
        private readonly IMapper _mapper;

        public CreateAreaCommandHandler(IAreaRepository AreaRepository, IMapper mapper)
        {
            _AreaRepository = AreaRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse> Handle(CreateAreaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Area - From Area Write Dto - Map
                var Area = _mapper.Map<AreaModel>(request.Area);

                // Area - Save
                var result = await _AreaRepository.CreateArea(Area);

                return result;
            }
            catch (Exception ex)
            {
                return new ServiceResponse(
                    HttpStatusCode.InternalServerError, new List<string>() { GenericError.GenericErrorMessage, ex.Message });
            }
        }
    }
}
