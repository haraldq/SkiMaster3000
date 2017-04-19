import { Component, OnInit, DoCheck, SimpleChanges, Input } from '@angular/core';
import { Http, URLSearchParams } from '@angular/http';

import { UserInput } from "./UserInput"

@Component({
    selector: 'skidata',
    templateUrl: './skidata.component.html'
})
export class SkiDataComponent implements OnInit, DoCheck {
    @Input() userInput: UserInput;
    public answer: Answer;
    public skistyles = ['Klassisk', 'Freestyle'];
    changeLog: string[] = [];
    oldLength; isChanged;

    http;

    constructor(http: Http) {
        this.http = http;
        //http.get('/api/SkiData/GetSkiLength').subscribe(result => {
        //    this.answer = result.json() as Answer;
        //});
    }

    ngOnInit() {
        this.userInput = new UserInput(42, 35, this.skistyles[0]);
        this.answer = { skiLength: 0, comment: "" };
    }

    ngDoCheck() {

        if (this.isNumeric(this.userInput.length) && this.oldLength !== this.userInput.length) {
            this.changeLog.push(this.userInput.length + '!');
            this.oldLength = this.userInput.length;
            this.isChanged = true;
        }

        if (this.isChanged) {
            this.changeLog.push('Calling!');
            this.http.get('/api/SkiData/GetSkiLength/' + this.userInput.length.toString()).subscribe(result => {
                this.answer = result.json() as Answer;
            });
            this.isChanged = false;
        }
    }
    isNumeric(n) {
        return !isNaN(parseFloat(n)) && isFinite(n);
    }
}
interface Answer {
    skiLength: number;
    comment: string;
}