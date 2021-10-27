import { Component, OnDestroy, OnInit } from '@angular/core';

@Component({
  selector: 'app-user-row',
  templateUrl: './user-row.component.html',
  styleUrls: ['./user-row.component.css']
})
export class UserRowComponent implements OnDestroy {
 
  constructor(
  ) {}

  /**
   * Executed method when view is destroyed
   */
  ngOnDestroy(): void {
  }

  
}

