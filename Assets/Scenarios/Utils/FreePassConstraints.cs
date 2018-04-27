using System;

namespace GreenhouseUI {
  public class FreePassConstraints<TValue> : IStateConstraints<TValue>
  {
    public bool Check(TValue current, TValue updated)
    {
      return true;
    }
  }
}

