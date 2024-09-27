import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { appsettings } from '../Settings/appsettings';
import { ProductResponseApi } from '../Models/Api/ProductResponseApi';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private http = inject(HttpClient);
  private api_url:string = appsettings.api_url;
  constructor() { }

  getAll(){
    return this.http.get<ProductResponseApi>(this.api_url + "/products");
  }
}
