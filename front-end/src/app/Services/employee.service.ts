import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { appsettings } from '../Settings/appsettings';
import { EmployeesResponseApi } from '../Models/Api/EmployeesResponseApi';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  private http = inject(HttpClient);
  private api_url:string = appsettings.api_url;
  constructor() { }

  getAll(){
    return this.http.get<EmployeesResponseApi>(this.api_url + "/employees");
  }
}
