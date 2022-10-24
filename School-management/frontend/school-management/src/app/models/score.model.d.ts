export interface Score {
    id?: string;
    studentId: string;
    assignatureId: string;
    courseId: string;
    value: number;
    dateIssue: Date;
}