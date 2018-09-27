import { TestBed } from '@angular/core/testing';

import { WordPuzzleServiceService } from './word-puzzle-service.service';

describe('WordPuzzleServiceService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: WordPuzzleServiceService = TestBed.get(WordPuzzleServiceService);
    expect(service).toBeTruthy();
  });
});
