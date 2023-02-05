export interface Response<T> {
    message: string,
    data: T
}

export interface PagedResponse<T> extends Response<T>{
    pagenumber: number,
    pageSize: number,
    totalPage: number,
    totalRecords: number,
}