import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

export interface TodoItem {
  id: string;
  title: string;
  isCompleted: boolean;
}

@Injectable({
  providedIn: 'root',
})
export class TodoService {
  private baseUrl = environment.baseUrl;

  constructor(private http: HttpClient) {}

  getTodos(): Observable<TodoItem[]> {
    return this.http.get<TodoItem[]>(this.baseUrl);
  }

  createTodo(title: string): Observable<string> {
    return this.http.post<string>(this.baseUrl, { title });
  }

  updateTodo(id: string, title: string): Observable<void> {
    return this.http.put<void>(`${this.baseUrl}/${id}`, { title });
  }

  deleteTodo(id: string): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
