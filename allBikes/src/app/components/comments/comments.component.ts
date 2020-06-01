import {Component, Input, OnInit} from '@angular/core';
import {CommentModel} from "../../Shared/Models/comment.model";
import {CommentService} from "../../Shared/Services/comment.service";
import {ActivatedRoute} from "@angular/router";

@Component({
  selector: 'app-comments',
  templateUrl: './comments.component.html',
  styleUrls: ['./comments.component.scss']
})
export class CommentsComponent implements OnInit {
  @Input() bikeId: string;
  comments: CommentModel[] = [];
  constructor(private commentService: CommentService, private route: ActivatedRoute) {
    this.route.params.subscribe(params => {
      this.commentService.GetComments(params["id"]).subscribe(data => {
        this.comments = data;
      });
    })
  }

  onUpdate()
  {
    this.route.params.subscribe(params => {
      this.commentService.GetComments(params["id"]).subscribe(data => {
        this.comments = data;
      });
    })
  }

  ngOnInit(): void {
  }

}
