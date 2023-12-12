export default interface IOrder {
    email: string,
    address: {
        id?: number | null,
        addressLine: string,
        city: string,
        country: string,
        zipCode: string
    },
    orderDetails: IOrderDetails[],
    paymentInfo: {
        cardHolderName: string,
        CVV: number,
        cardNumber: string,
        expiryMonth: number,
        expiryYear: number
    }
}

export interface IOrderDetails {
    productId: number,
    quantity: number
}

export interface IOrderSellerList {
    id: number,
    orderDate: string,
    totalPrice: number,
    status: string,
    address: string
}

export interface IOrderSellerDetails {
    id: number,
    email: string,
    address: {
        id?: number | null,
        addressLine: string,
        city: string,
        country: string,
        zipCode: string
    }
    products: IOrderProductDetails[]
}

export interface IOrderProductDetails{
    name: string,
    price: number,
    discountPercentage: number
}