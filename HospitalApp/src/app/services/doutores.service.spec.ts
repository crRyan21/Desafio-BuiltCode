import { TestBed } from '@angular/core/testing';

import { DoutoresService } from './doutores.service';

describe('DoutoresService', () => {
  let service: DoutoresService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DoutoresService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
