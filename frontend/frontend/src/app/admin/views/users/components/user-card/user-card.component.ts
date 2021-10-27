import { Component, OnDestroy, OnInit } from '@angular/core';

@Component({
  selector: 'app-user-card',
  templateUrl: './user-card.component.html',
  styleUrls: ['./user-card.component.css']
})
export class UserCardComponent implements OnDestroy {
  
  constructor(
  ) {}

  /**
   * Executed method when view is destroyed
   */
  ngOnDestroy(): void {
  }


  
}

