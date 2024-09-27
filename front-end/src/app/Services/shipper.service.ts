import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { appsettings } from '../Settings/appsettings';
import { ShippersResponseApi } from '../Models/Api/ShippersResponseApi';

@Injectable({
  providedIn: 'root'
})
export class ShipperService {
  private http = inject(HttpClient);
  private api_url:string = appsettings.api_url;
  constructor() { }

  getAll(){
    return this.http.get<ShippersResponseApi>(this.api_url + "/shippers");
  }
}
