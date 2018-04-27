using System;
using System.Collections.Generic;

namespace GreenhouseUI {
  public sealed class ObservableDataStrategy : IDataControlStrategy
  {
    private static ObservableDataStrategy instance;

    private ObservableDataStrategy() {}

    public static ObservableDataStrategy Instance
    {
      get {
        if (instance == null) 
        {
          instance = new ObservableDataStrategy();
        }
        return instance;
      }
    }

    public T Set<T>(T value)
    {
      NotifyObservers(value);
      return value;
    }

    private void NotifyObservers<T>(T changes) {
      Messenger<T>.Broadcast(DataEvent<T>.SET_MODEL_DATA, changes);
    }
  }
}
