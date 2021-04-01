import { Injectable } from "@angular/core";
import { Subject } from "rxjs";



@Injectable({providedIn: 'root'})
export class ApplicationManager {
    searchSubject: Subject<string> = new Subject();
}