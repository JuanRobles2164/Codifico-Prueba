import { Component, ViewChild, inject } from '@angular/core';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MatCardModule } from '@angular/material/card';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { Router } from '@angular/router';
import { SalesDatePrediction } from '../../Models/SalesDatePrediction';
import { CustomerService } from '../../Services/customer.service';
import { OrdersModal } from '../orders-view/orders-modal.service';
import { OrdersViewComponent } from '../orders-view/orders-view.component';
import { NewOrderViewComponent } from '../new-order-view/new-order-view.component';
import { MatFormFieldModule, MatLabel } from '@angular/material/form-field';

@Component({
  selector: 'app-sales-date-prediction-view',
  standalone: true,
  imports: [
    MatCardModule, 
    MatTableModule, 
    MatIconModule, 
    MatButtonModule,
    MatPaginatorModule,
    MatLabel,
    MatFormFieldModule,
  ],
  templateUrl: './sales-date-prediction-view.component.html',
  styleUrls: ['./sales-date-prediction-view.component.css']
})
export class SalesDatePredictionViewComponent {
  private customerService = inject(CustomerService);
  private readonly _modalSvc = inject(OrdersModal);

  public displayedColumns: string[] = ["companyName", "lastOrderDate", "nextPredictedOrder", "accion"];
  public dataSource = new MatTableDataSource<SalesDatePrediction>([]);

  @ViewChild(MatPaginator) paginator!: MatPaginator; // Obtenemos referencia al paginador

  constructor(private router: Router) {
    this.getSalesPredictions();
  }

  getSalesPredictions() {
    this.customerService.getSalesPredictions().subscribe({
      next: (data) => {
        if (data.results.length > 0) {
          this.dataSource.data = data.results;
          this.dataSource.paginator = this.paginator; // Asignamos el paginador a la fuente de datos
        }
      },
      error: (error) => {
        console.log(error);
      }
    });
  }

  viewOrders(saleData: SalesDatePrediction) {
    this._modalSvc.openModal(OrdersViewComponent, { client_id: saleData.customerId, client_name: saleData.companyName });
  }

  newOrder(saleData: SalesDatePrediction) {
    this._modalSvc.openModal(NewOrderViewComponent, { saleData });
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
}
