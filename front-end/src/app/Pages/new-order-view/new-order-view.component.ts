import { Component, Inject, OnInit, inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { EmployeeService } from '../../Services/employee.service';
import { ShipperService } from '../../Services/shipper.service';
import { ProductService } from '../../Services/product.service';
import { Employee } from '../../Models/Employee';
import { CreateOrderWithProductsRequest } from '../../Models/Request/CreateOrderWithProductsRequest';
import { Shipper } from '../../Models/Shipper';
import { Product } from '../../Models/Product';
import { OrderService } from '../../Services/order.service';
import { Order } from '../../Models/Order';
import { OrderDetails } from '../../Models/OrderDetails';
import { MAT_DATE_LOCALE, MatNativeDateModule } from '@angular/material/core';

@Component({
  selector: 'app-new-order-view',
  standalone: true,
  imports: [
    MatButtonModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatDatepickerModule,
    ReactiveFormsModule,
    MatNativeDateModule
  ],
  providers: [
    { provide: MAT_DATE_LOCALE, useValue: 'es-ES' },
    MatNativeDateModule
  ],
  templateUrl: './new-order-view.component.html',
  styleUrls: ['./new-order-view.component.css']
})
export class NewOrderViewComponent implements OnInit {
  private fb = inject(FormBuilder);
  private employeeService = inject(EmployeeService);
  private shipperService = inject(ShipperService);
  private productService = inject(ProductService);
  private orderService = inject(OrderService);
  
  public employees : Employee[] = [];
  public shippers : Shipper[] = [];
  public products : Product[] = [];
  
  public orderForm!: FormGroup;

  constructor(
    private dialogRef: MatDialogRef<NewOrderViewComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
  }

  ngOnInit(): void {
    
    this.orderForm = this.fb.group({
      employee: ['', Validators.required],
      shipper: ['', Validators.required],
      shipName: ['', Validators.required],
      shipAddress: ['', Validators.required],
      shipCity: ['', Validators.required],
      shipCountry: ['', Validators.required],
      orderDate: ['', Validators.required],
      requiredDate: ['', Validators.required],
      shippedDate: [''],
      freight: ['', Validators.required],
      product: ['', Validators.required],
      unitPrice: ['', Validators.required],
      quantity: ['', Validators.required],
      discount: ['']
    });

    this.employeeService.getAll().subscribe({
      next:(data) => {
        if(data.results.length > 0){
          this.employees = data.results
        }
      }
    });

    this.shipperService.getAll().subscribe({
      next: (data) => {
        if(data.results.length > 0){
          this.shippers = data.results;
        }
      }
    });

    this.productService.getAll().subscribe({
      next: (data) => {
        if(data.results.length > 0){
          this.products = data.results;
        }
      }
    });
  }

  save() {
    console.log(this.orderForm.value);
    if (this.orderForm.valid) {
      var newOrder : Order = {
        orderId: 0,
        requiredDate: this.orderForm.value.requiredDate,
        shipAddress: this.orderForm.value.shipAddress,
        shipCity: this.orderForm.value.shipCity,
        shipName: this.orderForm.value.shipName,
        shippedDate: this.orderForm.value.shippedDate
      }
      var newOrderDetails : OrderDetails = {
        Discount: this.orderForm.value.discount,
        OrderId: 0,
        ProductID: this.orderForm.value.product,
        Qty: this.orderForm.value.quantity,
        UnitPrice: this.orderForm.value.unitPrice,
      }
      var formulario:CreateOrderWithProductsRequest = {
        NewOrder: newOrder,
        NewOrderDetails: [newOrderDetails]
      };
      this.orderService.addOrder(formulario)
      alert('Orden creada con éxito');
      this.close();
    }
  }

  close() {
    this.dialogRef.close();
  }
}
