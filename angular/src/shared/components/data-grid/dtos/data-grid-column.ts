import { BaseEnum } from "../enums/base-enum";
import { DataGridColumnType } from "./data-grid-column-type";

export class DataGridColumn {
    dataTitle : string;
    dataField : string;
    dataType : DataGridColumnType;
    dataEnum : BaseEnum[];

    dataTitleLocalize : boolean = true;
    dataFieldLocalize  : boolean = false;

    sortingEnabled : boolean = true;
    filteringEnabled : boolean = true;
    filteringGlobalEnabled : boolean = true;

    style : string = "";
}
