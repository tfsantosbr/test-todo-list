import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { TodoService, TodoItem } from '../../services/todo.service';

@Component({
  selector: 'app-todo-list',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './todo-list.component.html',
  styleUrls: ['./todo-list.component.scss'],
})
export class TodoListComponent implements OnInit {
  todos: TodoItem[] = [];
  newTodoTitle: string = '';

  constructor(private todoService: TodoService) {}

  ngOnInit(): void {
    this.getTodos();
  }

  getTodos(): void {
    this.todoService.getTodos().subscribe((todos) => {
      this.todos = todos;
    });
  }

  createTodo(): void {
    if (this.newTodoTitle.trim()) {
      if (this.newTodoTitle.length > 200) {
        alert('O título da tarefa deve ser menor que 200');
        return;
      }

      this.todoService.createTodo(this.newTodoTitle).subscribe(() => {
        this.getTodos();
        this.newTodoTitle = '';
      });
    }
  }

  updateTodo(todo: TodoItem): void {
    const newTitle = prompt('Atualizar o título do TODO', todo.title);
    if (newTitle && newTitle.trim()) {
      if (newTitle.length > 200) {
        alert('O título da tarefa deve ser menor que 200');
        return;
      }
      this.todoService.updateTodo(todo.id, newTitle.trim()).subscribe(() => {
        this.getTodos();
      });
    }
  }

  deleteTodo(id: string): void {
    if (confirm('Tem certeza que deseja deletar este TODO?')) {
      this.todoService.deleteTodo(id).subscribe(() => {
        this.getTodos();
      });
    }
  }
}
