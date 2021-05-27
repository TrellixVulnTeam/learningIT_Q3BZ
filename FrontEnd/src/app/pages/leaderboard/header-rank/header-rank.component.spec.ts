import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HeaderRankComponent } from './header-rank.component';

describe('HeaderRankComponent', () => {
  let component: HeaderRankComponent;
  let fixture: ComponentFixture<HeaderRankComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HeaderRankComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HeaderRankComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
