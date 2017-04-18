import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';

import { UserInput } from "./UserInput"

@Component({
    selector: 'skidata',
    templateUrl: './skidata.component.html'
})
export class SkiDataComponent implements OnInit {
    public userInput: UserInput;
    public answer: Answer;

    constructor(http: Http) {
        http.get('/api/SkiData/GetSkiLength').subscribe(result => {
            this.answer = result.json() as Answer;
        });
    }

    ngOnInit() {
        this.userInput = new UserInput(42, 35, 'Classic');
        this.answer = { skiLength: 0, comment: "" };
    }
}
interface Answer {
    skiLength: number;
    comment: string;
}