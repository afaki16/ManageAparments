import { Component, OnInit } from '@angular/core';
import { DetailApartmentOutput, HirerServiceProxy } from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-apartmentDetail',
  templateUrl: './apartmentDetail.component.html',
  styleUrls: ['./apartmentDetail.component.css']
})
export class ApartmentDetailComponent implements OnInit {

  apartmentDetail : DetailApartmentOutput[];

  constructor(private hirerService: HirerServiceProxy) {}

  ngOnInit() {
    this.hirerService.getDetailApartmentOutput().subscribe((data) => {
      this.apartmentDetail = data;
  });

  }


}
