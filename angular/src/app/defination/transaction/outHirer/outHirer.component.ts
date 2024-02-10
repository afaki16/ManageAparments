import { Component, OnInit } from '@angular/core';
import { ApartmentPartOutput, ApartmentServiceProxy, HirerPartOutput, HirerServiceProxy } from '@shared/service-proxies/service-proxies';
import { ConfirmEventType, ConfirmationService, MessageService } from 'primeng/api';


@Component({
  selector: 'app-outHirer',
  templateUrl: './outHirer.component.html',
  styleUrls: ['./outHirer.component.css']
})
export class OutHirerComponent implements OnInit {
  hirers: HirerPartOutput[];
  apartments: ApartmentPartOutput[];
  hirerInput :  HirerPartOutput = new HirerPartOutput();
  apartmentInput : ApartmentPartOutput = new ApartmentPartOutput();

  constructor(
    private _hirerService: HirerServiceProxy,
    private _apartmentService: ApartmentServiceProxy,
    private _messageService: MessageService,
    private _confirmationService : ConfirmationService,
  ) { }

  ngOnInit() {
    this.getApartment();
  }

  getApartment() {
    this._apartmentService.getApartmentPartOutputs().subscribe((response) => {
        if (response) {
            this.apartments = response;

        } else {

        }
    });
  }
  save(entitiy: ApartmentPartOutput): void {
debugger
    this._confirmationService.confirm({
      message: '',
      header: 'Emin misiniz',
      acceptLabel: 'Evet',
      rejectLabel: 'İptal',
      acceptButtonStyleClass : "p-button-danger",
      rejectButtonStyleClass : "p-button-secondary",
      icon: 'pi pi-exclamation-triangle',

      accept: () => {
        this._apartmentService.update(entitiy).subscribe(() => {
          this._messageService.add({severity:'info', summary:'RequestCompleted', detail : 'SuccessfullyDeleted'});
          window.location.reload();
        });
      },
      reject: (type) => {
          switch(type) {
              case ConfirmEventType.REJECT:
              break;
              case ConfirmEventType.CANCEL:
              break;
          }
      }
    });
  }


}
