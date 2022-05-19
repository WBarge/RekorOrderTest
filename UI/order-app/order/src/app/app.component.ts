import { Component, OnInit } from '@angular/core';
import {MenuItem, MessageService, PrimeNGConfig} from 'primeng/api';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [MessageService]
})
export class AppComponent implements OnInit{
  title = 'Rekor Order Code Challenge';
  items: MenuItem[] = [];

  constructor(private messageService: MessageService,private primengConfig: PrimeNGConfig) {}

  ngOnInit() {
    this.items = [
      { label: 'Customers', routerLink: ['/customer']},
      { label: 'Products', routerLink: ['/product'] },
      { label: 'Orders', routerLink: ['/order'] }
    ];
  }
}
