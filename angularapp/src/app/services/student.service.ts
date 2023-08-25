import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StudentService {
  private baseUrl = 'https://8080-dffafdafebcfacbdcbaeadfdfbaabfff.premiumproject.examly.io'; // Your backend URL

  constructor(private http: HttpClient) {}

  getStudents() {
    return this.http.get<any[]>(`${this.baseUrl}/getAllStudent`);
  }

  createStudent(student: any): Observable<any> {
    return this.http.post<any>(`${this.baseUrl}/addStudent`, student);
  }

  getStudentById(id: number): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}/getById/${id}`);
  }

  // Implement methods to add, update, and delete students
}
