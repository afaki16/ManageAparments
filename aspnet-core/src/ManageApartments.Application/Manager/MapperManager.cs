using AutoMapper;
using ManageApartments.Domain.Apartment.Dtos;
using ManageApartments.Domain.Building.Dtos;
using ManageApartments.Domain.Electric.Dtos;
using ManageApartments.Domain.Entities;
using ManageApartments.Domain.Expense.Dtos;
using ManageApartments.Domain.ExpenseType.Dtos;
using ManageApartments.Domain.Fee.Dtos;
using ManageApartments.Domain.Hirer.Dtos;
using ManageApartments.Domain.InvoiceDetail.Dtos;
using ManageApartments.Domain.Rent.Dtos;

namespace ManageApartments.Manager
{
    public class MapperManager : AutoMapper.Profile
    {
        public static void DtosToDomain(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Building, CreateBuildingInput>();
            cfg.CreateMap<Building, DeleteBuildingInput>();
            cfg.CreateMap<Building, BuildingFullOutput>();
            cfg.CreateMap<Building, BuildingPartOutput>();
            cfg.CreateMap<Building, GetBuildingInput>();
            cfg.CreateMap<Building, GetBuildingListInput>();
            cfg.CreateMap<Building, UpdateBuildingInput>();

            cfg.CreateMap<Apartment, CreateApartmentInput>();
            cfg.CreateMap<Apartment, DeleteApartmentInput>();
            cfg.CreateMap<Apartment, ApartmentFullOutput>();
            cfg.CreateMap<Apartment, ApartmentPartOutput>();
            cfg.CreateMap<Apartment, GetApartmentInput>();
            cfg.CreateMap<Apartment, GetApartmentListInput>();
            cfg.CreateMap<Apartment, UpdateApartmentInput>();

            cfg.CreateMap<Hirer, CreateHirerInput>();
            cfg.CreateMap<Hirer, DeleteHirerInput>();
            cfg.CreateMap<Hirer, HirerFullOutput>();
            cfg.CreateMap<Hirer, HirerPartOutput>();
            cfg.CreateMap<Hirer, GetHirerInput>();
            cfg.CreateMap<Hirer, GetHirerListInput>();
            cfg.CreateMap<Hirer, UpdateHirerInput>();

            cfg.CreateMap<InvoiceDetail, CreateInvoiceDetailInput>();
            cfg.CreateMap<InvoiceDetail, DeleteInvoiceDetailInput>();
            cfg.CreateMap<InvoiceDetail, InvoiceDetailFullOutput>();
            cfg.CreateMap<InvoiceDetail, InvoiceDetailPartOutput>();
            cfg.CreateMap<InvoiceDetail, GetInvoiceDetailInput>();
            cfg.CreateMap<InvoiceDetail, GetInvoiceDetailListInput>();
            cfg.CreateMap<InvoiceDetail, UpdateInvoiceDetailInput>();

            cfg.CreateMap<Expense, CreateExpenseInput>();
            cfg.CreateMap<Expense, DeleteExpenseInput>();
            cfg.CreateMap<Expense, ExpenseFullOutput>();
            cfg.CreateMap<Expense, ExpensePartOutput>();
            cfg.CreateMap<Expense, GetExpenseInput>();
            cfg.CreateMap<Expense, GetExpenseListInput>();
            cfg.CreateMap<Expense, UpdateExpenseInput>();

            cfg.CreateMap<ExpenseType, CreateExpenseTypeInput>();
            cfg.CreateMap<ExpenseType, DeleteExpenseTypeInput>();
            cfg.CreateMap<ExpenseType, ExpenseTypeFullOutput>();
            cfg.CreateMap<ExpenseType, ExpenseTypePartOutput>();
            cfg.CreateMap<ExpenseType, GetExpenseTypeInput>();
            cfg.CreateMap<ExpenseType, GetExpenseTypeListInput>();
            cfg.CreateMap<ExpenseType, UpdateExpenseTypeInput>();

            cfg.CreateMap<Electric, CreateElectricInput>();
            cfg.CreateMap<Electric, DeleteElectricInput>();
            cfg.CreateMap<Electric, ElectricFullOutput>();
            cfg.CreateMap<Electric, ElectricPartOutput>();
            cfg.CreateMap<Electric, GetElectricInput>();
            cfg.CreateMap<Electric, GetElectricListInput>();
            cfg.CreateMap<Electric, UpdateElectricInput>();

            cfg.CreateMap<Fee, CreateFeeInput>();
            cfg.CreateMap<Fee, DeleteFeeInput>();
            cfg.CreateMap<Fee, FeeFullOutput>();
            cfg.CreateMap<Fee, FeePartOutput>();
            cfg.CreateMap<Fee, GetFeeInput>();
            cfg.CreateMap<Fee, GetFeeListInput>();
            cfg.CreateMap<Fee, UpdateFeeInput>();

            cfg.CreateMap<Rent, CreateRentInput>();
            cfg.CreateMap<Rent, DeleteRentInput>();
            cfg.CreateMap<Rent, RentFullOutput>();
            cfg.CreateMap<Rent, RentPartOutput>();
            cfg.CreateMap<Rent, GetRentInput>();
            cfg.CreateMap<Rent, GetRentListInput>();
            cfg.CreateMap<Rent, UpdateRentInput>();


        }
        public static void DomainToDtos(IMapperConfigurationExpression cfg)
        {

            cfg.CreateMap<CreateBuildingInput, Building>();
            cfg.CreateMap<DeleteBuildingInput, Building>();
            cfg.CreateMap<BuildingFullOutput, Building>();
            cfg.CreateMap<BuildingPartOutput, Building>();
            cfg.CreateMap<GetBuildingInput, Building>();
            cfg.CreateMap<GetBuildingListInput, Building>();
            cfg.CreateMap<UpdateBuildingInput, Building>();

            cfg.CreateMap<CreateApartmentInput, Apartment>();
            cfg.CreateMap<DeleteApartmentInput, Apartment>();
            cfg.CreateMap<ApartmentFullOutput, Apartment>();
            cfg.CreateMap<ApartmentPartOutput, Apartment>();
            cfg.CreateMap<GetApartmentInput, Apartment>();
            cfg.CreateMap<GetApartmentListInput, Apartment>();
            cfg.CreateMap<UpdateApartmentInput, Apartment>();

            cfg.CreateMap<CreateHirerInput, Hirer>();
            cfg.CreateMap<DeleteHirerInput, Hirer>();
            cfg.CreateMap<HirerFullOutput, Hirer>();
            cfg.CreateMap<HirerPartOutput, Hirer>();
            cfg.CreateMap<GetHirerInput, Hirer>();
            cfg.CreateMap<GetHirerListInput, Hirer>();
            cfg.CreateMap<UpdateHirerInput, Hirer>();

            cfg.CreateMap<CreateInvoiceDetailInput, InvoiceDetail>();
            cfg.CreateMap<DeleteInvoiceDetailInput, InvoiceDetail>();
            cfg.CreateMap<InvoiceDetailFullOutput, InvoiceDetail>();
            cfg.CreateMap<InvoiceDetailPartOutput, InvoiceDetail>();
            cfg.CreateMap<GetInvoiceDetailInput, InvoiceDetail>();
            cfg.CreateMap<GetInvoiceDetailListInput, InvoiceDetail>();
            cfg.CreateMap<UpdateInvoiceDetailInput, InvoiceDetail>();

            cfg.CreateMap<CreateExpenseInput, Expense>();
            cfg.CreateMap<DeleteExpenseInput, Expense>();
            cfg.CreateMap<ExpenseFullOutput, Expense>();
            cfg.CreateMap<ExpensePartOutput, Expense>();
            cfg.CreateMap<GetExpenseInput, Expense>();
            cfg.CreateMap<GetExpenseListInput, Expense>();
            cfg.CreateMap<UpdateExpenseInput, Expense>();

            cfg.CreateMap<CreateExpenseTypeInput, ExpenseType>();
            cfg.CreateMap<DeleteExpenseTypeInput, ExpenseType>();
            cfg.CreateMap<ExpenseTypeFullOutput, ExpenseType>();
            cfg.CreateMap<ExpenseTypePartOutput, ExpenseType>();
            cfg.CreateMap<GetExpenseTypeInput, ExpenseType>();
            cfg.CreateMap<GetExpenseTypeListInput, ExpenseType>();
            cfg.CreateMap<UpdateExpenseTypeInput, ExpenseType>();

            cfg.CreateMap<CreateElectricInput, Electric>();
            cfg.CreateMap<DeleteElectricInput, Electric>();
            cfg.CreateMap<ElectricFullOutput, Electric>();
            cfg.CreateMap<ElectricPartOutput, Electric>();
            cfg.CreateMap<GetElectricInput, Electric>();
            cfg.CreateMap<GetElectricListInput, Electric>();
            cfg.CreateMap<UpdateElectricInput, Electric>();

            cfg.CreateMap<CreateFeeInput, Fee>();
            cfg.CreateMap<DeleteFeeInput, Fee>();
            cfg.CreateMap<FeeFullOutput, Fee>();
            cfg.CreateMap<FeePartOutput, Fee>();
            cfg.CreateMap<GetFeeInput, Fee>();
            cfg.CreateMap<GetFeeListInput, Fee>();
            cfg.CreateMap<UpdateFeeInput, Fee>();

            cfg.CreateMap<CreateRentInput, Rent>();
            cfg.CreateMap<DeleteRentInput, Rent>();
            cfg.CreateMap<RentFullOutput, Rent>();
            cfg.CreateMap<RentPartOutput, Rent>();
            cfg.CreateMap<GetRentInput, Rent>();
            cfg.CreateMap<GetRentListInput, Rent>();
            cfg.CreateMap<UpdateRentInput, Rent>();
        }
    }
}
