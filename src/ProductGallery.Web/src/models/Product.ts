import { Url } from "url";
import { Category } from "./Category";

export interface Product{
    id?: string,
    name: string,
    description: string,
    category: Category,
    imageUrl: string,
    createdAt: Date,
    updatedAt?: Date,
}