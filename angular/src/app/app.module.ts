import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientJsonpModule } from '@angular/common/http';
import { HttpClientModule } from '@angular/common/http';
import { ModalModule } from 'ngx-bootstrap/modal';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { NgxPaginationModule } from 'ngx-pagination';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ServiceProxyModule } from '@shared/service-proxies/service-proxy.module';
import { SharedModule } from '@shared/shared.module';
import { HomeComponent } from '@app/home/home.component';
import { AboutComponent } from '@app/about/about.component';
// tenants
import { TenantsComponent } from '@app/tenants/tenants.component';
import { CreateTenantDialogComponent } from './tenants/create-tenant/create-tenant-dialog.component';
import { EditTenantDialogComponent } from './tenants/edit-tenant/edit-tenant-dialog.component';
// roles
import { RolesComponent } from '@app/roles/roles.component';
import { CreateRoleDialogComponent } from './roles/create-role/create-role-dialog.component';
import { EditRoleDialogComponent } from './roles/edit-role/edit-role-dialog.component';
// users
import { UsersComponent } from '@app/users/users.component';
import { CreateUserDialogComponent } from '@app/users/create-user/create-user-dialog.component';
import { EditUserDialogComponent } from '@app/users/edit-user/edit-user-dialog.component';
import { ChangePasswordComponent } from './users/change-password/change-password.component';
import { ResetPasswordDialogComponent } from './users/reset-password/reset-password.component';
// layout
import { HeaderComponent } from './layout/header.component';
import { HeaderLeftNavbarComponent } from './layout/header-left-navbar.component';
import { HeaderLanguageMenuComponent } from './layout/header-language-menu.component';
import { HeaderUserMenuComponent } from './layout/header-user-menu.component';
import { FooterComponent } from './layout/footer.component';
import { SidebarComponent } from './layout/sidebar.component';
import { SidebarLogoComponent } from './layout/sidebar-logo.component';
import { SidebarUserPanelComponent } from './layout/sidebar-user-panel.component';
import { SidebarMenuComponent } from './layout/sidebar-menu.component';
// primeng
import { PrimeNgModule } from "@shared/PrimeNg/PrimeNg.module";
import { CalendarModule } from 'primeng/calendar';
import { ToastModule } from 'primeng/toast';
import { TableModule } from 'primeng/table';
import { InputNumberModule } from 'primeng/inputnumber';
import { DataGridComponent } from "@shared/components/data-grid/data-grid.component";
//building
import {BuildingComponent} from '@app/defination/building/building.component';
import { CreateBuildingComponent } from './defination/building/create-building/create-building.component';
import { EditBuildingComponent } from './defination/building/edit-building/edit-building.component';
//apartment
import {ApartmentComponent} from '@app/defination/apartment/apartment.component';
import { CreateApartmentComponent } from './defination/apartment/create-apartment/create-apartment.component';
import { EditApartmentComponent } from './defination/apartment/edit-apartment/edit-apartment.component';
//hirer
import {HirerComponent} from '@app/defination/hirer/hirer.component';
import { CreateHirerComponent } from './defination/hirer/create-hirer/create-hirer.component';
import { EditHirerComponent } from './defination/hirer/edit-hirer/edit-hirer.component';
 //invoiceDetail
import {InvoiceDetailComponent} from '@app/defination/invoiceDetail/invoiceDetail.component';
import {CreateInvoiceDetailComponent} from '@app/defination/invoiceDetail/create-invoiceDetail/create-invoiceDetail.component';
import {EditInvoiceDetailComponent} from '@app/defination/invoiceDetail/edit-invoiceDetail/edit-invoiceDetail.component';




@NgModule({
    declarations: [
        AppComponent,
        HomeComponent,
        AboutComponent,
        // tenants
        TenantsComponent,
        CreateTenantDialogComponent,
        EditTenantDialogComponent,
        // roles
        RolesComponent,
        CreateRoleDialogComponent,
        EditRoleDialogComponent,
        // users
        UsersComponent,
        CreateUserDialogComponent,
        EditUserDialogComponent,
        ChangePasswordComponent,
        ResetPasswordDialogComponent,
        // layout
        HeaderComponent,
        HeaderLeftNavbarComponent,
        HeaderLanguageMenuComponent,
        HeaderUserMenuComponent,
        FooterComponent,
        SidebarComponent,
        SidebarLogoComponent,
        SidebarUserPanelComponent,
        SidebarMenuComponent,
        DataGridComponent,
         // building
         BuildingComponent,
         CreateBuildingComponent,
         EditBuildingComponent,
         //apartment
         ApartmentComponent,
         CreateApartmentComponent,
         EditApartmentComponent,
         //hirer
         HirerComponent,
         CreateHirerComponent,
         EditHirerComponent,

         //invoiceDetail
         InvoiceDetailComponent,
         CreateInvoiceDetailComponent,
         EditInvoiceDetailComponent,

    ],
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        HttpClientModule,
        HttpClientJsonpModule,
        ModalModule.forChild(),
        BsDropdownModule,
        CollapseModule,
        TabsModule,
        AppRoutingModule,
        ServiceProxyModule,
        SharedModule,
        NgxPaginationModule,
        PrimeNgModule,
        ToastModule,
        CalendarModule,
        TableModule,
        InputNumberModule
    ],
    providers: []
})
export class AppModule {}
