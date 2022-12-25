import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
 
  loginFrm = this.fb.group({
    userName:['', Validators.required],
    password:['', Validators.required]
  });
  errorMessage:string='';

  constructor(private fb:FormBuilder, private authSerive:AuthService, private route:Router){
  }

  onSubmit(){
    this.loginFrm.markAllAsTouched();

    if(this.loginFrm.valid){
      this.authSerive.GetToken(this.loginFrm.value).subscribe((res) =>{
        localStorage.setItem('token', res.token);
        this.route.navigateByUrl('/employee');
      },
      (err)=>{
        this.errorMessage = err.error;
      })
    }
  }

}
