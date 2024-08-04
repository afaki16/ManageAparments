import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { Base64FileUpload, CreateLoginImageInput, LoginImageServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { ConfirmationService, MessageService } from 'primeng/api';

@Component({
  selector: 'app-create-loginImage',
  templateUrl: './create-loginImage.component.html',
  styleUrls: ['./create-loginImage.component.css']
})
export class CreateLoginImageComponent extends AppComponentBase implements OnInit {

  @Output() onSave = new EventEmitter<any>();

  saving : boolean = false;
  createInput : CreateLoginImageInput = new CreateLoginImageInput();

  constructor(
    injector: Injector,
    private _loginImageService: LoginImageServiceProxy,
    private _confirmationService : ConfirmationService,
    private _messageService: MessageService,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit() {
  }

  onFileSelected(event) {
    let fileReader = new FileReader();
    this.createInput.base64FileUpload = new Base64FileUpload();
    let currentInput = this.createInput;

    for (let file of event.files) {
      currentInput.base64FileUpload.fileName = file.name;
      currentInput.base64FileUpload.fileExtn = file.type;
      fileReader.readAsDataURL(file);
      fileReader.onload = function () {
        currentInput.base64FileUpload.fileData = fileReader.result.toString();
      };
    }
  }

  save(): void {
    this.saving = true;

     this._loginImageService.create(this.createInput).subscribe(
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
