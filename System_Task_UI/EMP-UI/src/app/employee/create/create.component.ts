import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { EmployeeService } from 'src/app/services/Employee/employee.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent {

  empform = this.fb.group({
    id: [''],
    name: ['', Validators.required],
    designation: ['', Validators.required]
  })
  title: string = 'Create';
  constructor(private employeeService: EmployeeService, private fb: FormBuilder, private route: Router, private activeRoute: ActivatedRoute) {

  }

  ngOnInit() {
    this.activeRoute.params.subscribe(params => {
      let id = params['id'];
      if (id) {
        this.title = 'Edit'
        this.employeeService.GetById(id).subscribe((res) => {
          this.empform.patchValue({ id: res.id, name: res.name, designation: res.designation });
        })

      }
    });
  }

  submit() {
    this.empform.markAllAsTouched();
    if (this.empform.valid) {
      if (this.empform.controls['id'].value) {
        this.employeeService.Update(this.empform.value).subscribe((res) => {
          this.route.navigateByUrl('/employee/list');
        })
      }
      else {
        this.employeeService.Add(this.empform.value).subscribe((res) => {
          this.route.navigateByUrl('/employee/list');
        })
      }
    }
  }
}
