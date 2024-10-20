using System.ComponentModel;

namespace ManageApartments.Domain.Enums

{
    public enum InvoiceType
    {
        [Description("Aidat")]
        Fee = 0,
        [Description("Kira")]
        Rent = 1,
        [Description("Elektrik")]
        Electric = 2,
        [Description("Diğer")]
        Other = 3,


    }
}
