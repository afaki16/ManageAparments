import {Injector} from '@angular/core';
import {MessageService} from 'primeng/api';
import {BsModalService} from '@node_modules/ngx-bootstrap/modal';

export class DataGridAction {
    icon: string | undefined;
    title: string | undefined;
    class: string | undefined;
    callback: Function | undefined;
    disabled: Function | undefined;

    constructor(public _messageService: MessageService, public _crudService, public _modalService, public _confirmationService) {

    }
}
