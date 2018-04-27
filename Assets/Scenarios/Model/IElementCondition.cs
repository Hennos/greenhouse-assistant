using System;

namespace GreenhouseUI {
  public interface IElementCondition
  {
    bool? Active { get; }
    int? Condition { get; }
  }
}
