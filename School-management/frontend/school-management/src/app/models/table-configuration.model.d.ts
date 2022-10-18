export interface TableConfiguration<T> {
    title: string,
    icon: string,
    headers: Array<RowConfiguration<T>>,
    data: Array<T>
}

export interface RowConfiguration<T> {
    label: string,
    value: (item: T) => string,
    primary?: boolean 
}

