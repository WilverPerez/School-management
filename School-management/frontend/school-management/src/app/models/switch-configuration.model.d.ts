export interface SwitchConfiguration<T> {
    title: string;
    data: Array<SwitchData<T>>
}

export interface SwitchData<T> {
    id: string;
    label: string;
    checked: boolean;
    toEntity: () => T;
}