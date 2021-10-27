import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatSort } from '@angular/material/sort';

export interface PeriodicElement {
  name: number;
  position: number;
  value: number;
  symbol: string;
}

const ELEMENT_DATA: PeriodicElement[] = [
  {position: 1, name: 312837287301832, value: 71.00, symbol: '2 minutos atrás'},
  {position: 2, name: 317376218719327, value: 44.00, symbol: '5 minutos atrás'},
  {position: 3, name: 812363213792137, value: 16.99, symbol: '30 minutos atrás'},
  {position: 4, name: 917313523326331, value: 9.01, symbol: '1 hora atrás'},
  {position: 5, name: 123017236182163, value: 10.81, symbol: '1 hora e meia atrás'},
];

export interface TopClient{
  name: number;
  position: number;
}


const TOP_CLIENT: TopClient[] = [
  { name: 312837287301832, position: 9 },
  { name: 317376218719327, position: 6 },
  { name: 812363213792137, position: 4 },
  { name: 917313523326331, position: 2 },
  { name: 123017236182163, position: 1 },
];


export interface TopDeliver{
  name: number;
  position: number;
}

const TOP_DELIVER: TopDeliver[] = [
  { name: 312837287301832, position: 9 },
  { name: 317376218719327, position: 6 },
  { name: 812363213792137, position: 4 },
  { name: 917313523326331, position: 2 },
  { name: 123017236182163, position: 1 },
];


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  displayedColumns: string[] = ['position', 'name', 'value', 'symbol'];
  dataSource = ELEMENT_DATA;
  
  displayColumns: string[] = ['name', 'position',];
  topclientes = TOP_CLIENT;

  showColumns: string[] = ['name', 'position',];
  topdelivery = TOP_DELIVER;

  constructor() { }

  ngOnInit(): void {
  }

  

}
