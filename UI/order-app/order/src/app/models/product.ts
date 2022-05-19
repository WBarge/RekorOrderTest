export class Product {
  public productId!: string;
  public productName!: string;
  public pricePerItem!: number;
  public averageCustomerRating!: number;

  constructor (productId?: string,productName?: string, pricePerItem?: number, averageCustomerRating?: number)
  {
    this.productId = productId ?? "";
    this.productName = productName ?? "";
    this.pricePerItem = pricePerItem ?? 0;
    this.averageCustomerRating = averageCustomerRating ?? 0;
  }
}
