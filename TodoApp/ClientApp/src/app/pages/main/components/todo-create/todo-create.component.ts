import { Component } from '@angular/core';
import { Modal } from 'src/app/components/modal/modal.component';

@Component({
  selector: 'app-todo-create',
  templateUrl: './todo-create.component.html',
  styleUrls: ['./todo-create.component.scss']
})
export class TodoCreateComponent implements Modal {
  constructor() { }

  OnSave() {
    console.log("save calisti")
    return "Test";
  }

}