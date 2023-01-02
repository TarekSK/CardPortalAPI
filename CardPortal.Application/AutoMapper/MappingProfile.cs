using AutoMapper;
using CardPortal.Domain.AggregateModel.Account;
using CardPortal.Domain.AggregateModel.Card;
using CardPortal.Domain.AggregateModel.User;
using CardPortal.Domain.AggregateModel.User.Profile;
using CardPortal.Domain.AggregateModel.Vendor;
using CardPortal.Domain.AggregateModel.Vendor.Address.Address;
using CardPortal.Domain.AggregateModel.Vendor.Address.Area;
using CardPortal.Domain.AggregateModel.Vendor.Address.City;
using CardPortal.Domain.AggregateModel.Vendor.Contact.Contact;
using CardPortal.Domain.AggregateModel.Vendor.Contact.ContactType;
using CardPortal.Domain.Dto.Account;
using CardPortal.Domain.Dto.Card;
using CardPortal.Domain.Dto.Transaction;
using CardPortal.Domain.Dto.User;
using CardPortal.Domain.Dto.User.Login;
using CardPortal.Domain.Dto.User.Profile;
using CardPortal.Domain.Dto.Vendor;
using CardPortal.Domain.Dto.Vendor.Address.Address;
using CardPortal.Domain.Dto.Vendor.Address.Area;
using CardPortal.Domain.Dto.Vendor.Address.City;
using CardPortal.Domain.Dto.Vendor.Contact.Contact;
using CardPortal.Domain.Dto.Vendor.Contact.ContactType;
using System.Transactions;

namespace CardPortal.Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Account

            // Account Map
            CreateMap<Account, AccountReadDto>();
            CreateMap<AccountReadDto, Account>();
            CreateMap<Account, AccountWriteDto>();
            CreateMap<AccountWriteDto, Account>();

            #endregion Account

            #region Card

            // Card Map
            CreateMap<Card, CardReadDto>();
            CreateMap<CardReadDto, Card>();
            CreateMap<Card, CardWriteDto>();
            CreateMap<CardWriteDto, Card>();

            #endregion Card

            #region Transaction

            // Transaction Map
            CreateMap<Transaction, TransactionReadDto>();
            CreateMap<TransactionReadDto, Transaction>();
            CreateMap<Transaction, TransactionWriteDto>();
            CreateMap<TransactionWriteDto, Transaction>();

            #endregion Transaction

            #region User

            #region Login

            // Login Map
            CreateMap<Login, LoginDto>();
            CreateMap<LoginDto, Login>();

            #endregion Login

            #region Profile

            // Change Name Map
            CreateMap<ChangeName, ChangeNameDto>();
            CreateMap<ChangeNameDto, ChangeName>();

            // Change Password Map
            CreateMap<ChangePassword, ChangePasswordDto>();
            CreateMap<ChangePasswordDto, ChangePassword>();

            #endregion Profile

            // User Map
            CreateMap<User, UserReadDto>();
            CreateMap<UserReadDto, User>();
            CreateMap<User, UserWriteDto>();
            CreateMap<UserWriteDto, User>();

            #endregion User

            #region Vendor

            // Vendor Map
            CreateMap<Vendor, VendorReadDto>();
            CreateMap<VendorReadDto, Vendor>();
            CreateMap<Vendor, VendorWriteDto>();
            CreateMap<VendorWriteDto, Vendor>();

            #region Address

            // Address Map
            CreateMap<Address, AddressReadDto>();
            CreateMap<AddressReadDto, Address>();
            CreateMap<Address, AddressWriteDto>();
            CreateMap<AddressWriteDto, Address>();

            #endregion Address

            #region Area

            // Area Map
            CreateMap<Area, AreaReadDto>();
            CreateMap<AreaReadDto, Area>();
            CreateMap<Area, AreaWriteDto>();
            CreateMap<AreaWriteDto, Area>();

            #endregion Area

            #region City

            // City Map
            CreateMap<City, CityReadDto>();
            CreateMap<CityReadDto, City>();
            CreateMap<City, CityWriteDto>();
            CreateMap<CityWriteDto, City>();

            #endregion City

            #region Contact

            // Contact Map
            CreateMap<Contact, ContactReadDto>();
            CreateMap<ContactReadDto, Contact>();
            CreateMap<Contact, ContactWriteDto>();
            CreateMap<ContactWriteDto, Contact>();

            #endregion Contact

            #region ContactType

            // ContactType Map
            CreateMap<ContactType, ContactTypeReadDto>();
            CreateMap<ContactTypeReadDto, ContactType>();
            CreateMap<ContactType, ContactTypeWriteDto>();
            CreateMap<ContactTypeWriteDto, ContactType>();

            #endregion ContactType

            #endregion Vendor

        }
    }
}
