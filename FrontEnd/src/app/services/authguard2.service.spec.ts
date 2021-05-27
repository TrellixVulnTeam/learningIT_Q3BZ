/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { Authguard2Service } from './authguard2.service';

describe('Service: Authguard2', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [Authguard2Service]
    });
  });

  it('should ...', inject([Authguard2Service], (service: Authguard2Service) => {
    expect(service).toBeTruthy();
  }));
});
