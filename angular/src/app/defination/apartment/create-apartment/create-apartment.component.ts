
import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { ConfirmationService, MessageService } from 'primeng/api';
import { ApartmentServiceProxy,BuildingPartOutput,BuildingServiceProxy,CreateApartmentInput, CreateElectricInput, CreateFeeInput, CreateRentInput, ElectricServiceProxy, FeeServiceProxy, RentServiceProxy } from '@shared/service-proxies/service-proxies';
import { log } from 'console';

@Component({
  selector: 'app-create-apartment',
  templateUrl: './create-apartment.component.html',
  styleUrls: ['./create-apartment.component.css']
})
export class CreateApartmentComponent extends AppComponentBase implements OnInit {
  @Output() onSave = new EventEmitter<any>();

  saving : boolean = false;
  createInput : CreateApartmentInput = new CreateApartmentInput();
  createInputElectric : CreateElectricInput = new CreateElectricInput();
  createInputFee : CreateFeeInput = new CreateFeeInput();
  createInputRent : CreateRentInput = new CreateRentInput();
  buildings: BuildingPartOutput[];
  _apartmanId:number;
  constructor(
    injector: Injector,
    private _apartmentService: ApartmentServiceProxy,
    private _electricService: ElectricServiceProxy,
    private _feeService: FeeServiceProxy,
    private _rentService: RentServiceProxy,
    private _buildingService: BuildingServiceProxy,
    private _messageService: MessageService,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit() {
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

     this._apartmentService.create(this.createInput).subscribe(
      (response) => {
        if (response) {

          this._apartmanId = response.id;
          this.createInputElectric.apartmentId =this._apartmanId
    this.createInputElectric.isActive =true

 this._electricService.create(this.createInputElectric).subscribe(
  (response) => {
    if (response) {
      this._messageService.add({ severity: 'success', summary: this.l('Sayaç oluşturuldu'), detail: this.l('SavedSuccessfully') });
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

 this.createInputFee.apartmentId =this._apartmanId
 this.createInputFee.isActive =true


 this._feeService.create(this.createInputFee).subscribe(
  (response) => {
    if (response) {
      this._messageService.add({ severity: 'success', summary: this.l('Aidat oluşturuldu'), detail: this.l('SavedSuccessfully') });
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

this.createInputRent.apartmentId =this._apartmanId
 this.createInputRent.isActive =true


this._rentService.create(this.createInputRent).subscribe(
  (response) => {
    if (response) {
      this._messageService.add({ severity: 'success', summary: this.l('Kira oluşturuldu'), detail: this.l('SavedSuccessfully') });
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







          this._messageService.add({ severity: 'success', summary: this.l('Daire Oluşturuldu'), detail: this.l('SavedSuccessfully') });
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
