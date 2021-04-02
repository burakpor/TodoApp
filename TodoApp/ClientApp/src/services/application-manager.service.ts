import { Injectable } from "@angular/core";
import { Subject } from "rxjs";
import { Category } from "src/app/models/models";



@Injectable({providedIn: 'root'})
export class ApplicationManager {
    searchSubject: Subject<string> = new Subject();
    loadTodoSubject: Subject<Category> = new Subject();
}