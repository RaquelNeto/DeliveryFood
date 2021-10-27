import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UserService } from 'src/app/shared/services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  hide =true;
  titulo = 'Login';
  model: any = {};

  constructor(private userService: UserService
    , public router: Router
    , private toastr: ToastrService) { }

  ngOnInit() {
    localStorage.clear();
    sessionStorage.clear();

  }

  login() {
    this.userService.login(this.model)
      .subscribe(
        () => {
          this.router.navigate(['/admin']);
          this.toastr.success('Login efetuado com sucesso');
        },
        error => {
          this.toastr.error('Falha');
        }
      );
  }

}