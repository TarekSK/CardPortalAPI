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
    public record DeleteCityCommand(CityWriteDto City) : IRequest<ServiceResponse>;

    public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommand, ServiceResponse>
    {
        private readonly ICityRepository _CityRepository;
        private readonly IMapper _mapper;

        public DeleteCityCommandHandler(ICityRepository CityRepository, IMapper mapper)
        {
            _CityRepository = CityRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // City - From City Write Dto - Map
                var City = _mapper.Map<CityModel>(request.City);

                // City - Delete
                var result = await _CityRepository.DeleteCity(City);

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
