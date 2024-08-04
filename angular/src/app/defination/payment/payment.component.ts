import { Component, OnInit } from '@angular/core';
import { InvoiceTypeEnum } from '@app/service/enum/InvoiceType';
import { InvoiceDetailFullOutput, InvoiceDetailServiceProxy } from '@shared/service-proxies/service-proxies';
import { log } from 'console';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent implements OnInit {
  invoices: InvoiceDetailFullOutput[];
  invoiceTypeEnum = InvoiceTypeEnum;

    constructor(private _invoiceDetailService: InvoiceDetailServiceProxy,) {}

    ngOnInit() {

        this._invoiceDetailService.getAllPayment().subscribe((invoices) => {
            this.invoices = invoices;
        });
    }

    getTime(invoiceDate:Date) {

        var invoiceDate = new Date(invoiceDate);
        var today = new Date();
        var differenceInMilliseconds = invoiceDate.getTime() - today.getTime();
        var oneDayInMilliseconds = 1000 * 60 * 60 * 24;
        var differenceInDays = Math.floor(differenceInMilliseconds / oneDayInMilliseconds);

        return differenceInDays;
    }





    getSeverity(status: number) {
        if (31<status) {
            return'secondary'
        }
        else if(3<status && status<31)
        {
             return 'success'
        }
        else if(0<status &&status<3)
        {
            return 'warning'
        }
        else
        {
            return 'danger'
        }

    }
}
