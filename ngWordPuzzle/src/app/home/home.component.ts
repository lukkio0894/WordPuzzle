import { Component, OnInit } from '@angular/core';
import {WordPuzzleServiceService} from '../word-puzzle-service.service'

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

 matrix:string[][] = [];

  multi:Letter[][] = [];

  words:string[] = [];

  word:string  = "";

  lastSearch:any[] = [];

  constructor(private wordPuzzleService:WordPuzzleServiceService) { }

  ngOnInit() {
    this.wordPuzzleService.puzzle.subscribe(res=> this.FillMulti(res));
    this.wordPuzzleService.breakdown.subscribe(res=>this.searchResult(res));
    this.wordPuzzleService.words.subscribe(res=>this.words=res);
  }

  FillMulti(res){
    this.matrix=res;
    for(let i = 0;i<this.matrix.length;i++){
      let line = this.matrix[i];
      this.multi[i]=[];
      for(let j=0;j<line.length;j++){
        let newLetter = new Letter();
        newLetter.inPath=false;
        newLetter.Value= this.matrix[i][j];
this.multi[i][j]=newLetter;
      }
    }
  }
  
  Search(){
    this.ResetSearch();
    this.words.push(this.word);
   this.wordPuzzleService.SearchWord(this.word);
  }

  SearchWord(event){
    this.word="";
    this.ResetSearch();
      this.wordPuzzleService.SearchWord(event.target.innerText);
  }

  searchResult(res){
    if(res.Breakdown!= undefined){
      res.Breakdown.forEach(element => {
        this.multi[element.Row][element.Column].inPath=true;
      });
      this.lastSearch=res.Breakdown;
    }
  }

  ResetSearch(){
    this.lastSearch.forEach(element => {
      this.multi[element.Row][element.Column].inPath=false;
    });
    this.lastSearch=[];
  }

}

export class Letter {
  Value: string;
  inPath: boolean;
}