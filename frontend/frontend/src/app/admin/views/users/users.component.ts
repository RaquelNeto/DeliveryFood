import { Component, OnDestroy, OnInit } from '@angular/core';
import {User} from 'src/app/shared/models/users.model'
import { UserService } from 'src/app/shared/services/user.service';
import { UploadService } from 'src/app/shared/services/upload.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit, OnDestroy {
 
  users:User[]|undefined;

  constructor(private uploadService: UploadService, private userService: UserService, private router: Router, private route: ActivatedRoute,private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.userService.getUsers().subscribe((user: User[]) => {
      this.users = user;
      console.log(this.users);
    });

        
   
  };
  

  
  ngOnDestroy(): void {
  }
}

