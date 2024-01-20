import { PagedListingComponentBase } from "@shared/paged-listing-component-base";
import { DataGridAction } from "./data-grid-action";
import { DataGridColumn } from "./data-grid-column";

export class DataGridOptions {
    //Header
    title : string = '';

    //Permission Names
    permissionNameCreate : string = '';
    permissionNameUpdate : string = '';
    permissionNameDelete : string = '';
    permissionNameExport : string = '';

    //Button Controllers
    buttonActiveCreate : boolean = true;
    buttonActiveUpdate : boolean = true;
    buttonActiveDelete : boolean = true;
    buttonActiveExport : boolean = true;

    buttonHiddenCreate : boolean = false;
    buttonHiddenUpdate : boolean = false;
    buttonHiddenDelete : boolean = false;
    buttonHiddenExport : boolean = false;

    isButtonUpdateActive : Function = undefined;
    isButtonDeleteActive : Function = undefined;

    //Pagination
    paginationActive : boolean = true;
    paginationSizes : number[] = [5, 10, 20];

    //Filtering
    filteringGlobal : boolean = false;

    //Data Columns
    columns : DataGridColumn[] = [];
    actions : DataGridAction[] = [];

    //Parent Component
    parentComponent : any;

    //Selection Mode
    selectionMode : undefined | "single" | "multiple" = undefined;
  }
