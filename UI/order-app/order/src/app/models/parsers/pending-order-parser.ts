import { GenericParser } from "./generic-parser";
import { PendingOrder } from "../pending-order";


export class PendingOrderParser {
  private static baseParser: GenericParser<PendingOrder> = new GenericParser<PendingOrder>(PendingOrder);

  public static parseResponseInToArray(res: object[]): PendingOrder[] {
    var returnValue: PendingOrder[] = this.baseParser.parseResponseInToArray(res);
    return returnValue;
  }

  public  static parseObjectIntoPendingOrder(obj: any): PendingOrder {
    var returnValue: PendingOrder = this.baseParser.parseObjectIntoAttribute(obj);
    return returnValue;
  }
}
