import { Component, OnInit } from '@angular/core';
import { InvoiceTypeEnum } from '@app/service/enum/InvoiceType';
import { GetAllPaidReport, InvoiceDetailServiceProxy } from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-paid',
  templateUrl: './paid.component.html',
  styleUrls: ['./paid.component.css']
})
export class PaidComponent implements OnInit {

  paidReport : GetAllPaidReport[];
  invoiceTypeEnum = InvoiceTypeEnum;

  constructor(private invoiceDetailService: InvoiceDetailServiceProxy) {}

  ngOnInit() {
    this.invoiceDetailService.getAllPaidReport().subscribe((data) => {
      this.paidReport = data;
  });

  }
}
