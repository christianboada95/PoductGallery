import axios from "axios"
import { Product } from "../models/Product";
import { PagedResponse } from "../models/Response";


export const getProducts = (pageIndex: number, pageSize: number, findBy?: string, orderBy?: string) => {
    return axios.get<PagedResponse<Product[]>>("https://localhost:7298/products", {
        params: {
            pageIndex, pageSize, findBy, orderBy
        }});
}
