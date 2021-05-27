import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UsersRankListComponent } from './users-rank-list.component';

describe('UsersRankListComponent', () => {
  let component: UsersRankListComponent;
  let fixture: ComponentFixture<UsersRankListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UsersRankListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UsersRankListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
