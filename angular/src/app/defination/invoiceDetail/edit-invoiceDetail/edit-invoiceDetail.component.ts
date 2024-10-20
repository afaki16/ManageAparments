
import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { ConfirmationService, MessageService } from 'primeng/api';
import { InvoiceDetailServiceProxy,BuildingPartOutput,UpdateInvoiceDetailInput, HirerServiceProxy, HirerPartOutput } from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-edit-invoiceDetail',
  templateUrl: './edit-invoiceDetail.component.html',
  styleUrls: ['./edit-invoiceDetail.component.css']
})
export class EditInvoiceDetailComponent extends AppComponentBase implements OnInit {
  @Output() onSave = new EventEmitter<any>();
  id : number;
  saving : boolean = false;
  invoiceTypes = [];
  updateInput : UpdateInvoiceDetailInput = new UpdateInvoiceDetailInput();
  hirers: HirerPartOutput[];

  constructor(
    injector: Injector,
    private _invoiceDetailService:InvoiceDetailServiceProxy,
    private _hirerService: HirerServiceProxy,
    private _messageService: MessageService,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }


  ngOnInit() {
    this.invoiceTypes = this.getInvoiceTypeEnumsAndValues();
    this._invoiceDetailService.get(this.id).subscribe((response) => {
      this.updateInput = response;
    });
    this.getHirers();
  }

  getHirers() {
    this._hirerService.getHirerPartOutputs().subscribe((response) => {
        if (response) {
            this.hirers = response;
            this.saving = false;
        } else {
            this.saving = false;
        }
    });
}



  save(): void {
    this.saving = true;

    this._invoiceDetailService.update(this.updateInput).subscribe(
      (response) => {
        if (response) {
          this._messageService.add({ severity: 'success', summary: this.l('RequestCompleted'), detail: this.l('SavedSuccessfully') });
          this.bsModalRef.hide();
          this.onSave.emit();
        }
      },
      (error) =>{
        this.saving = false;
        let errorMessage= error.error.error.message;
        this._messageService.add({ severity: 'error', summary: this.l('Error'), detail: errorMessage });

      });

  }
}

