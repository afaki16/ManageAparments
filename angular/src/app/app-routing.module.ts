import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { AppRouteGuard } from '@shared/auth/auth-route-guard';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { UsersComponent } from './users/users.component';
import { TenantsComponent } from './tenants/tenants.component';
import { RolesComponent } from 'app/roles/roles.component';
import { ChangePasswordComponent } from './users/change-password/change-password.component';
import { BuildingComponent } from './defination/building/building.component';
import { ApartmentComponent } from './defination/apartment/apartment.component';
import { HirerComponent } from './defination/hirer/hirer.component';
import { InvoiceDetailComponent } from './defination/invoiceDetail/invoiceDetail.component';
import { ExpenseComponent } from './defination/expense/expense.component';
import { ExpenseTypeComponent } from './defination/expenseType/expenseType.component';
import { PaymentComponent } from './defination/payment/payment.component';
import { InHirerComponent } from './defination/transaction/inHirer/inHirer.component';
import { OutHirerComponent } from './defination/transaction/outHirer/outHirer.component';
import { ChangeRentComponent } from './defination/transaction/changeRent/changeRent.component';
import { PaidComponent } from './defination/transaction/paid/paid.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                component: AppComponent,
                children: [
                    { path: 'home', component: HomeComponent,  canActivate: [AppRouteGuard] },
                    { path: 'users', component: UsersComponent, data: { permission: 'Pages.Users' }, canActivate: [AppRouteGuard] },
                    { path: 'roles', component: RolesComponent, data: { permission: 'Pages.Roles' }, canActivate: [AppRouteGuard] },
                    { path: 'tenants', component: TenantsComponent, data: { permission: 'Pages.Tenants' }, canActivate: [AppRouteGuard] },
                    { path: 'about', component: AboutComponent, canActivate: [AppRouteGuard] },
                    { path: 'update-password', component: ChangePasswordComponent, canActivate: [AppRouteGuard] },
                    { path: 'building', component: BuildingComponent, canActivate: [AppRouteGuard] },
                    { path: 'apartment', component: ApartmentComponent, canActivate: [AppRouteGuard] },
                    { path: 'hirer', component: HirerComponent, canActivate: [AppRouteGuard] },
                    { path: 'invoiceDetail', component: InvoiceDetailComponent, canActivate: [AppRouteGuard] },
                    { path: 'expense', component: ExpenseComponent, canActivate: [AppRouteGuard] },
                    { path: 'expenseType', component: ExpenseTypeComponent, canActivate: [AppRouteGuard] },
                    { path: 'payment', component: PaymentComponent, canActivate: [AppRouteGuard] },
                    { path: 'inHirer', component: InHirerComponent, canActivate: [AppRouteGuard] },
                    { path: 'outHirer', component: OutHirerComponent, canActivate: [AppRouteGuard] },
                    { path: 'changeRent', component: ChangeRentComponent, canActivate: [AppRouteGuard] },
                    { path: 'paid', component: PaidComponent, canActivate: [AppRouteGuard] },
                ]
            }
        ])
    ],
    exports: [RouterModule]
})
export class AppRoutingModule { }
