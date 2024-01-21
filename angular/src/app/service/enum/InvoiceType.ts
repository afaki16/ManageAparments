
export enum InvoiceType {

    Dues = 0,
    Water = 1,
    Electric = 2,
    Heat = 3,
}

export const InvoiceTypeEnum: Array<BaseEnum> = [
    { id: 0, displayName: "Aidat" },
    { id: 1, displayName: "Su" },
    { id: 2, displayName: "Elektrik" },
    { id: 3, displayName: "Doğal Gaz" }

];
