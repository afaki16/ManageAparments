
import { AfterContentChecked, ChangeDetectorRef, Component, Injector, OnInit } from '@angular/core';
import { PagedListingComponentBase, PagedRequestDto } from '@shared/paged-listing-component-base';
import { Observable, finalize } from 'rxjs';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { DataGridOptions } from '@shared/components/data-grid/dtos/data-grid-options';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { DataGridColumn } from '@shared/components/data-grid/dtos/data-grid-column';
import { DataGridColumnType } from '@shared/components/data-grid/dtos/data-grid-column-type';
import { TableFilterModel, TableFilterSortMeta } from '@shared/components/data-grid/filters/table-filter';
import {ConfirmationService, ConfirmEventType, MessageService} from 'primeng/api';
import { InvoiceFullOutput, InvoiceServiceProxy } from '@shared/service-proxies/service-proxies';
import { InvoiceTypeEnum } from '@app/service/enum/InvoiceType';
import { CreateInvoiceComponent } from './create-invoice/create-invoice.component';
import { EditInvoiceComponent } from './edit-invoice/edit-invoice.component';

@Component({
  selector: 'app-invoice',
  templateUrl: './invoice.component.html',
  styleUrls: ['./invoice.component.css'],
  animations: [appModuleAnimation()]
})
export class InvoiceComponent extends PagedListingComponentBase<InvoiceFullOutput> implements OnInit, AfterContentChecked {
  entities: InvoiceFullOutput[];
  selectedEntities : InvoiceFullOutput[];
  dataGridOptions : DataGridOptions;
  invoiceTypeEnum = InvoiceTypeEnum;
  filteredDataRequest : TableFilterModel = new TableFilterModel();
  selectAll: boolean = false;
  totalCount: number ;
  constructor(
    injector: Injector,
    private changeDetector: ChangeDetectorRef,
    private _invoiceService : InvoiceServiceProxy,
    private _confirmationService : ConfirmationService,
    private _messageService: MessageService,
    private _modalService: BsModalService
  ) {
    super(injector);

    this.dataGridOptions = new DataGridOptions();

    this.dataGridOptions.title = this.l('Fatura');
    this.dataGridOptions.permissionNameCreate  = 'Invoice.Create';
    this.dataGridOptions.permissionNameUpdate  = 'Invoice.Update';
    this.dataGridOptions.permissionNameDelete  = 'Invoice.Delete';
    this.dataGridOptions.permissionNameExport  = 'Invoice.GetList';


    this.dataGridOptions.buttonActiveCreate = true;
    this.dataGridOptions.buttonActiveUpdate = true;
    this.dataGridOptions.buttonActiveDelete = true;
    this.dataGridOptions.buttonActiveExport = true;

    this.dataGridOptions.buttonHiddenCreate = false;
    this.dataGridOptions.buttonHiddenUpdate = false;
    this.dataGridOptions.buttonHiddenDelete = false;
    this.dataGridOptions.buttonHiddenExport = true;

    this.dataGridOptions.selectionMode ="multiple";
    this.dataGridOptions.paginationActive = true;
    this.dataGridOptions.paginationSizes = [5, 10, 20, 50];

    this.dataGridOptions.filteringGlobal = true;

    let x = new DataGridColumn();
    x.dataTitle = 'Id';
    x.dataField = 'id';
    x.dataType = DataGridColumnType.string;
    this.dataGridOptions.columns.push(x);

    x = new DataGridColumn();
    x.dataTitle = this.l('Apartman');
    x.dataField = 'apartment.building.name';
    x.dataType = DataGridColumnType.string;
    this.dataGridOptions.columns.push(x);

    x = new DataGridColumn();
    x.dataTitle = this.l('Daire');
    x.dataField = 'apartment.name';
    x.dataType = DataGridColumnType.string;
    this.dataGridOptions.columns.push(x);

    x = new DataGridColumn();
    x.dataTitle = this.l("Fatura Tipi");
    x.dataField = "type";
    x.dataType = DataGridColumnType.enum;
    x.dataEnum = this.invoiceTypeEnum;
    x.sortingEnabled = false;
    x.filteringEnabled = true;
    x.dataFieldLocalize = true;
    this.dataGridOptions.columns.push(x);

    x = new DataGridColumn();
    x.dataTitle = this.l('Abone Numarası');
    x.dataField = 'subscribeNo';
    x.dataType = DataGridColumnType.string;
    this.dataGridOptions.columns.push(x);

    x = new DataGridColumn();
    x.dataTitle = this.l('Sözleşme Numarası');
    x.dataField = 'contractNo';
    x.dataType = DataGridColumnType.string;
    this.dataGridOptions.columns.push(x);

    x = new DataGridColumn();
    x.dataTitle = this.l('Açıklama');
    x.dataField = 'description';
    x.dataType = DataGridColumnType.string;
    this.dataGridOptions.columns.push(x);

    x = new DataGridColumn();
    x.dataTitle = this.l('Aktif');
    x.dataField = 'active';
    x.dataType = DataGridColumnType.boolean;
    this.dataGridOptions.columns.push(x);



    this.dataGridOptions.parentComponent = this;
  }



