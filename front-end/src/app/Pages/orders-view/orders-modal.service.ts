import { ComponentType } from "@angular/cdk/portal";
import { inject, Injectable } from "@angular/core";
import { MatDialog } from '@angular/material/dialog';

@Injectable({providedIn: 'root'})
export class OrdersModal{
    private readonly _dialog = inject(MatDialog);

    openModal<CT, T>(componentRef: ComponentType<CT>, data?: T): any {
        console.log(data);
        this._dialog.open(componentRef, {
          data,
        });
    }

    closeModal(){
        this._dialog.closeAll();
    }

}