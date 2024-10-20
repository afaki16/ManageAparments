
import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { ConfirmationService, MessageService } from 'primeng/api';
import { ExpenseTypeServiceProxy,CreateExpenseTypeInput } from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-create-expenseType',
  templateUrl: './create-expenseType.component.html',
  styleUrls: ['./create-expenseType.component.css']
})
export class CreateExpenseTypeComponent extends AppComponentBase implements OnInit {
  @Output() onSave = new EventEmitter<any>();

  saving : boolean = false;
  createInput : CreateExpenseTypeInput = new CreateExpenseTypeInput();

  constructor(
    injector: Injector,
    private _expenseTypeService: ExpenseTypeServiceProxy,
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

     this._expenseTypeService.create(this.createInput).subscribe(
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
