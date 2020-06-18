import { Component, OnInit } from '@angular/core';
import {BikeServiceService} from "../../Shared/Services/bike-service.service";
import {BikeModel} from "../../Shared/Models/bike.model";

@Component({
  selector: 'app-inner-main',
  templateUrl: './inner-main.component.html',
  styleUrls: ['./inner-main.component.scss']
})
export class InnerMainComponent implements OnInit {

  Bikes:BikeModel[] = [];
  constructor(private BikeService: BikeServiceService) {
    this.BikeService.bikes.subscribe(data => {
      this.Bikes = data;
    });
  }

  ngOnInit(): void {
  }

}
