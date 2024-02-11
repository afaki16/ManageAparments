import { Component, OnInit } from '@angular/core';
import { ApartmentPartOutput, ApartmentServiceProxy, HirerPartOutput, HirerServiceProxy } from '@shared/service-proxies/service-proxies';
import { ConfirmEventType, ConfirmationService, MessageService } from 'primeng/api';


@Component({
  selector: 'app-outHirer',
  templateUrl: './outHirer.component.html',
  styleUrls: ['./outHirer.component.css']
})
export class OutHirerComponent implements OnInit {
  apartments: ApartmentPartOutput[];
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

  save() {

        this._hirerService.outApartment(this.apartmentInput.id).subscribe((response) => {
          if (response) {
            abp.message.success('Başarılı','Daire Boşaltıldı.',true)
            .then(function (isConfirmed) {
              window.location.reload();
            });
          } else {
            abp.message.error('Daire Boşaltma Başarısız Oldu.', 'Danger');
          }
      });



  }

}
