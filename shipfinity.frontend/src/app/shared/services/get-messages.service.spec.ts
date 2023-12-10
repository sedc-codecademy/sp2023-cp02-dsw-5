import { TestBed } from '@angular/core/testing';

import { GetMessagesService } from './get-messages.service';

describe('GetMessagesService', () => {
  let service: GetMessagesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GetMessagesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
