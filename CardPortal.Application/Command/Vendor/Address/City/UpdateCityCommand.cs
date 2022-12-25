using AutoMapper;
using CardPortal.Application.Helper;
using CardPortal.Domain.AggregateModel.Vendor.Address.City;
using CardPortal.Domain.Dto.Vendor.Address.City;
using CardPortal.Domain.Helper.ServiceResponse;
using MediatR;
using System.Net;
using CityModel = CardPortal.Domain.AggregateModel.Vendor.Address.City.City;

namespace CardPortal.Application.Command.Vendor.Address.City
{
    public record UpdateCityCommand(CityWriteDto City) : IRequest<ServiceResponse>;

    public class UpdateCityCommandHandler : IRequestHandler<UpdateCityCommand, ServiceResponse>
    {
        private readonly ICityRepository _CityRepository;
        private readonly IMapper _mapper;

        public UpdateCityCommandHandler(ICityRepository CityRepository, IMapper mapper)
        {
            _CityRepository = CityRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // City - From City Write Dto - Map
                var City = _mapper.Map<CityModel>(request.City);

                // City - Update
                var result = await _CityRepository.UpdateCity(City);

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
