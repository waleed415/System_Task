import { Component } from '@angular/core';
import { EmployeeModel } from 'src/app/Entities/employee-model';
import { EmployeeService } from 'src/app/services/Employee/employee.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent {
  list: Array<EmployeeModel> = [];
  constructor(private employeeService:EmployeeService){
      this.getList();
  }

  getList(){
    this.employeeService.GetAll().subscribe((res) => {
      this.list = res;
    })
  }

  delete(id:any){
    this.employeeService.Delete(id).subscribe((res)=>{
      this.getList();
    })
  }
}
