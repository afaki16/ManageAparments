
import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { ConfirmationService, MessageService } from 'primeng/api';
import { HirerServiceProxy,UpdateHirerInput, ApartmentServiceProxy, ApartmentPartOutput } from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-edit-hirer',
  templateUrl: './edit-hirer.component.html',
  styleUrls: ['./edit-hirer.component.css']
})
export class EditHirerComponent extends AppComponentBase implements OnInit {
  @Output() onSave = new EventEmitter<any>();
  id : number;
  saving : boolean = false;
  updateInput : UpdateHirerInput = new UpdateHirerInput();
  apartments: ApartmentPartOutput[];

  constructor(
    injector: Injector,
    private _hirerService:HirerServiceProxy,
    private _apartmentService: ApartmentServiceProxy,
    private _messageService: MessageService,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }


  ngOnInit() {
    this._hirerService.get(this.id).subscribe((response) => {
      this.updateInput = response;
    });
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

    this._hirerService.update(this.updateInput).subscribe(
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

