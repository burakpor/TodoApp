import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { AddCategoryDto, AddCategoryResponse, AddTodoDto, GetCategoryDto, GetCategoryResponse, TaskPriority, TaskStatus, Todo, UpdateTodoDto } from "src/app/models/models";
import { HttpCallService } from "./http-call.service";

@Injectable({ providedIn: "root" })
export class TodoService {
    constructor(private http: HttpCallService) { }

    getCategories(): Observable<GetCategoryResponse> {
        return this.http.post<GetCategoryResponse>("Category", "GetCategory", {});
    }

    getCategory(categoryId: number): Observable<GetCategoryResponse> {
        const request: GetCategoryDto = {
            CategoryId: categoryId
        }
        return this.http.post<GetCategoryResponse>("Category", "GetCategory", request);
    }

    updateTodo(todo: Todo, categoryId: number){
        const request: UpdateTodoDto = {
            TaskId:todo.TaskId,
            Name: todo.Name,
            TaskPriority: todo.TaskPriority,
            TaskStatus: todo.Status,
            CategoryId: categoryId
        }
        return this.http.post<GetCategoryResponse>("Todo", "UpdateTodo", request);
    }

    addTodo(todoText: string,categoryId: number, taskStatus: TaskStatus){
        const request: AddTodoDto = {
            CategoryId:categoryId,
            Name: todoText,
            TaskPriority: TaskPriority.P1,
            TaskStatus: taskStatus
        }
        return this.http.post<GetCategoryResponse>("Todo", "AddTodo", request);
    }

    addCategory(categoryName: string){
        const request: AddCategoryDto = {
            Category: categoryName
        }
        return this.http.post<AddCategoryResponse>("Category", "AddCategory", request);
    }
}