
import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { ConfirmationService, MessageService } from 'primeng/api';
import { ExpenseServiceProxy,CreateExpenseInput, BuildingPartOutput, BuildingServiceProxy, ExpenseTypePartOutput, ExpenseTypeServiceProxy } from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-create-expense',
  templateUrl: './create-expense.component.html',
  styleUrls: ['./create-expense.component.css']
})
export class CreateExpenseComponent extends AppComponentBase implements OnInit {
  @Output() onSave = new EventEmitter<any>();

  saving : boolean = false;
  createInput : CreateExpenseInput = new CreateExpenseInput();
  buildings: BuildingPartOutput[];
  expenseTypes: ExpenseTypePartOutput[];
  constructor(
    injector: Injector,
    private _expenseService: ExpenseServiceProxy,
    private _confirmationService : ConfirmationService,
    private _buildingService: BuildingServiceProxy,
    private _expenseTypeService: ExpenseTypeServiceProxy,
    private _messageService: MessageService,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit() {
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

     this._expenseService.create(this.createInput).subscribe(
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
