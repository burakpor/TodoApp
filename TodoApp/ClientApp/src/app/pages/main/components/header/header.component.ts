import { Component } from '@angular/core';
import { ApplicationManager } from 'src/services/application-manager.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent {
    searchString: string ="";

    constructor(private appManager: ApplicationManager){
    }

    search(){
        this.appManager.searchSubject.next(this.searchString);
    }

}