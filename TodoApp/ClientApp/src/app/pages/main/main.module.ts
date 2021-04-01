import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MainComponent } from './main.component';
import { RouterModule, Routes } from '@angular/router';
import { HeaderComponent } from './components/header/header.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { ContainerComponent } from './components/container/container.component';
import { BodyComponent } from './components/body/body.component';
import { TodoContainerComponent } from './components/todo-container/todo-container.component';
const routes: Routes = [
  {
    path: '', component: ContainerComponent
  }
]
@NgModule({
  declarations: [
      MainComponent,
      SidebarComponent,
      HeaderComponent,
      ContainerComponent,
      BodyComponent,
      TodoContainerComponent
  ],
  imports: [
    RouterModule.forChild(routes),
    FormsModule,
    CommonModule
  ],
  providers: [],
  bootstrap: []
})
export class MainModule { }