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
    public record CreateCityCommand(CityWriteDto City) : IRequest<ServiceResponse>;

    public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, ServiceResponse>
    {
        private readonly ICityRepository _CityRepository;
        private readonly IMapper _mapper;

        public CreateCityCommandHandler(ICityRepository CityRepository, IMapper mapper)
        {
            _CityRepository = CityRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // City - From City Write Dto - Map
                var City = _mapper.Map<CityModel>(request.City);

                // City - Save
                var result = await _CityRepository.CreateCity(City);

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
