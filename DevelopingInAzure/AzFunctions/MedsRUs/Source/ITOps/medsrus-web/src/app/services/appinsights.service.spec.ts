import { TestBed } from '@angular/core/testing';

import { AppInsightsService } from './appinsights.service';

describe('AppinsightsService', () => {
  let service: AppInsightsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AppInsightsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
