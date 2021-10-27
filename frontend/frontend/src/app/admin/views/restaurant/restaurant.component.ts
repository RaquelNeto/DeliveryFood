import { Component, OnInit } from '@angular/core';
import {Restaurant} from 'src/app/shared/models/restaurant.model'
import { RestaurantService } from 'src/app/shared/services/restaurant.service';
import { UploadService } from 'src/app/shared/services/upload.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-restaurant',
  templateUrl: './restaurant.component.html',
  styleUrls: ['./restaurant.component.css']
})
export class RestaurantComponent implements OnInit {
  restaurant:Restaurant|undefined ;
  model:any = {};
 
  /**
     * Variable used to show or hide old password
     */
  oldHide = true;
 

   /**
    * Variable used to show or hide new and confirm password
    */
   hide = true;

  constructor(private uploadService: UploadService, private restaurantService: RestaurantService, private router: Router, private route: ActivatedRoute,private toastr: ToastrService) { }

  ngOnInit(): void {
    this.restaurantService.getRestaurantById(sessionStorage.getItem("restaurant")||"").subscribe((restaurant: Restaurant) => {
      this.restaurant = restaurant;

    });
    }


    atualizardados() {
      console.log(this.model);
      this.restaurantService.updateRestaurant(this.model)
      .subscribe(
        () => {
          this.router.navigate(['/admin/restaurant'], { relativeTo: this.route });
          this.toastr.success('Sucesso!');
        },
        error => {
          this.toastr.error('Falha');
        }
      );
   
    };
  


}
