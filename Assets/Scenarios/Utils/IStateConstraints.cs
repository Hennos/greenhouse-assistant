using System;

namespace GreenhouseUI {
  public interface IStateConstraints<TValue>
  {
    bool Check(TValue current, TValue updated);
  }
}
