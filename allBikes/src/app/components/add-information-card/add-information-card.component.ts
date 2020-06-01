import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {BikeServiceService} from "../../Shared/Services/bike-service.service";
import {SpecificationModel} from "../../Shared/Models/Specification.model";
import {ActivatedRoute, Router} from "@angular/router";

@Component({
  selector: 'app-add-information-card',
  templateUrl: './add-information-card.component.html',
  styleUrls: ['./add-information-card.component.scss']
})
export class AddInformationCardComponent implements OnInit {
  form: FormGroup
  specifications: SpecificationModel[] = [];
  constructor(private fb: FormBuilder, private bikeService: BikeServiceService, private router: Router) {
    this.form = fb.group({
      Name: ["", [Validators.required]],
      Weight: ["", [Validators.required]],
      MaxSpeed: ["", [Validators.required]],
      Radius: ["", [Validators.required]],
      Height: ["", [Validators.required]],
      Text: ["", [Validators.required]],
      SpecificationId: ["", [Validators.required]],
      File: ["", [Validators.required]]
    })
  }

  ngOnInit(): void {
    this.bikeService.GetSpecifications().subscribe(data => {
      this.specifications = data;
    });
  }
  onPickImage(){
    const selector = document.getElementById("file_selector") as HTMLInputElement;
    selector.click();
    selector.onchange = (event:any) => {
      if (!event.target.files[0].type.indexOf("image"))
      {
        this.form.controls.File.setValue(event.target.files[0]);
      }
    }
  }
  onClick(){
    const dataForm = this.form.value;
    const data = new FormData();
    data.append("Name", dataForm.Name);
    data.append("Weight", dataForm.Weight);
    data.append("MaxSpeed", dataForm.MaxSpeed);
    data.append("CarCapacity", "123");
    data.append("Radius", dataForm.Radius);
    data.append("Height", dataForm.Height);
    data.append("Text", dataForm.Text);
    data.append("Weight", dataForm.Weight);
    data.append("SpecificationId", dataForm.SpecificationId);
    data.append("File", dataForm.File);

    this.bikeService.CreateBike(data).subscribe(_ => this.router.navigate(["/"]), _ => this.router.navigate(["/"]));

  }

}
