import { Component, OnInit } from '@angular/core';
import { HirerPartOutput, HirerServiceProxy, InvoiceDetailFullOutput, InvoiceDetailServiceProxy } from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent implements OnInit {
  invoices: InvoiceDetailFullOutput[];
  statuses!: any[];

    constructor(private _invoiceDetailService: InvoiceDetailServiceProxy,) {}

    ngOnInit() {
        this._invoiceDetailService.getAllPayment().subscribe((invoices) => {
            this.invoices = invoices;

        });

        this.statuses = [
            { label: 'Unqualified', value: 'unqualified' },
            { label: 'Qualified', value: 'qualified' },
            { label: 'New', value: 'new' },
            { label: 'Negotiation', value: 'negotiation' },
            { label: 'Renewal', value: 'renewal' },
            { label: 'Proposal', value: 'proposal' }
        ];
    }


    getSeverity(status: string) {
        switch (status) {
            case 'unqualified':
                return 'danger';

            case 'qualified':
                return 'success';

            case 'new':
                return 'info';

            case 'negotiation':
                return 'warning';

            case 'renewal':
                return null;
        }
    }
}
