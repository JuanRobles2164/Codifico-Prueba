import { Component, Inject, inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { OrderService } from '../../Services/order.service';
import { Order } from '../../Models/Order';
import { Router } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-orders-view',
  templateUrl: './orders-view.component.html',
  styleUrls: ['./orders-view.component.css'],
  standalone: true,
  imports: [
    MatCardModule, 
    MatTableModule, 
    MatIconModule, 
    MatButtonModule
  ],
})
export class OrdersViewComponent implements OnInit {
  private ordersService = inject(OrderService);
  public orders: Order[] = [];
  public displayedColumns = [
    'orderId',
    'requiredDate',
    'shippedDate',
    'shipName',
    'shipAddress',
    'shipCity',
  ];

  // Variables para almacenar los datos recibidos
  public client_id!: number;
  public client_name!: string;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
  }

  ngOnInit(): void {
    // Asignar datos al inicializar el componente
    console.log(this.data);
    this.client_id = this.data.client_id;
    this.client_name = this.data.client_name;

    // Lógica para obtener las órdenes basadas en client_id
    if (this.client_id != 0) {
      this.ordersService.getOrdersByClient(this.client_id).subscribe({
        next: (data) => {
          if (data.results.length > 0) {
            this.orders = data.results;
          }
        },
      });
    }
  }
}
