import { Component, Inject, inject, OnInit, ViewChild } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { OrderService } from '../../Services/order.service';
import { Order } from '../../Models/Order';
import { Router } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatSort, MatSortModule } from '@angular/material/sort';

@Component({
  selector: 'app-orders-view',
  templateUrl: './orders-view.component.html',
  styleUrls: ['./orders-view.component.css'],
  standalone: true,
  imports: [
    MatCardModule, 
    MatTableModule, 
    MatIconModule, 
    MatButtonModule,
    MatPaginatorModule,
    MatSortModule
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

  public client_id!: number;
  public client_name!: string;
  public dataSource!: MatTableDataSource<Order>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    this.dataSource = new MatTableDataSource<Order>();
  }
  ngOnInit(): void {
    console.log(this.data);
    this.client_id = this.data.client_id;
    this.client_name = this.data.client_name;

    if (this.client_id != 0) {
      this.ordersService.getOrdersByClient(this.client_id).subscribe({
        next: (data) => {
          if (data.results.length > 0) {
            this.dataSource.data = data.results;
            this.dataSource.paginator = this.paginator;
            this.dataSource.sort = this.sort;
          }
        },
      });
    }
  }
}
