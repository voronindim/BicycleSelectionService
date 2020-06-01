import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {CommentModel} from "../Models/comment.model";
import {API} from "../config";

@Injectable({
  providedIn: 'root'
})
export class CommentService {

  constructor(private http: HttpClient) {

  }

  // поулчаем comments по id
  GetComments(id){
    return this.http.get<CommentModel[]>(API + `api/Comment/get-comments-by-bikeId/${id}`)
  }

  // делаем запрос отправления name, text, bikeId
  CreateComment(name, text, bikeId){
    return this.http.post(API + `api/comment/create-comment`, {
      name, text, bikeId
    })
  }
}
