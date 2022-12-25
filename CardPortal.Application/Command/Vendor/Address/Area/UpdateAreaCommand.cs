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
    public record UpdateAreaCommand(AreaWriteDto Area) : IRequest<ServiceResponse>;

    public class UpdateAreaCommandHandler : IRequestHandler<UpdateAreaCommand, ServiceResponse>
    {
        private readonly IAreaRepository _AreaRepository;
        private readonly IMapper _mapper;

        public UpdateAreaCommandHandler(IAreaRepository AreaRepository, IMapper mapper)
        {
            _AreaRepository = AreaRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse> Handle(UpdateAreaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Area - From Area Write Dto - Map
                var Area = _mapper.Map<AreaModel>(request.Area);

                // Area - Update
                var result = await _AreaRepository.UpdateArea(Area);

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
