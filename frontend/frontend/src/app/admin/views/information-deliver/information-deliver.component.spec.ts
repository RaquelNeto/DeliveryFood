import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InformationDeliverComponent } from './information-deliver.component';

describe('InformationDeliverComponent', () => {
  let component: InformationDeliverComponent;
  let fixture: ComponentFixture<InformationDeliverComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InformationDeliverComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InformationDeliverComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
