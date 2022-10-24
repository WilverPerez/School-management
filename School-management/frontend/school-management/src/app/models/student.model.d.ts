import { AssignatureList } from './assignature-list.model';
import { CourseList } from './course-list.model';
import { Parent } from './parent.model';

export interface Student {
    id: string;
    name: string;
    lastName: string;
    dateOfBorn: Date;
    parent: Parent;
    courses: Array<CourseList>;
    assignatures: Array<AssignatureList>;
    fullName: string;
}