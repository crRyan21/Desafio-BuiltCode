import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TableDoutoresComponent } from './table-doutores.component';

describe('TableDoutoresComponent', () => {
  let component: TableDoutoresComponent;
  let fixture: ComponentFixture<TableDoutoresComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TableDoutoresComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TableDoutoresComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
