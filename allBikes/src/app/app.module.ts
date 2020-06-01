import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { BeginMainComponent } from './components/begin-main/begin-main.component';
import { SearchMainComponent } from './components/search-main/search-main.component';
import { AddInformationCardComponent } from './components/add-information-card/add-information-card.component';
import { DescriptionComponent } from './components/description/description.component';
import { CommentsComponent } from './components/comments/comments.component';
import { FormToCommentComponent } from './components/form-to-comment/form-to-comment.component';
import { InnerMainComponent } from './components/inner-main/inner-main.component';
import { CardComponent } from './components/card/card.component';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {HttpClientModule} from "@angular/common/http";
import {CommonModule} from "@angular/common";

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    BeginMainComponent,
    SearchMainComponent,
    AddInformationCardComponent,
    DescriptionComponent,
    CommentsComponent,
    FormToCommentComponent,
    InnerMainComponent,
    CardComponent,
  ],
    imports: [
      CommonModule,
        BrowserModule,
        AppRoutingModule,
        FormsModule,
        HttpClientModule,
      FormsModule,
      ReactiveFormsModule
    ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
