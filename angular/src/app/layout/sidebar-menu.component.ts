import {Component, Injector, OnInit} from '@angular/core';
import {AppComponentBase} from '@shared/app-component-base';
import {
    Router,
    RouterEvent,
    NavigationEnd,
    PRIMARY_OUTLET
} from '@angular/router';
import {BehaviorSubject} from 'rxjs';
import {filter} from 'rxjs/operators';
import {MenuItem} from '@shared/layout/menu-item';

@Component({
    selector: 'sidebar-menu',
    templateUrl: './sidebar-menu.component.html'
})
export class SidebarMenuComponent extends AppComponentBase implements OnInit {
    menuItems: MenuItem[];
    menuItemsMap: { [key: number]: MenuItem } = {};
    activatedMenuItems: MenuItem[] = [];
    routerEvents: BehaviorSubject<RouterEvent> = new BehaviorSubject(undefined);
    homeRoute = '/app/home';

    constructor(injector: Injector, private router: Router) {
        super(injector);
    }

    ngOnInit(): void {
        this.menuItems = this.getMenuItems();
        this.patchMenuItems(this.menuItems);

        this.router.events.subscribe((event: NavigationEnd) => {
            const currentUrl = event.url !== '/' ? event.url : this.homeRoute;
                const primaryUrlSegmentGroup = this.router.parseUrl(currentUrl).root
                    .children[PRIMARY_OUTLET];
                if (primaryUrlSegmentGroup) {
                    this.activateMenuItems('/' + primaryUrlSegmentGroup.toString());
                }
        });
    }

    getMenuItems(): MenuItem[] {
        return [

            new MenuItem(this.l('HomePage'), '/app/home', 'fas fa-home'),
            new MenuItem(this.l('Binalar'), '/app/building', "ml-2 fas fa-building"),
            new MenuItem(this.l('Daireler'), '/app/apartment', 'fas fa-home'),
            new MenuItem(this.l('Kiracılar'), '/app/hirer', "ml-2 fa fa-handshake"),
            new MenuItem(this.l('Ödemeler'), '/app/invoiceDetail', "ml-2 fas fa-receipt"),
            new MenuItem(this.l('Ödeme Takip'), '/app/payment', "fa-solid fa-cart-shopping"),

            new MenuItem(this.l('İşlemler'), '', "fa fa-bar-chart ml-2 nav-icon",'',[
                new MenuItem(
                    'Tahsilatlar',
                    '/app/paid',
                    'fas fa-check'
                ),
                new MenuItem(
                    'Kira Düzenle',
                    '/app/changeRent',
                    'fa-solid fa-arrows-rotate'
                ),
                new MenuItem(
                    'Daireyi Boşalt',
                    '/app/outHirer',
                    'fa-solid fa-arrow-turn-up'
                ),
                new MenuItem(
                    'Kiracı Yerleştir',
                    '/app/inHirer',
                    'fa-solid fa-arrow-turn-down'
                ),

        ]),

            new MenuItem(this.l('Masraflar'), '', 'fa-solid fa-money-check-dollar', '', [

                    new MenuItem(
                        'Masraf Girişi',
                        '/app/expense',
                        'fa-solid fa-file-invoice-dollar'
                    ),
                    new MenuItem(
                        'Masraf Türleri',
                        '/app/expenseType',
                        'fa-solid fa-hurricane'
                    ),

            ]),

            new MenuItem(
                this.l('Roles'),
                '/app/roles',
                'fas fa-theater-masks',
                'Pages.Roles'
            ),

            new MenuItem(
                this.l('Users'),
                '/app/users',
                'fas fa-users',
                'Pages.Users'
            ),
            // new MenuItem(this.l('MultiLevelMenu'), '', 'fas fa-circle', '', [
            //     new MenuItem('ASP.NET Boilerplate', '', 'fas fa-dot-circle', '', [
            //         new MenuItem(
            //             'Home',
            //             'https://aspnetboilerplate.com?ref=abptmpl',
            //             'far fa-circle'
            //         ),
            //         new MenuItem(
            //             'Templates',
            //             'https://aspnetboilerplate.com/Templates?ref=abptmpl',
            //             'far fa-circle'
            //         ),
            //         new MenuItem(
            //             'Samples',
            //             'https://aspnetboilerplate.com/Samples?ref=abptmpl',
            //             'far fa-circle'
            //         ),
            //         new MenuItem(
            //             'Documents',
            //             'https://aspnetboilerplate.com/Pages/Documents?ref=abptmpl',
            //             'far fa-circle'
            //         ),
            //     ]),

            // ])
        ];
    }

    patchMenuItems(items: MenuItem[], parentId?: number): void {
        items.forEach((item: MenuItem, index: number) => {
            item.id = parentId ? Number(parentId + '' + (index + 1)) : index + 1;
            if (parentId) {
                item.parentId = parentId;
            }
            if (parentId || item.children) {
                this.menuItemsMap[item.id] = item;
            }
            if (item.children) {
                this.patchMenuItems(item.children, item.id);
            }
        });
    }

    activateMenuItems(url: string): void {
        this.deactivateMenuItems(this.menuItems);
        this.activatedMenuItems = [];
        const foundedItems = this.findMenuItemsByUrl(url, this.menuItems);
        foundedItems.forEach((item) => {
            this.activateMenuItem(item);
        });
    }

    deactivateMenuItems(items: MenuItem[]): void {
        items.forEach((item: MenuItem) => {
            item.isActive = false;
            item.isCollapsed = true;
            if (item.children) {
                this.deactivateMenuItems(item.children);
            }
        });
    }

    findMenuItemsByUrl(
        url: string,
        items: MenuItem[],
        foundedItems: MenuItem[] = []
    ): MenuItem[] {
        items.forEach((item: MenuItem) => {
            if (item.route === url) {
                foundedItems.push(item);
            } else if (item.children) {
                this.findMenuItemsByUrl(url, item.children, foundedItems);
            }
        });
        return foundedItems;
    }

    activateMenuItem(item: MenuItem): void {
        item.isActive = true;
        if (item.children) {
            item.isCollapsed = false;
        }
        this.activatedMenuItems.push(item);
        if (item.parentId) {
            this.activateMenuItem(this.menuItemsMap[item.parentId]);
        }
    }

    isMenuItemVisible(item: MenuItem): boolean {
        if (!item.permissionName) {
            return true;
        }
        return this.permission.isGranted(item.permissionName);
    }
}
