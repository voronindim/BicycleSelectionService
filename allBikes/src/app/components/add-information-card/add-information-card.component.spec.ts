import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddInformationCardComponent } from './add-information-card.component';

describe('AddInformationCardComponent', () => {
  let component: AddInformationCardComponent;
  let fixture: ComponentFixture<AddInformationCardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddInformationCardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddInformationCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
