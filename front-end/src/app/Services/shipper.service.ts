import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { appsettings } from '../Settings/appsettings';
import { ResponseApi } from '../Models/Api/ResponseApi';

@Injectable({
  providedIn: 'root'
})
export class ShipperService {
  private http = inject(HttpClient);
  private api_url:string = appsettings.api_url;
  constructor() { }

  getAll(){
    return this.http.get<ResponseApi>(this.api_url + "/shippers");
  }
}
