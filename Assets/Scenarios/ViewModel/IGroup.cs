using System;
using System.Collections.Generic;

namespace GreenhouseUI.ViewModel {
  public interface IGroup
  {
    string Name { get; }
    List<string> Sensors { get; }
    List<string> Regulators { get; }
  }
}
