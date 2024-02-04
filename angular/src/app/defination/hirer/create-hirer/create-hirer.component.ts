
import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { ConfirmationService, MessageService } from 'primeng/api';
import { HirerServiceProxy,CreateHirerInput, ApartmentServiceProxy, ApartmentPartOutput } from '@shared/service-proxies/service-proxies';
import { log } from 'console';

@Component({
  selector: 'app-create-hirer',
  templateUrl: './create-hirer.component.html',
  styleUrls: ['./create-hirer.component.css']
})
export class CreateHirerComponent extends AppComponentBase implements OnInit {
  @Output() onSave = new EventEmitter<any>();

  saving : boolean = false;
  createInput : CreateHirerInput = new CreateHirerInput();
  apartments: ApartmentPartOutput[];

  constructor(
    injector: Injector,
    private _hirerService: HirerServiceProxy,
    private _apartmentService: ApartmentServiceProxy,
    private _messageService: MessageService,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit() {
    this.getApartments()
  }

  getApartments() {
    this._apartmentService.getActiveApartmentPartOutputs().subscribe((response) => {
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
debugger
     this._hirerService.create(this.createInput).subscribe(
      (response) => {
        if (response) {
          this._messageService.add({ severity: 'success', summary: this.l('Kiracı Oluşturuldu.'), detail: this.l('SavedSuccessfully') });
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
