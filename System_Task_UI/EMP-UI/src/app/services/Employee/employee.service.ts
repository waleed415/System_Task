import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { EmployeeModel } from 'src/app/Entities/employee-model';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  baseUrl : string = 'https://localhost:7027/';
  resourceUrl : string = 'api/Employee';

  constructor(private httpService : HttpClient) { }

  public GetAll():Observable<Array<EmployeeModel>>{
    return this.httpService.get<Array<EmployeeModel>>(this.baseUrl+this.resourceUrl)
  }

  public GetById(id:string):Observable<EmployeeModel>{
      return this.httpService.get<EmployeeModel>(this.baseUrl+this.resourceUrl+"/"+id);
  }

  public Add(model: EmployeeModel):Observable<EmployeeModel>{
    return this.httpService.post<EmployeeModel>(this.baseUrl+this.resourceUrl, model);
  }

  public Update(model:EmployeeModel): Observable<EmployeeModel>{
    return this.httpService.put<EmployeeModel>(this.baseUrl+this.resourceUrl, model);
  }

  public Delete(id?:string){
    return this.httpService.delete(this.baseUrl+this.resourceUrl+'/'+id);
  }
}
