using System;
using System.Collections.Generic;

namespace GreenhouseUI {
  public class DefaultDataStrategy : IDataControlStrategy
  {
    private static DefaultDataStrategy instance;

    private DefaultDataStrategy() {}

    public static DefaultDataStrategy Instance
    {
      get {
        if (instance == null) 
        {
          instance = new DefaultDataStrategy();
        }
        return instance;
      }
    }
      
    public T Set<T>(T value) {
      return value;
    }
  }
}
