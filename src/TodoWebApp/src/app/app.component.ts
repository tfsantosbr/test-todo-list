import { Component } from '@angular/core';
import { TodoListComponent } from './components/todo-list/todo-list.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [TodoListComponent],
  template: `<app-todo-list></app-todo-list>`,
  styleUrls: ['./app.component.scss']
})
export class AppComponent {}
