export class GenericParser<T> {

  constructor(private readonly parserType: new () => T) { }

  public parseResponseInToArray(res: object[]): T[] {
      var returnValue: T[] = new Array<T>();
      if (res != null) {
          var length = res.length;
          for (var sub = 0; sub < length; sub++) {
              var obj = res[sub];
              var tempValPropertyModel: T = this.parseObjectIntoAttribute(obj);
              returnValue.push(tempValPropertyModel);
          }
      }
      return returnValue;
  }

  //common functionality of all parsing methods - will parse an object into an object of Type T so any methods on T can be used and an object is not just returned
  public parseObjectIntoAttribute(obj: any): T {
      var returnValue: T;
      if (obj != null) {
          returnValue = this.create();
          for (var prop in obj) {
              if (obj.hasOwnProperty(prop)) {
                  switch (prop) {
                  default:
                    //@ts-ignore
                      returnValue[prop] = obj[prop];
                  }
              }
          }
      }
      //@ts-ignore
      return returnValue;
  }
  protected create(): T {
      return new this.parserType();//create a new instance of T using the constructor function of T
  }
}
