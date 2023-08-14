import Product from "./product";

export default class ProductOrder {
    product: Product;
    quantity: number;

    constructor(product?: Product, quantity?: number){
        this.product = !product? new Product() : product;
        this.quantity = !quantity? 1 : quantity;
        if(quantity === undefined || quantity <= 0){
            this.quantity = 1;
        }
    }

    setQuantity(q:number){
        if(q > 0){
            this.quantity = q;
        }
    }
}