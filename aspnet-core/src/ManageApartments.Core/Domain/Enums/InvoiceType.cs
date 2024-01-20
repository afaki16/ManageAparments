using System.ComponentModel;

namespace ManageApartments.Domain.Enums

{
    public enum InvoiceType
    {
        [Description("Aidat")]
        Dues = 0,
        [Description("Su")]
        Water = 1,
        [Description("Elektrik")]
        Electric = 2,
        [Description("Doğal Gaz")]
        Heat = 3,
    }
}
