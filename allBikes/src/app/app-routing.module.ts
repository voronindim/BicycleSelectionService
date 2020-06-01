import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {BeginMainComponent} from "./components/begin-main/begin-main.component";
import {SearchMainComponent} from "./components/search-main/search-main.component";
import {AddInformationCardComponent} from "./components/add-information-card/add-information-card.component";
import {DescriptionComponent} from "./components/description/description.component";
import {InnerMainComponent} from "./components/inner-main/inner-main.component";


const routes: Routes = [{path: '', component: BeginMainComponent},
  {path: 'finder', component: SearchMainComponent},
  {path: 'add-info', component: AddInformationCardComponent},
  {path: 'description/:id', component: DescriptionComponent},
  {path: 'listCard', component: InnerMainComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {
    useHash: true
  })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
