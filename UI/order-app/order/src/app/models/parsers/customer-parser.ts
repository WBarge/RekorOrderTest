import { GenericParser } from "./generic-parser";
import { Customer } from "../customer";

export class CustomerParser {
  private static baseParser: GenericParser<Customer> = new GenericParser<Customer>(Customer);

  public static parseResponseInToArray(res: object[]): Customer[] {
    var returnValue: Customer[] = this.baseParser.parseResponseInToArray(res);
    return returnValue;
  }

  public  static parseObjectIntoCustomer(obj: any): Customer {
    var returnValue: Customer = this.baseParser.parseObjectIntoAttribute(obj);
    return returnValue;
  }
}
