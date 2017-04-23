import { Component, OnInit, DoCheck, SimpleChanges, Input } from '@angular/core';
import { Http, URLSearchParams } from '@angular/http';

@Component({
    selector: 'skidata',
    templateUrl: './skidata.component.html',
    styleUrls: ['./skidata.component.css']
})
export class SkiDataComponent implements OnInit, DoCheck {
    @Input() userInput: UserInput;
    public answer: Answer;
    public skistyles = ['Klassisk', 'Freestyle'];
    oldLength; oldAge; oldSkistyle; isChanged;
    http;

    constructor(http: Http) {
        this.http = http;
    }

    ngOnInit() {
        this.userInput = new UserInput(180, 35, this.skistyles[0]);
        this.answer = { skiLengthMax: 0, skiLengthMin: 0, comment: "" };
    }

    ngDoCheck() {

        if (this.userInput.length > 0 && this.oldLength !== this.userInput.length) {
            this.oldLength = this.userInput.length;
            this.isChanged = true;
        }

        if (this.userInput.age > 0 && this.oldAge !== this.userInput.age) {            
            this.oldAge = this.userInput.age;
            this.isChanged = true;
        }


        if (this.oldSkistyle !== this.userInput.skistyle) {
            this.oldSkistyle = this.userInput.skistyle;
            this.isChanged = true;
        }

        if (this.isChanged) {
            var url = '/api/SkiData/GetSkiLength/' +
                this.userInput.length.toString() + '/' +
                this.userInput.age.toString() + '/' +
                this.userInput.skistyle.toString();

            this.http.get(url).subscribe(result => {
                this.answer = result.json() as Answer;
            });
            this.isChanged = false;
        }
    }

    updateSkistyle(selectValue) {
        this.userInput.skistyle = selectValue;
        this.ngDoCheck();
    }
}
interface Answer {
    skiLengthMax: number;
    skiLengthMin: number;
    comment: string;
}
export class UserInput {
    constructor(
        public length: number,
        public age: number,
        public skistyle: string
    ) { }
}