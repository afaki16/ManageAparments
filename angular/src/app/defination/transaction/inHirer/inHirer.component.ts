import { Component, OnInit } from '@angular/core';
import { ApartmentPartOutput, ApartmentServiceProxy, HirerPartOutput, HirerServiceProxy } from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-inHirer',
  templateUrl: './inHirer.component.html',
  styleUrls: ['./inHirer.component.css']
})
export class InHirerComponent implements OnInit {
  hirers: HirerPartOutput[];
  apartments: ApartmentPartOutput[];
  constructor(
    private _hirerService: HirerServiceProxy,
    private _apartmentService: ApartmentServiceProxy,
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
}
