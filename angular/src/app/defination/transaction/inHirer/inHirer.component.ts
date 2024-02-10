import { Component, OnInit } from '@angular/core';
import { ApartmentPartOutput, ApartmentServiceProxy, HirerPartOutput, HirerServiceProxy } from '@shared/service-proxies/service-proxies';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-inHirer',
  templateUrl: './inHirer.component.html',
  styleUrls: ['./inHirer.component.css']
})
export class InHirerComponent implements OnInit {
  hirers: HirerPartOutput[];
  apartments: ApartmentPartOutput[];
  hirerInput :  HirerPartOutput = new HirerPartOutput();
  apartmentInput : ApartmentPartOutput = new ApartmentPartOutput();
  constructor(
    private _hirerService: HirerServiceProxy,
    private _apartmentService: ApartmentServiceProxy,
    private _messageService: MessageService,
  ) { }

  ngOnInit() {
    this.getApartment();
    this.getHirers();
  }

  getHirers() {
    this._hirerService.getActiveHirerPartOutputs().subscribe((response) => {
        if (response) {
            this.hirers = response;

        } else {

        }
    });
}
getApartment() {
  this._apartmentService.getActiveApartmentPartOutputs().subscribe((response) => {
      if (response) {
          this.apartments = response;

      } else {

      }
  });
}

save(): void {
  this._hirerService.hirerInApartment(this.apartmentInput.id, this.hirerInput.id).subscribe(
    );
 this._messageService.add({ severity: 'success', summary: 'Request Completed', detail: 'Saved Successfully' });
 abp.message.success('Kiracı Yerleştirildi.', 'Success');
 window.location.reload();
}
}
