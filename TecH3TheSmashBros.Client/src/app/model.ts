export interface Product{
    id: number,
    title: string,
    storage: number,
    categoryId: number,
    price: number,
    images: string
}

export interface Category{
    id: number;
    title: string;
}
export interface CartItem{
    productid : number,
    navn: string,
    pris: number,
    // storage: number,
    antal: number,
}