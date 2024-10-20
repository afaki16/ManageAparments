
import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { ConfirmationService, MessageService } from 'primeng/api';
import { ApartmentServiceProxy,BuildingPartOutput,BuildingServiceProxy,UpdateApartmentInput } from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-edit-apartment',
  templateUrl: './edit-apartment.component.html',
  styleUrls: ['./edit-apartment.component.css']
})
export class EditApartmentComponent extends AppComponentBase implements OnInit {
  @Output() onSave = new EventEmitter<any>();
  id : number;
  saving : boolean = false;
  updateInput : UpdateApartmentInput = new UpdateApartmentInput();
  buildings: BuildingPartOutput[];

  constructor(
    injector: Injector,
    private _apartmentService:ApartmentServiceProxy,
    private _buildingService: BuildingServiceProxy,
    private _messageService: MessageService,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }


  ngOnInit() {
    this._apartmentService.get(this.id).subscribe((response) => {
      this.updateInput = response;
    });
    this.getBuildings();
  }

  getBuildings() {
    this._buildingService.getBuildingPartOutputs().subscribe((response) => {
        if (response) {
            this.buildings = response;
            this.saving = false;
        } else {
            this.saving = false;
        }
    });
}



  save(): void {
    this.saving = true;

    this._apartmentService.update(this.updateInput).subscribe(
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

