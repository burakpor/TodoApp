import { Component, Input } from '@angular/core';
import * as _ from 'lodash';
import { ModalModel } from 'src/app/components/modal/modal.component';
import { TaskStatus, Todo } from 'src/app/models/models';
import { ApplicationManager } from 'src/services/application-manager.service';
import { ModalService } from 'src/services/modal.service';
import { TodoService } from 'src/services/todo.service';
import { TodoCreateComponent } from '../todo-create/todo-create.component';

@Component({
  selector: 'app-todo-container',
  templateUrl: './todo-container.component.html',
  styleUrls: ['./todo-container.component.scss']
})
export class TodoContainerComponent {
  private _todoList: Todo[];
  @Input() get todoList(): Todo[] {
    return this._todoList;
  }
  set todoList(todoList: Todo[]) {
    this._todoList = todoList;
  }

  private _categoryId: number;
  @Input() get categoryId(): number {
    return this._categoryId;
  }
  set categoryId(todoList: number) {
    this._categoryId = todoList;
  }

  @Input() headerText: string;

  constructor(private todoService: TodoService, private applicationManager: ApplicationManager, private modalService: ModalService) { }

  updateStatusNext(todo: Todo) {
    if (todo.Status == TaskStatus.Todo)
      todo.Status = TaskStatus.InProgress;
    else
      todo.Status = TaskStatus.Completed;

    this.todoService.updateTodo(todo, this.categoryId).subscribe(res => {
      if (res.Result.IsSuccess) {
        this.todoService.getCategory(this.categoryId).subscribe((res) => {
          if (res.Result.IsSuccess)
            this.applicationManager.loadTodoSubject.next(res.CategoryObj);

        })
      }
    });
  }

  updateStatusPrevious(todo: Todo) {
    if (todo.Status != TaskStatus.Todo) {
      if (todo.Status == TaskStatus.InProgress)
        todo.Status = TaskStatus.Todo;
      else if (todo.Status == TaskStatus.Completed)
        todo.Status = TaskStatus.InProgress;

      this.todoService.updateTodo(todo, this.categoryId).subscribe(res => {
        if (res.Result.IsSuccess) {
          this.todoService.getCategory(this.categoryId).subscribe((res) => {
            if (res.Result.IsSuccess)
              this.applicationManager.loadTodoSubject.next(res.CategoryObj);

          })
        }
      });
    }
  }

  getTaskStatus() {
    if (this.headerText == "Todo")
      return TaskStatus.Todo;
    else if (this.headerText == "In Progress")
      return TaskStatus.InProgress;
    else
      return TaskStatus.Completed;
  }

  openModal() {
    const modal: ModalModel = {
      Component: TodoCreateComponent,
      CallBackFunction: (data) => {

        this.todoService.addTodo(data, this.categoryId,this.getTaskStatus()).subscribe(() => {
          this.todoService.getCategory(this.categoryId).subscribe((res) => {
            if (res.Result.IsSuccess)
              this.applicationManager.loadTodoSubject.next(res.CategoryObj);

          })
        });
      }
    }
    this.modalService.openModalSubject.next(modal);
  }

  openEditModal(todo: Todo){
    const modal: ModalModel = {
      Component: TodoCreateComponent,
      Data: todo.Name,
      CallBackFunction: (data) => {
        todo.Name = data;
        this.todoService.updateTodo(todo, this.categoryId).subscribe(() => {
          this.todoService.getCategory(this.categoryId).subscribe((res) => {
            if (res.Result.IsSuccess)
              this.applicationManager.loadTodoSubject.next(res.CategoryObj);

          })
        });
      }
    }
    this.modalService.openModalSubject.next(modal);
  }
}