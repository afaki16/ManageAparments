import { Component, OnInit } from '@angular/core';
import { DetailApartmentOutput, HirerServiceProxy } from '@shared/service-proxies/service-proxies';
import { TreeNode } from 'primeng/api';

@Component({
  selector: 'app-changeRent',
  templateUrl: './changeRent.component.html',
  styleUrls: ['./changeRent.component.css']
})
export class ChangeRentComponent implements OnInit {

  apartmentDetail : DetailApartmentOutput[];

  constructor(private hirerService: HirerServiceProxy) {}

  ngOnInit() {
    this.hirerService.getDetailApartmentOutput().subscribe((data) => {
      this.apartmentDetail = data;
  });

  }

}
