export interface CategoryModel {
    id: number;
    name: string;
    displayName: string;
}

export interface CategoryCreateModel {
    id?: number;
    name: string;
    displayName: string;
}