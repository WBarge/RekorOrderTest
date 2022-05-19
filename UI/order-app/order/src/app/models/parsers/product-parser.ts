import { GenericParser } from "./generic-parser";
import { Product } from "../product";

export class ProductParser {
  private static baseParser: GenericParser<Product> = new GenericParser<Product>(Product);

  public static parseResponseInToArray(res: any): Product[] {
    var returnValue: Product[] = this.baseParser.parseResponseInToArray(res);
    return returnValue;
  }

  public  static parseObjectIntoProduct(obj: any): Product {
    var returnValue: Product = this.baseParser.parseObjectIntoAttribute(obj);
    return returnValue;
  }
}
