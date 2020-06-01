import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {BikeModel} from "../../Shared/Models/bike.model";
import {BikeServiceService} from "../../Shared/Services/bike-service.service";
import {ImageApi} from "../../Shared/config";

@Component({
  selector: 'app-description',
  templateUrl: './description.component.html',
  styleUrls: ['./description.component.scss']
})
export class DescriptionComponent implements OnInit {

  image = ImageApi;
  bike: BikeModel;
  bikeId: string;

  constructor(private route:ActivatedRoute, private bikeService: BikeServiceService) {
    this.route.params.subscribe(params => {
      console.log(params["id"]);
      this.bikeId = params["id"];
      this.bikeService.GetBikeById(params["id"]).subscribe(bike => {
        this.bike = bike;
      })
    });
  }

  ngOnInit(): void {
  }

}
