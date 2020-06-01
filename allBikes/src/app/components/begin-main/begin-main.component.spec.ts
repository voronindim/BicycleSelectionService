import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BeginMainComponent } from './begin-main.component';

describe('BeginMainComponent', () => {
  let component: BeginMainComponent;
  let fixture: ComponentFixture<BeginMainComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BeginMainComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BeginMainComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
