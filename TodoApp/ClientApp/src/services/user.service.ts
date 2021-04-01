import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { HttpCallService } from "./http-call.service";
import * as _ from 'lodash';
export const USER_TOKEN: string = "USER_TOKEN";

@Injectable({
    providedIn: "root"
})
export class UserService {
    get userLogin() {
        return !_.isEmpty(localStorage.getItem(USER_TOKEN))
    }

    constructor(private httpCallService: HttpCallService) {

    }

    login(request: any): Observable<boolean> {
        return new Observable((subscriber) => {
            this.httpCallService.post<any>("User", "Login", request).subscribe((res) => {
                if (res.Result.IsSuccess) {
                    localStorage.setItem(USER_TOKEN, res.Token);
                    subscriber.next(res);
                }
                else {
                    subscriber.next(res);
                }
            });
        })
    }

    register(request: any): Observable<boolean> {
        return new Observable((subscriber) => {
            this.httpCallService.post<any>("User", "Register", request).subscribe((res) => {
                subscriber.next(res);
            });
        })
    }
}