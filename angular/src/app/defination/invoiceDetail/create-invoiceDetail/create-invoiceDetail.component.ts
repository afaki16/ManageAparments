
import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { ConfirmationService, MessageService } from 'primeng/api';
import { InvoiceDetailServiceProxy,CreateInvoiceDetailInput, ApartmentServiceProxy, ApartmentPartOutput, HirerPartOutput, HirerServiceProxy } from '@shared/service-proxies/service-proxies';
import { log } from 'console';

@Component({
  selector: 'app-create-invoiceDetail',
  templateUrl: './create-invoiceDetail.component.html',
  styleUrls: ['./create-invoiceDetail.component.css']
})
export class CreateInvoiceDetailComponent extends AppComponentBase implements OnInit {
  @Output() onSave = new EventEmitter<any>();

  saving : boolean = false;
  createInput : CreateInvoiceDetailInput = new CreateInvoiceDetailInput();
  invoiceTypes = [];
  hirers: HirerPartOutput[];


  constructor(
    injector: Injector,
    private _invoiceDetailService: InvoiceDetailServiceProxy,
    private _messageService: MessageService,
    private _hirerService: HirerServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit() {
    this.invoiceTypes = this.getInvoiceTypeEnumsAndValues();
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

     this._invoiceDetailService.create(this.createInput).subscribe(
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

      }
    );

  }
}
