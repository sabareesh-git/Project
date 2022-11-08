import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { EmployeeDetail } from 'src/app/models/employee-detail.model';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private http: HttpClient) { }

  readonly baseurl = ' https://localhost:44304/api/employee';
  formData:EmployeeDetail = new EmployeeDetail();
  list: EmployeeDetail[] | undefined;

  refreshlist(){
    return this.http.get(this.baseurl).toPromise().then(res=> this.list = res as EmployeeDetail[])
  }

  postPaymetndetail(){
    return this.http.post(this.baseurl,this.formData)
  }

  putPaymetndetail(){
    return this.http.put(`${this.baseurl}/${this.formData.employeeId}`,this.formData)
  }

  deletePaymetndetail(id:number){
    return this.http.delete(`${this.baseurl}/${id}`)
  }

}
