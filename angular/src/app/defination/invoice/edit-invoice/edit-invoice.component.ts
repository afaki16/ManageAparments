
import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { ConfirmationService, MessageService } from 'primeng/api';
import { InvoiceServiceProxy,UpdateInvoiceInput, ApartmentServiceProxy, ApartmentPartOutput } from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-edit-invoice',
  templateUrl: './edit-invoice.component.html',
  styleUrls: ['./edit-invoice.component.css']
})
export class EditInvoiceComponent extends AppComponentBase implements OnInit {
  @Output() onSave = new EventEmitter<any>();
  id : number;
  saving : boolean = false;
  updateInput : UpdateInvoiceInput = new UpdateInvoiceInput();
  apartments: ApartmentPartOutput[];
  invoiceTypes = [];

  constructor(
    injector: Injector,
    private _invoiceService:InvoiceServiceProxy,
    private _apartmentService: ApartmentServiceProxy,
    private _messageService: MessageService,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }


  ngOnInit() {
    this._invoiceService.get(this.id).subscribe((response) => {
      this.updateInput = response;
    });
    this.invoiceTypes = this.getInvoiceTypeEnumsAndValues();
    this.getApartments()
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

    this._invoiceService.update(this.updateInput).subscribe(
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

