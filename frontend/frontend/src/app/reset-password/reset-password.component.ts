import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UserService } from 'src/app/shared/services/user.service';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.css']
})
export class ResetPasswordComponent implements OnInit {
  
  model: any = {};

  constructor(private userService: UserService
    , public router: Router
    , private toastr: ToastrService) { }

  ngOnInit() {
   
  }

  forgetpassword() {
    this.userService.forgetPassword(this.model)
      .subscribe(
        () => {
          this.router.navigate(['/']);
          this.toastr.success('Uma mensagem foi mandada para o seu email!');
        },
        error => {
          this.toastr.error('Falha');
        }
      );
  }

}
