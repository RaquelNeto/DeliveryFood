import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-situation',
  templateUrl: './situation.component.html',
  styleUrls: ['./situation.component.css']
})
export class SituationComponent implements OnInit {
   selected = 'option2';

  constructor() { }

  ngOnInit(): void {
  }

}
