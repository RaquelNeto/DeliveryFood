import { Component, OnInit } from '@angular/core';
import {User} from 'src/app/shared/models/users.model'
import { UserService } from 'src/app/shared/services/user.service';
import { UploadService } from 'src/app/shared/services/upload.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';



@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
            
 user:User|undefined;
 model : any = {};


 


  /**
     * Variable used to show or hide old password
     */
    oldHide = true;

    /**
     * Variable used to show or hide new and confirm password
     */
    hide = true;

  constructor(private uploadService: UploadService, private userService: UserService, private router: Router, private route: ActivatedRoute,private toastr: ToastrService) {}

  ngOnInit(): void {
    
    this.userService.getUser(sessionStorage.getItem("id") || "").subscribe((user: User) => {
      this.user = user;

    });

        
   
  };

  atualizardados() {
 
    this.userService.updateUser(sessionStorage.getItem("id")||"",this.model)
    .subscribe(
      () => {
        this.router.navigate(['/admin/profile'], { relativeTo: this.route });
        this.toastr.success('Uma mensagem foi mandada para o seu email!');
      },
      error => {
        this.toastr.error('Falha');
      }
    );
 
  };












}
