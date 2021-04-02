import { Component, OnInit } from '@angular/core';
import * as _ from 'lodash';
import { Observable } from 'rxjs';
import {take} from 'rxjs/operators';
import { Category } from 'src/app/models/models';
import { ApplicationManager } from 'src/services/application-manager.service';
import { TodoService } from 'src/services/todo.service';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {
  categoryList: Category[] = [];
  showAddCategory: boolean = false;
  categoryName: string = "";
  constructor(private todoService: TodoService, private applicationManager: ApplicationManager) { }

  ngOnInit(): void {
    this.getCategories().pipe((take(1))).subscribe(() => {});
  }

  getCategories(): Observable<void> {
    this.categoryList = [];
    return new Observable((subscriber) => {
      this.todoService.getCategories().pipe(take(1)).subscribe((res) => {
        if (res.Result.IsSuccess) {
            this.categoryList = res.Categories
          this.applicationManager.loadTodoSubject.next(res.Categories[0]);
        }
        subscriber.next();
      })
    }) 
  }

  openCategory(category : Category){
    this.getCategories().pipe(take(1)).subscribe(() => {
      this.applicationManager.loadTodoSubject.next(category);
    })
  }

  saveCategory(){
    this.todoService.addCategory(this.categoryName).subscribe(() => {
      this.showAddCategory = false;
      this.categoryName = "";
      this.getCategories();
    });

  }

}