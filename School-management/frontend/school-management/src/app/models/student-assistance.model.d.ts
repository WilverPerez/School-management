import { AssistanceValue } from '../enums/assistance-value.enum';

export interface StudentAssistance {
    id: string;
    fullName: string;
    value: AssistanceValue;
    dateIssue: Date;
}