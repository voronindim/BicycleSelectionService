import {Component, Input, OnInit} from '@angular/core';
import {BikeModel} from "../../Shared/Models/bike.model";
import {ImageApi} from "../../Shared/config";

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.scss']
})
export class CardComponent implements OnInit {
  @Input("bike") bike: BikeModel;
  image = ImageApi;
  constructor() { }

  ngOnInit(): void {
  }

}
