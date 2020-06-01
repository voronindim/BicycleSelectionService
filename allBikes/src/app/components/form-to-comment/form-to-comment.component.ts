import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {CommentService} from "../../Shared/Services/comment.service";
import {ActivatedRoute} from "@angular/router";

@Component({
  selector: 'app-form-to-comment',
  templateUrl: './form-to-comment.component.html',
  styleUrls: ['./form-to-comment.component.scss']
})
export class FormToCommentComponent implements OnInit {
  name: string = "";
  text: string = "";
  @Output() update: EventEmitter<any> = new EventEmitter<any>();

  constructor(private commentService: CommentService, private route: ActivatedRoute) {

  }
  onAdd(){
    let bikeId = 0;
    this.route.params.subscribe(params => bikeId = params["id"]);
    this.commentService.CreateComment(this.name, this.text, bikeId).subscribe(x => this.update.emit(null), err => this.update.emit(null))
  }

  ngOnInit(): void {
  }

}
