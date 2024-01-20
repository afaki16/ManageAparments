using AutoMapper;
using ManageApartments.Domain.Apartment.Dtos;
using ManageApartments.Domain.Building.Dtos;
using ManageApartments.Domain.Entities;
using ManageApartments.Domain.Hirer.Dtos;
using ManageApartments.Domain.Invoice.Dtos;
using ManageApartments.Domain.InvoiceDetail.Dtos;

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

            cfg.CreateMap<Invoice, CreateInvoiceInput>();
            cfg.CreateMap<Invoice, DeleteInvoiceInput>();
            cfg.CreateMap<Invoice, InvoiceFullOutput>();
            cfg.CreateMap<Invoice, InvoicePartOutput>();
            cfg.CreateMap<Invoice, GetInvoiceInput>();
            cfg.CreateMap<Invoice, GetInvoiceListInput>();
            cfg.CreateMap<Invoice, UpdateInvoiceInput>();

            cfg.CreateMap<InvoiceDetail, CreateInvoiceDetailInput>();
            cfg.CreateMap<InvoiceDetail, DeleteInvoiceDetailInput>();
            cfg.CreateMap<InvoiceDetail, InvoiceDetailFullOutput>();
            cfg.CreateMap<InvoiceDetail, InvoiceDetailPartOutput>();
            cfg.CreateMap<InvoiceDetail, GetInvoiceDetailInput>();
            cfg.CreateMap<InvoiceDetail, GetInvoiceDetailListInput>();
            cfg.CreateMap<InvoiceDetail, UpdateInvoiceDetailInput>();


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

            cfg.CreateMap<CreateInvoiceInput, Invoice>();
            cfg.CreateMap<DeleteInvoiceInput, Invoice>();
            cfg.CreateMap<InvoiceFullOutput, Invoice>();
            cfg.CreateMap<InvoicePartOutput, Invoice>();
            cfg.CreateMap<GetInvoiceInput, Invoice>();
            cfg.CreateMap<GetInvoiceListInput, Invoice>();
            cfg.CreateMap<UpdateInvoiceInput, Invoice>();

            cfg.CreateMap<CreateInvoiceDetailInput, InvoiceDetail>();
            cfg.CreateMap<DeleteInvoiceDetailInput, InvoiceDetail>();
            cfg.CreateMap<InvoiceDetailFullOutput, InvoiceDetail>();
            cfg.CreateMap<InvoiceDetailPartOutput, InvoiceDetail>();
            cfg.CreateMap<GetInvoiceDetailInput, InvoiceDetail>();
            cfg.CreateMap<GetInvoiceDetailListInput, InvoiceDetail>();
            cfg.CreateMap<UpdateInvoiceDetailInput, InvoiceDetail>();

        }
    }
}
