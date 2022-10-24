import { AssignatureList } from './assignature-list.model';
import { Schedule } from './schedule.model';
import { Student } from './student.model';

export interface Course {
    id: string;
    name: string,
    schedules: Array<Schedule>,
    students: Array<Student>,
    assignatures: Array<AssignatureList>
}
