import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FormToCommentComponent } from './form-to-comment.component';

describe('FormToCommentComponent', () => {
  let component: FormToCommentComponent;
  let fixture: ComponentFixture<FormToCommentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FormToCommentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FormToCommentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
