using System;

namespace GreenhouseUI {
  public interface IDataControlStrategy
  {
    T Set<T>(T value);
  }
}

