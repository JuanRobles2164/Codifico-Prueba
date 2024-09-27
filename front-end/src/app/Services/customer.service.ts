import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { appsettings } from '../Settings/appsettings';
import { SalesPredictionResponseApi } from '../Models/Api/SalesPredictionResponseApi';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  private http = inject(HttpClient);
  private api_url:string = appsettings.api_url;
  constructor() { }

  getSalesPredictions(){
    return this.http.get<SalesPredictionResponseApi>(this.api_url + "/sales_prediction")
  }
}
