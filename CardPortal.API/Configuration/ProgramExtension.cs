#region Reference

using CardPortal.Domain.AggregateModel.Account;
using CardPortal.Domain.AggregateModel.Card;
using CardPortal.Domain.AggregateModel.Transaction;
using CardPortal.Domain.AggregateModel.User;
using CardPortal.Domain.AggregateModel.Vendor;
using CardPortal.Persistence.Repository.Account;
using CardPortal.Persistence.Repository.Card;
using CardPortal.Persistence.Repository.Transaction;
using CardPortal.Persistence.Repository.User;
using CardPortal.Persistence.Repository.Vendor;
using CardPortal.Domain.AggregateModel.Vendor.Address.Address;
using CardPortal.Domain.AggregateModel.Vendor.Address.Area;
using CardPortal.Domain.AggregateModel.Vendor.Address.City;
using CardPortal.Persistence.Repository.Vendor.Address.Address;
using CardPortal.Persistence.Repository.Vendor.Address.Area;
using CardPortal.Persistence.Repository.Vendor.Address.City;
using CardPortal.Domain.AggregateModel.Vendor.Contact.Contact;
using CardPortal.Persistence.Repository.Vendor.Contact.Contact;
using CardPortal.Domain.AggregateModel.Vendor.Contact.ContactType;
using CardPortal.Persistence.Repository.Vendor.Contact.ContactType;
using MediatR;
using System.Reflection;
using CardPortal.Application.Command.Account;
using CardPortal.Application.Query.Account;
using CardPortal.Application.Command.Card;
using CardPortal.Application.Query.Card;
using CardPortal.Application.Command.Transaction;
using CardPortal.Application.Query.Transaction;
using CardPortal.Application.Query.User;
using CardPortal.Application.Command.User;
using CardPortal.Application.Query.Vendor;
using CardPortal.Application.Command.Vendor;
using CardPortal.Application.Command.Vendor.Address.Address;
using CardPortal.Application.Command.Vendor.Address.Area;
using CardPortal.Application.Command.Vendor.Address.City;
using CardPortal.Application.Command.Vendor.Contact.Contact;
using CardPortal.Application.Command.Vendor.Contact.ContactType;

#endregion Reference

namespace CardPortal.API.Configuration
{
    public static class ProgramExtension
    {
        // Custom Services - <Repository Interface, Repository>
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            // Add Services To Collection
            services
                .AddScoped<IAccountRepository, AccountRepository>()
                .AddScoped<ICardRepository, CardRepository>()
                .AddScoped<ITransactionRepository, TransactionRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IVendorRepository, VendorRepository>()
                .AddScoped<IAddressRepository, AddressRepository>()
                .AddScoped<IAreaRepository, AreaRepository>()
                .AddScoped<ICityRepository, CityRepository>()
                .AddScoped<IContactRepository, ContactRepository>()
                .AddScoped<IContactTypeRepository, ContactTypeRepository>();

            return services;
        }

        // MediatR - Command, Query
        public static IServiceCollection AddMediatRServices(this IServiceCollection services)
        {
            var mediatRAssembly = GetCommandQueryAssembly();

            // Add Services To Collection
            services
                .AddMediatR(mediatRAssembly);

            return services;
        }

        // Command Query Assembly
        private static Assembly[] GetCommandQueryAssembly()
        {
            return new Assembly[]
            {
                // Account
                typeof(GetUserAccountsQueryHandler).GetTypeInfo().Assembly,
                typeof(GetAccountQueryHandler).GetTypeInfo().Assembly,
                typeof(CreateAccountCommandHandler).GetTypeInfo().Assembly,
                typeof(UpdateAccountCommandHandler).GetTypeInfo().Assembly,
                typeof(DeleteAccountCommandHandler).GetTypeInfo().Assembly,
                // Card
                typeof(GetUserCardsQueryHandler).GetTypeInfo().Assembly,
                typeof(GetCardQueryHandler).GetTypeInfo().Assembly,
                typeof(CreateCardCommandHandler).GetTypeInfo().Assembly,
                typeof(UpdateCardCommandHandler).GetTypeInfo().Assembly,
                typeof(DeleteCardCommandHandler).GetTypeInfo().Assembly,
                // Transaction
                typeof(GetUserTransactionsQueryHandler).GetTypeInfo().Assembly,
                typeof(GetTransactionQueryHandler).GetTypeInfo().Assembly,
                typeof(CreateTransactionCommandHandler).GetTypeInfo().Assembly,
                // User
                typeof(GetAllUsersQueryHandler).GetTypeInfo().Assembly,
                typeof(GetUserByUsernameQueryHandler).GetTypeInfo().Assembly,
                typeof(GetUserQueryHandler).GetTypeInfo().Assembly,
                typeof(ChangePasswordCommandHandler).GetTypeInfo().Assembly,
                typeof(ChangeUsernameCommandHandler).GetTypeInfo().Assembly,
                typeof(CreateUserCommandHandler).GetTypeInfo().Assembly,
                typeof(DeleteUserCommandHandler).GetTypeInfo().Assembly,
                typeof(LoginCommandHandler).GetTypeInfo().Assembly,
                typeof(RequestNewPasswordCommandHandler).GetTypeInfo().Assembly,
                typeof(UpdateUserCommandHandler).GetTypeInfo().Assembly,
                // Vendor
                typeof(GetAllVendorsQueryHandler).GetTypeInfo().Assembly,
                typeof(GetVendorQueryHandler).GetTypeInfo().Assembly,
                typeof(CreateVendorCommandHandler).GetTypeInfo().Assembly,
                typeof(UpdateVendorCommandHandler).GetTypeInfo().Assembly,
                typeof(DeleteVendorCommandHandler).GetTypeInfo().Assembly,
                // Address
                typeof(CreateAddressCommandHandler).GetTypeInfo().Assembly,
                typeof(UpdateAddressCommandHandler).GetTypeInfo().Assembly,
                typeof(DeleteAddressCommandHandler).GetTypeInfo().Assembly,
                // Area
                typeof(CreateAreaCommandHandler).GetTypeInfo().Assembly,
                typeof(UpdateAreaCommandHandler).GetTypeInfo().Assembly,
                typeof(DeleteAreaCommandHandler).GetTypeInfo().Assembly,
                // City
                typeof(CreateCityCommandHandler).GetTypeInfo().Assembly,
                typeof(UpdateCityCommandHandler).GetTypeInfo().Assembly,
                typeof(DeleteCityCommandHandler).GetTypeInfo().Assembly,
                // Contact
                typeof(CreateContactCommandHandler).GetTypeInfo().Assembly,
                typeof(UpdateContactCommandHandler).GetTypeInfo().Assembly,
                typeof(DeleteContactCommandHandler).GetTypeInfo().Assembly,
                // Contact Type
                typeof(CreateContactTypeCommandHandler).GetTypeInfo().Assembly,
                typeof(UpdateContactTypeCommandHandler).GetTypeInfo().Assembly,
                typeof(DeleteContactTypeCommandHandler).GetTypeInfo().Assembly,
            };
        }
    }
}
