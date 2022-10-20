import { CourseList } from './course-list.model';

export interface Assignature {
    id: string;
    name: string;
    courses: Array<CourseList>;
}
