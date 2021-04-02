import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { GetCategoryDto, GetCategoryResponse, Todo, UpdateTodoDto } from "src/app/models/models";
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
}