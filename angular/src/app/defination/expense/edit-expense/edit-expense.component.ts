
import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { ConfirmationService, MessageService } from 'primeng/api';
import { BuildingPartOutput, BuildingServiceProxy, ExpenseServiceProxy,ExpenseTypePartOutput,ExpenseTypeServiceProxy,UpdateExpenseInput } from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-edit-expense',
  templateUrl: './edit-expense.component.html',
  styleUrls: ['./edit-expense.component.css']
})
export class EditExpenseComponent extends AppComponentBase implements OnInit {
  @Output() onSave = new EventEmitter<any>();
  id : number;
  saving : boolean = false;
  updateInput : UpdateExpenseInput = new UpdateExpenseInput();
  buildings: BuildingPartOutput[];
  expenseTypes: ExpenseTypePartOutput[];

  constructor(
    injector: Injector,
    private _expenseService:ExpenseServiceProxy,
    private _messageService: MessageService,
    private _buildingService: BuildingServiceProxy,
    private _expenseTypeService: ExpenseTypeServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit() {
    this._expenseService.get(this.id).subscribe((response) => {
      this.updateInput = response;
    });
    this.getBuildings();
    this.getExpenseTypes();
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

  getExpenseTypes() {
    this._expenseTypeService.getExpenseTypePartOutputs().subscribe((response) => {
      if (response) {
        this.expenseTypes = response;
        this.saving = false;
      } else {
        this.saving = false;
      }
    });
  }

  save(): void {
    this.saving = true;

    this._expenseService.update(this.updateInput).subscribe(
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

