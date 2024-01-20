
import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { ConfirmationService, MessageService } from 'primeng/api';
import { ApartmentServiceProxy,CreateApartmentInput } from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-create-apartment',
  templateUrl: './create-apartment.component.html',
  styleUrls: ['./create-apartment.component.css']
})
export class CreateApartmentComponent extends AppComponentBase implements OnInit {
  @Output() onSave = new EventEmitter<any>();

  saving : boolean = false;
  createInput : CreateApartmentInput = new CreateApartmentInput();

  constructor(
    injector: Injector,
    private _apartmentService: ApartmentServiceProxy,
    private _confirmationService : ConfirmationService,
    private _messageService: MessageService,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit() {
  }



  save(): void {
    this.saving = true;

     this._apartmentService.create(this.createInput).subscribe(
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
