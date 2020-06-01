import { Component, OnInit } from '@angular/core';
import {BikeServiceService} from "../../Shared/Services/bike-service.service";

@Component({
  selector: 'app-search-main',
  templateUrl: './search-main.component.html',
  styleUrls: ['./search-main.component.scss']
})
export class SearchMainComponent implements OnInit {

  name: string = "";
  speed: string = "";
  weight: string = "";
  capacity: string = "";
  radius: string = "";
  height: string = "";

  constructor(private bikeService: BikeServiceService) { }

  onClick()
  {
    this.bikeService.GetBikesByFilter(this.name, this.weight, this.speed, this.capacity, this.radius, this.height)
  }

  ngOnInit(): void {
  }



}
