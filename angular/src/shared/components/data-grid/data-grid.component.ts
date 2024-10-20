import { Component, Injector, Input, OnInit } from "@angular/core";
import { AppComponentBase } from "@shared/app-component-base";
import { BaseEnum } from "../data-grid/enums/base-enum";
import { DataGridColumnType } from "./dtos/data-grid-column-type";
import { DataGridOptions } from "./dtos/data-grid-options";
import { DatePipe } from "@angular/common";
import { Table } from "primeng/table";

import {


} from "@shared/service-proxies/service-proxies";
import * as moment from "moment";

@Component({
  selector: "app-data-grid",
  templateUrl: "./data-grid.component.html",
  styleUrls: ["./data-grid.component.css"],
})
export class DataGridComponent extends AppComponentBase implements OnInit {
  @Input() dataGridOptions: DataGridOptions;
  @Input() entities: any[];
  @Input() excelEntities: any[];

  dataGridColumnType: DataGridColumnType;
  exportColumns: any[];
  selectedEntities: any[];

  constructor(
    injector: Injector,
    private _datePipe: DatePipe

  ) {
    super(injector);
  }

  ngOnInit() {
    this.exportColumns = this.dataGridOptions?.columns?.map((col) => ({
      title: col.dataTitle,
      dataKey: col.dataField,
    }));
  }

  fetchFromObject(
    rowData,
    dataField,
    dataType: DataGridColumnType,
    enumData: BaseEnum[]
  ) {
    if (rowData == undefined || rowData == null) {
      return "~";
    }
    let _index = dataField.indexOf(".");
    if (_index > -1) {
      return this.fetchFromObject(
        rowData[dataField.substring(0, _index)],
        dataField.substr(_index + 1),
        dataType,
        enumData
      );
    }

    if (rowData[dataField] == undefined || rowData[dataField] == null) {
      return "~";
    }

    switch (dataType) {
      case DataGridColumnType.string:
      case DataGridColumnType.number:
      case DataGridColumnType.image:
        return rowData[dataField];
      case DataGridColumnType.boolean:
        if (rowData[dataField]) {
          return "fa-regular fa-circle-check text-green";
        } else {
          return "fa-regular fa-circle-xmark text-red";
        }
      case DataGridColumnType.enum:
        return this.l(
          enumData.find((x) => x.id == rowData[dataField]).displayName
        );
        case DataGridColumnType.date:
          return (
            this._datePipe.transform(
              new Date(rowData[dataField])?.toString(),
              "shortDate"
            ) +
            " " +
            this._datePipe.transform(
              new Date(rowData[dataField])?.toString(),
              "mediumTime"
            )
          );
          case DataGridColumnType.dateOnly:
        return this._datePipe.transform(
          new Date(rowData[dataField])?.toString(),
          "shortDate"
        );
      case DataGridColumnType.timeOnly:
        return this._datePipe.transform(
          new Date(rowData[dataField])?.toString(),
          "mediumTime"
        );

      case DataGridColumnType.color:
        return `background-color: ${rowData[dataField]} ; padding: 10px; border: 1px solid black;`;
    }
  }

  protected isCreateActive() {
    return (
      this.dataGridOptions.buttonActiveCreate &&
      this.isGranted(this.dataGridOptions.permissionNameCreate)
    );
  }

  protected isEditActive(entity: any) {
    if (this.dataGridOptions.isButtonUpdateActive !== undefined) {
      return (
        this.dataGridOptions.buttonActiveUpdate &&
        this.isGranted(this.dataGridOptions.permissionNameUpdate) &&
        this.dataGridOptions.isButtonUpdateActive(entity)
      );
    }
    return (
      this.dataGridOptions.buttonActiveUpdate &&
      this.isGranted(this.dataGridOptions.permissionNameUpdate)
    );
  }

  protected isDeleteActive(entity: any) {
    if (this.dataGridOptions.isButtonDeleteActive !== undefined) {
      return (
        this.dataGridOptions.buttonActiveDelete &&
        this.isGranted(this.dataGridOptions.permissionNameDelete) &&
        this.dataGridOptions.isButtonDeleteActive(entity)
      );
    }
    return (
      this.dataGridOptions.buttonActiveDelete &&
      this.isGranted(this.dataGridOptions.permissionNameDelete)
    );
  }

  protected isExportActive() {
    return (
      this.dataGridOptions.buttonActiveExport &&
      this.isGranted(this.dataGridOptions.permissionNameExport)
    );
  }



  isHighlight(selectedEntities: any, rowData: any): boolean {
    if (Array.isArray(selectedEntities)) {
      return selectedEntities?.some((value, index) => value == rowData);
    } else {
      return selectedEntities == rowData;
    }
  }

  onSelectionChange(value = []) {
    this.selectedEntities = value;
    this.dataGridOptions.parentComponent.onSelectionChange(value);
  }

  onSelectAllChange(event) {
    this.dataGridOptions.parentComponent
      .onSelectAllChange(event)
      .subscribe((selectedEntities) => {
        this.selectedEntities = selectedEntities;
      });
  }

  paginate(event) {
    console.warn("eventpagechange",event);
  }
  // restoreTableFirst() {
  //   if (this.tableFirst) {
  //     this.dataGridOptions.t;
  //     delete this.tableFirst;
  //   }

}
