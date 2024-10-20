
import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { ConfirmationService, MessageService } from 'primeng/api';
import { BuildingServiceProxy,UpdateBuildingInput } from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-edit-building',
  templateUrl: './edit-building.component.html',
  styleUrls: ['./edit-building.component.css']
})
export class EditBuildingComponent extends AppComponentBase implements OnInit {
  @Output() onSave = new EventEmitter<any>();
  id : number;
  saving : boolean = false;
  updateInput : UpdateBuildingInput = new UpdateBuildingInput();

  constructor(
    injector: Injector,
    private _buildingService:BuildingServiceProxy,
    private _messageService: MessageService,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit() {
    this._buildingService.get(this.id).subscribe((response) => {
      this.updateInput = response;
    });
  }


  save(): void {
    this.saving = true;

    this._buildingService.update(this.updateInput).subscribe(
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

