import { Component, OnInit } from '@angular/core';
import { EmployeeService } from 'src/app/Shared/employee.service';
import { NgForm } from '@angular/forms';
import { EmployeeDetail } from 'src/app/models/employee-detail.model';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {

  constructor(public service:EmployeeService) { }

  ngOnInit(): void {
    this.service.refreshlist();
  }
  onSubmit(form: NgForm) {
    if (this.service.formData.employeeId == 0) {
      this.insertrecord(form);
    }
    else {
      this.updaterecord(form);
    }
  }

  insertrecord(form: NgForm) {
    this.service.postPaymetndetail().subscribe(
      res => {

        this.service.refreshlist();
        alert("Submitted Succesfully");
        //this.tostr.success('Submitted successfully', 'Department Detail register');
        this.resetform(form);

      },
      err => { console.log(err) }
    );
  }

  updaterecord(form: NgForm) {
    this.service.putPaymetndetail().subscribe(
      res => {

        this.service.refreshlist();
        alert("Updated Successfully");
        //this.tostr.info('Updated successfully', 'Department Detail Register');
        this.resetform(form);

      },
      err => { console.log(err) }
    );

  }

  resetform(form: NgForm) {
    form.form.reset();
    this.service.formData = new EmployeeDetail();
  }

  populateform(pd: EmployeeDetail) {
    this.service.formData = Object.assign({}, pd);

  }
  onDelete(id: number) {
    if (confirm("Are sure you want to delete this record ?"))
      this.service.deletePaymetndetail(id).subscribe(
        res => {
          this.service.refreshlist();

          //this.tostr.error("Deleted Succussfully", "Department Detail Register")
        },
        err => { console.log(err) }
      )
  }


}
