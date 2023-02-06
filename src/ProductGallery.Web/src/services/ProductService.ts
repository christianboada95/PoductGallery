import axios from "axios"
import { Product } from "../models/Product";
import { PagedResponse } from "../models/Response";


export const getProducts = (pageIndex: number, pageSize: number, findBy?: string, orderBy?: string) => {
    return axios.get<PagedResponse<Product[]>>("https://localhost:7298/products", {
        params: {
            pageIndex, pageSize, findBy, orderBy
        }
    });
}

export const createProduct = (product: Product) => {
    return axios.post<Product>("https://localhost:7298/products", product);
}

export const deleteProduct = (productId: string) => {
    return axios.delete("https://localhost:7298/products/" + productId);
}

export const updateProduct = (productId: string, product: Product) => {
    return axios.put<Product>("https://localhost:7298/products/" + productId, product);
}

