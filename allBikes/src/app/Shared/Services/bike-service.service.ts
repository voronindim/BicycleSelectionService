import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {BikeModel} from "../Models/bike.model";
import {API} from "../config";
import {BehaviorSubject} from "rxjs";
import {SpecificationModel} from "../Models/Specification.model";

@Injectable({
  providedIn: 'root'
})
export class BikeServiceService {

  bikes: BehaviorSubject<BikeModel[]>
  constructor(private http:HttpClient) {
    this.bikes = new BehaviorSubject<BikeModel[]>([]);
  }

  public GetBikesByFilter(name, weight, speed, capacity, radius, height)
  {
    this.http.get<BikeModel[]>(API + `api/Bike/get-bikes-by-filter?name=${name}&weight=${weight}&speed=${speed}&capacity=${capacity}&radius=${radius}&height=${height}`).subscribe(data => {
      this.bikes.next(data);
    }, error => {
      console.log(error);
    })
  }

  public GetBikeById(id)
  {
    return this.http.get<BikeModel>(API + `api/Bike/get-bike-by-id/${id}`)
  }

  public GetSpecifications()
  {
    return this.http.get<SpecificationModel[]>(API + `api/Specifications/get-specifications`)
  }

  public CreateBike(data)
  {
    return this.http.post(API + `api/Bike/create-bike`, data);
  }
}
