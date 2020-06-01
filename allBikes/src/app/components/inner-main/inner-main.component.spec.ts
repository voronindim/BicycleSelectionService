import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InnerMainComponent } from './inner-main.component';

describe('InnerMainComponent', () => {
  let component: InnerMainComponent;
  let fixture: ComponentFixture<InnerMainComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InnerMainComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InnerMainComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
