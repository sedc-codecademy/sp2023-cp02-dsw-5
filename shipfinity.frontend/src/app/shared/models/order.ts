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