import { GenericParser } from "./generic-parser";
import { Order } from "../order";

export class OrderParser {
  private static baseParser: GenericParser<Order> = new GenericParser<Order>(Order);

  public static parseResponseInToArray(res: object[]): Order[] {
    var returnValue: Order[] = this.baseParser.parseResponseInToArray(res);
    return returnValue;
  }

  public  static parseObjectIntoOrder(obj: any): Order {
    var returnValue: Order = this.baseParser.parseObjectIntoAttribute(obj);
    return returnValue;
  }
}