  ngOnInit(): void {
  }

  ngAfterContentChecked(): void {
    this.changeDetector.detectChanges();
  }

  public list(
    request: PagedRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    this._invoiceService
    .getAllFiltered(this.filteredDataRequest)
    .pipe(
      finalize(() => {
        finishedCallback();
      })
    )
    .subscribe((response) => {

        this.entities = response.items;
        this.totalCount = response.totalCount;
        this.showPaging(response, pageNumber);

    });
  }
  public changePageNumber(event) {
    this.pageSize = event.rows;
    this.getDataPage(event.page);
  }

  public onLazyLoad(event) {
    this.filteredDataRequest.filters = event.filters;
    this.filteredDataRequest.first = event.first;
    this.filteredDataRequest.rows = event.rows;
    this.filteredDataRequest.multiSortMeta = [];
    if (Array.isArray(event.multiSortMeta)) {
      event.multiSortMeta.forEach(element => {
        this.filteredDataRequest.multiSortMeta.push(new TableFilterSortMeta(element));
      });
    }
    this.refresh();
  }

  public create() {
    this.showCreateOrEditInvoiceDialog();
  }

  public update(entitiy: InvoiceFullOutput) {
   this.showCreateOrEditInvoiceDialog(entitiy.id);
  }
  public delete(entitiy: InvoiceFullOutput): void {

    this._confirmationService.confirm({
      message: this.l('DeleteConfirmation'),
      header: this.localization.localize('AreYouSure','AbpWeb'),
      acceptLabel: this.localization.localize('Yes','AbpWeb'),
      rejectLabel: this.localization.localize('Cancel','AbpWeb'),
      acceptButtonStyleClass : "p-button-danger",
      rejectButtonStyleClass : "p-button-secondary",
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this._invoiceService.delete(entitiy.id).subscribe(() => {
          this._messageService.add({severity:'info', summary:this.l('RequestCompleted'), detail : this.l('SuccessfullyDeleted')});
          this.refresh();
        });
      },
      reject: (type) => {
          switch(type) {
              case ConfirmEventType.REJECT:
              break;
              case ConfirmEventType.CANCEL:
              break;
          }
      }
    });
  }

  private showCreateOrEditInvoiceDialog(id?: number): void {
    let createOrEditUserDialog: BsModalRef;
    if (!id) {
      createOrEditUserDialog = this._modalService.show(
        CreateInvoiceComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditUserDialog = this._modalService.show(
        EditInvoiceComponent,
        {
          class: 'modal-lg',
          initialState: {
             id: id,
          },
        }
      );
    }

    createOrEditUserDialog.content.onSave.subscribe(() => {
      this.refresh();
    });

  }


  onSelectionChange(value = []) {
    this.selectAll = value.length === this.totalCount;
    this.selectedEntities = value;
  }

  onSelectAllChange(event) {
    return new Observable((observer) => {
      const checked = event.checked;

      if (checked) {
        this.filteredDataRequest.rows = this.totalCount;
        this.filteredDataRequest.first = 0;
        this._invoiceService
          .getAllFiltered(this.filteredDataRequest)
          .pipe(finalize(() => {}))
          .subscribe((response) => {
            this.entities = response.items;
            this.totalCount = response.totalCount;
            this.showPaging(response, this.pageNumber);
            this.selectedEntities = response.items;
            this.selectAll = true;
            observer.next(this.selectedEntities);
          });
      } else {
        this.selectedEntities = [];
        this.selectAll = false;
        observer.next(this.selectedEntities);
      }
    });
  }

}
