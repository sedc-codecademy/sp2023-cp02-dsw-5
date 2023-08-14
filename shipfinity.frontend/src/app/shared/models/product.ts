export default class Product {
    id: number;
    name: string;
    description: string;
    price: number;
    categoryId: number;
    discountPercentage: number;
    rating: number;
    imageUrl?: string;

    constructor(id?:number, name?: string, description?: string, price?: number, categoryId?: number, discount?: number, rating?: number, imageUrl?: string){
        this.id = !id? 0 : id;
        this.name = !name? "no name" : name;
        this.description = !description? "no description" : description;
        this.price = !price? 0 : price;
        this.categoryId = !categoryId? 0 : categoryId;
        this.discountPercentage = !discount? 0 : discount;
        this.rating = !rating? 0 : rating;
        this.imageUrl = !imageUrl? undefined : imageUrl;
    }
}