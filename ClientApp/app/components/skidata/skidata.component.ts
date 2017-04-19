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
    oldLength; oldAge; oldSkistyle; isChanged; http;

    constructor(http: Http) {
        this.http = http;
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

        if (this.isNumeric(this.userInput.age) && this.oldAge !== this.userInput.age) {            
            this.oldAge = this.userInput.age;
            this.isChanged = true;
        }

        if (this.oldSkistyle !== this.userInput.skistyle) {
            this.oldSkistyle = this.userInput.skistyle;
            this.isChanged = true;
        }

        if (this.isChanged) {
            this.changeLog.push('Calling!');
            var url = '/api/SkiData/GetSkiLength/' +
                this.userInput.length.toString() + '/' +
                this.userInput.age.toString() + '/' +
                this.userInput.skistyle.toString();

            this.changeLog.push('url = '  + url);

            this.http.get(url).subscribe(result => {
                this.answer = result.json() as Answer;
            });
            this.isChanged = false;
        }
    }
    isNumeric(n) {
        return !isNaN(parseFloat(n)) && isFinite(n);
    }

    updateSkistyle(selectValue) {
        this.userInput.skistyle = selectValue;
        this.ngDoCheck();
    }
}
interface Answer {
    skiLength: number;
    comment: string;
}