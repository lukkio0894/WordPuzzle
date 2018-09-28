import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs/internal/BehaviorSubject';
import { HttpClient } from '@angular/common/http'

import { environment } from './../environments/environment';
@Injectable({
  providedIn: 'root'
})
export class WordPuzzleServiceService {
  private puzzleM = new BehaviorSubject<any>([]);
  puzzle = this.puzzleM.asObservable();

  private breakdownM = new BehaviorSubject<any>([]);
  breakdown = this.breakdownM.asObservable();

  private wordsM = new BehaviorSubject([]);
  words = this.wordsM.asObservable();

  constructor(private http: HttpClient) {
    this.http.get(environment.APIEndpoint + "wordpuzzle/puzzle")
      .subscribe((data: [any]) => {
        this.puzzleM.next(data);
      });

    this.http.get(environment.APIEndpoint + "wordpuzzle/GetWords")
      .subscribe((data: [any]) => {
        this.wordsM.next(data);
      });
  }

  SearchWord(word) {
    let body = { "word": word, "puzzle": this.puzzleM.value };
    console.log(body);
    this.http.post(environment.APIEndpoint + "wordpuzzle/SearchWord", body)
      .subscribe((data: [any]) => {
        this.breakdownM.next(data);
      })
  }

}
