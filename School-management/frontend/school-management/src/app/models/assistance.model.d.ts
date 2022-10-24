import { AssistanceValue } from '../enums/assistance-value.enum';

export interface Assistance {
    id?: string;
    studentId: string;
    assignatureId: string;
    courseId: string;
    value: AssistanceValue;
    dateIssue: Date;
}