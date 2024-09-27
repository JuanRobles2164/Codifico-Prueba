import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { appsettings } from '../Settings/appsettings';
import { CreateOrderWithProductsRequest } from '../Models/Request/CreateOrderWithProductsRequest';
import { ResponseApi } from '../Models/Api/ResponseApi';
import { OrderByClientResponseApi } from '../Models/Api/OrdersByClientResponseApi';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  private http = inject(HttpClient);
  private api_url : string = appsettings.api_url;
  constructor() { }

  getOrdersByClient(client_id: number){
    return this.http.get<OrderByClientResponseApi>(`${this.api_url}/client_orders?ClientId=${client_id}`);
  }
  addOrder(params: CreateOrderWithProductsRequest){
    return this.http.post<ResponseApi>(`${this.api_url}/order`, params);
  }
}
