import { Course } from './course.model';

export interface Assignature {
    id: string;
    name: string;
    courses: Array<Course>;
}
