import { Component, OnInit } from '@angular/core';
import { DepartmentDetail } from 'src/app/models/department-detail.model';
import { DepartmentService } from 'src/app/Shared/department.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-department',
  templateUrl: './department.component.html',
  styleUrls: ['./department.component.css']
})
export class DepartmentComponent implements OnInit {
  constructor(public service:DepartmentService) { }

  ngOnInit(): void {
    this.service.refreshlist();
  }
  onSubmit(form: NgForm) {
    if (this.service.formData.designationID == 0) {
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
    this.service.formData = new DepartmentDetail();
  }

  populateform(pd: DepartmentDetail) {
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
