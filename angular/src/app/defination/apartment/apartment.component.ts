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
import { ApartmentFullOutput, ApartmentServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreateApartmentComponent } from './create-apartment/create-apartment.component';
import { EditApartmentComponent } from './edit-apartment/edit-apartment.component';



@Component({
  selector: 'app-apartment',
  templateUrl: './apartment.component.html',
  styleUrls: ['./apartment.component.css'],
  animations: [appModuleAnimation()]
})
export class ApartmentComponent extends PagedListingComponentBase<ApartmentFullOutput> implements OnInit, AfterContentChecked {
  entities: ApartmentFullOutput[];
  selectedEntities : ApartmentFullOutput[];
  dataGridOptions : DataGridOptions;
  filteredDataRequest : TableFilterModel = new TableFilterModel();
  selectAll: boolean = false;
  totalCount: number ;
  constructor(
    injector: Injector,
    private changeDetector: ChangeDetectorRef,
    private _apartmentService : ApartmentServiceProxy,
    private _confirmationService : ConfirmationService,
    private _messageService: MessageService,
    private _modalService: BsModalService
  ) {
    super(injector);

    this.dataGridOptions = new DataGridOptions();

    this.dataGridOptions.title = this.l('Daireler');
    this.dataGridOptions.permissionNameCreate  = 'Apartment.Create';
    this.dataGridOptions.permissionNameUpdate  = 'Apartment.Update';
    this.dataGridOptions.permissionNameDelete  = 'Apartment.Delete';
    this.dataGridOptions.permissionNameExport  = 'Apartment.GetList';


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
    x.dataTitle = this.l('Apartmanlar');
    x.dataField = 'building.name';
    x.dataType = DataGridColumnType.string;
    this.dataGridOptions.columns.push(x);

    x = new DataGridColumn();
    x.dataTitle = this.l("İsim");
    x.dataField = "name";
    x.dataType = DataGridColumnType.string;
    this.dataGridOptions.columns.push(x);

    x = new DataGridColumn();
    x.dataTitle = this.l('Kat Numarası');
    x.dataField = 'roofNo';
    x.dataType = DataGridColumnType.string;
    this.dataGridOptions.columns.push(x);

    x = new DataGridColumn();
    x.dataTitle = this.l('Açıklama');
    x.dataField = 'description';
    x.dataType = DataGridColumnType.string;
    this.dataGridOptions.columns.push(x);

    x = new DataGridColumn();
    x.dataTitle = this.l('Dolu mu?');
    x.dataField = 'isActive';
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
    this._apartmentService
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
    this.showCreateOrEditApartmentDialog();
  }

  public update(entitiy: ApartmentFullOutput) {
   this.showCreateOrEditApartmentDialog(entitiy.id);
  }
  public delete(entitiy: ApartmentFullOutput): void {

    this._confirmationService.confirm({
      message: this.l('DeleteConfirmation'),
      header: this.localization.localize('AreYouSure','AbpWeb'),
      acceptLabel: this.localization.localize('Yes','AbpWeb'),
      rejectLabel: this.localization.localize('Cancel','AbpWeb'),
      acceptButtonStyleClass : "p-button-danger",
      rejectButtonStyleClass : "p-button-secondary",
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this._apartmentService.delete(entitiy.id).subscribe(() => {
          this._messageService.add({severity:'info', summary:this.l(entitiy.name + ' ' + 'başaralı şekilde silindi' ), detail : this.l('SuccessfullyDeleted')});
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

  private showCreateOrEditApartmentDialog(id?: number): void {
    let createOrEditUserDialog: BsModalRef;
    if (!id) {
      createOrEditUserDialog = this._modalService.show(
        CreateApartmentComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditUserDialog = this._modalService.show(
       EditApartmentComponent,
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
        this._apartmentService
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
