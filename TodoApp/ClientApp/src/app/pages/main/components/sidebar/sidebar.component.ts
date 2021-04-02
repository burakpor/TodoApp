import { Component, OnInit } from '@angular/core';
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
  constructor(private todoService: TodoService, private applicationManager: ApplicationManager) { }

  ngOnInit(): void {
    this.getCategories();
  }

  getCategories() {
    this.todoService.getCategories().subscribe((res) => {
      if (res.Result.IsSuccess) {
        this.categoryList = res.Categories
        this.applicationManager.loadTodoSubject.next(res.Categories[0]);
      }
    })
  }

  openCategory(category : Category){
    this.applicationManager.loadTodoSubject.next(category);
  }

}