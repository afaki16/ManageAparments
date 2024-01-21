
import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { ConfirmationService, MessageService } from 'primeng/api';
import { InvoiceServiceProxy,CreateInvoiceInput, ApartmentServiceProxy, ApartmentPartOutput } from '@shared/service-proxies/service-proxies';
import { log } from 'console';

@Component({
  selector: 'app-create-invoice',
  templateUrl: './create-invoice.component.html',
  styleUrls: ['./create-invoice.component.css']
})
export class CreateInvoiceComponent extends AppComponentBase implements OnInit {
  @Output() onSave = new EventEmitter<any>();

  saving : boolean = false;
  createInput : CreateInvoiceInput = new CreateInvoiceInput();
  invoiceTypes = [];
  apartments: ApartmentPartOutput[];


  constructor(
    injector: Injector,
    private _invoiceService: InvoiceServiceProxy,
    private _messageService: MessageService,
    private _apartmentService: ApartmentServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit() {
    this.invoiceTypes = this.getInvoiceTypeEnumsAndValues();
    this.getApartments();
  }

  getApartments() {
    this._apartmentService.getApartmentPartOutputs().subscribe((response) => {
        if (response) {
            this.apartments = response;
            this.saving = false;
        } else {
            this.saving = false;
        }
    });
}


  save(): void {
    this.saving = true;

     this._invoiceService.create(this.createInput).subscribe(
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
