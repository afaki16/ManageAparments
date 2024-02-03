import { BaseEnum } from "@shared/components/data-grid/enums/base-enum";

export enum InvoiceType {

    Aidat = 0,
    Kira = 1,
    Elektrik = 2,
    Diğer = 3,
}

export const InvoiceTypeEnum: Array<BaseEnum> = [
    { id: 0, displayName: "Aidat" },
    { id: 1, displayName: "Kira" },
    { id: 2, displayName: "Elektrik" },
    { id: 3, displayName: "Diğer" }

];
