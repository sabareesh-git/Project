import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { DepartmentDetail } from '../models/department-detail.model';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {
  constructor(private http: HttpClient) { }

  readonly baseurl = 'https://localhost:44304/api/Designation';
  formData:DepartmentDetail = new DepartmentDetail();
  list: DepartmentDetail[] | undefined;

  refreshlist(){
    return this.http.get(this.baseurl).toPromise().then(res=> this.list = res as DepartmentDetail[])
  }

  postPaymetndetail(){
    return this.http.post(this.baseurl,this.formData)
  }

  putPaymetndetail(){
    return this.http.put(`${this.baseurl}/${this.formData.designationID}`,this.formData)
  }

  deletePaymetndetail(id:number){
    return this.http.delete(`${this.baseurl}/${id}`)
  }

}
