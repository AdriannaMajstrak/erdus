import { Component, OnInit } from '@angular/core';
import { NgwWowService } from 'ngx-wow';

@Component({ templateUrl: 'home.component.html', styleUrls: ['home.component.css'] })
export class HomeComponent implements OnInit {

    constructor(private wowService: NgwWowService) {

    }

    ngOnInit() {
        this.wowService.init();
    }
    
}
