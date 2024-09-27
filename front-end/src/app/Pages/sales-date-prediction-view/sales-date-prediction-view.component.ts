import { Component, inject } from '@angular/core';
import { Router } from '@angular/router';
import { SalesDatePrediction } from '../../Models/SalesDatePrediction';
import { CustomerService } from '../../Services/customer.service';
import { MatCardModule } from '@angular/material/card';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { OrdersModal } from '../orders-view/orders-modal.service';
import { OrdersViewComponent } from '../orders-view/orders-view.component';
import { NewOrderViewComponent } from '../new-order-view/new-order-view.component';

@Component({
  selector: 'app-sales-date-prediction-view',
  standalone: true,
  imports: [
    MatCardModule, 
    MatTableModule, 
    MatIconModule, 
    MatButtonModule
  ],
  templateUrl: './sales-date-prediction-view.component.html',
  styleUrl: './sales-date-prediction-view.component.css'
})
export class SalesDatePredictionViewComponent {
  private customerService = inject(CustomerService);
  private readonly _modalSvc = inject(OrdersModal);

  public salesPredictions: SalesDatePrediction[] = [];
  public displayedColumns : string[] = ["companyName", "lastOrderDate", "nextPredictedOrder", "accion"];

  getSalesPredictions(){
    this.customerService.getSalesPredictions().subscribe({
      next: (data) => {
        if(data.results.length > 0){
          this.salesPredictions = data.results;
        }
      },
      error: (error) => {
        console.log(error);
      }
    });
  }

  constructor(private router: Router){
    this.getSalesPredictions();
  }

  viewOrders(saleData: SalesDatePrediction){
    this._modalSvc.openModal(OrdersViewComponent, {client_id: saleData.customerId, client_name: saleData.companyName})
  }

  newOrder(saleData: SalesDatePrediction){
    this._modalSvc.openModal(NewOrderViewComponent, {saleData});
  }
}
