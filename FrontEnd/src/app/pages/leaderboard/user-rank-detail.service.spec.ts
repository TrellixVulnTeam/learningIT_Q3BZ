import { TestBed } from '@angular/core/testing';

import { UserRankDetailService } from './user-rank-detail.service';

describe('UserRankDetailService', () => {
  let service: UserRankDetailService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UserRankDetailService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
