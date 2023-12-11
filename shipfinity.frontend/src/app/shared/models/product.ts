export default class Product {
  id: number;
  name: string;
  description: string;
  price: number;
  categoryId: number;
  discountPercentage: number;
  rating: number;
  imageUrl?: string;

  constructor(
    id?: number,
    name?: string,
    description?: string,
    price?: number,
    categoryId?: number,
    discountPercentage?: number,
    rating?: number,
    imageUrl?: string
  ) {
    this.id = !id ? 0 : id;
    this.name = !name ? 'no name' : name;
    this.description = !description ? 'no description' : description;
    this.price = !price ? 0 : price;
    this.categoryId = !categoryId ? 0 : categoryId;
    this.discountPercentage = !discountPercentage ? 0 : discountPercentage;
    this.rating = !rating ? 0 : rating;
    this.imageUrl = !imageUrl ? undefined : imageUrl;
  }
}

export interface ProductEdit {
  id?: number | null;
  name: string;
  description: string;
  price: number;
  categoryId: number;
}

export interface ProductDetails {
  id: number;
  name: string;
  description: string;
  price: number;
  categoryId: number;
  imageUrl?: string;
  rating: number;
  discountPercentage: number;
}

export interface ReviewProductDto {
  comment: string;
  rating: number;
}
