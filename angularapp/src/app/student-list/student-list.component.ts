import { Component, OnInit } from '@angular/core';
import { StudentService } from '../services/student.service';
import { Student } from 'src/models/student.model';

@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html',
  styleUrls: ['./student-list.component.css']
})
export class StudentListComponent implements OnInit {
  students: Student[] = [
    // {
    //   id: 1,
    //   name: "Alice",
    //   department: 101,
    //   phonenumber: "123-456-7890"
    // },
    // {
    //   id: 2,
    //   name: "Bob",
    //   department: 102,
    //   phonenumber: "987-654-3210"
    // },
    // {
    //   id: 3,
    //   name: "Carol",
    //   department: 103,
    //   phonenumber: "555-555-5555"
    // }
  ];

  constructor(
    private studentService: StudentService
    ) {}

  ngOnInit() : void {
    this.studentService.getStudents().subscribe(data => {
      this.students = data;
    });
  }
}
