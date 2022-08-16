import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowDeleteUsersComponent } from './show-delete-users.component';

describe('ShowDeleteUsersComponent', () => {
  let component: ShowDeleteUsersComponent;
  let fixture: ComponentFixture<ShowDeleteUsersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowDeleteUsersComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShowDeleteUsersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
