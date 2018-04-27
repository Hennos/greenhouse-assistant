using System;
using System.Collections.Generic;

namespace GreenhouseUI.ViewModel {
  public interface IMainDataModel
  {
    Dictionary<string, ISensorElement> Sensors { get; }
    Dictionary<string, IRegulatorElement> Regulators { get; }
    Dictionary<string, IDevice> Devices { get; }
    Dictionary<string, IGroup> Groups { get; }
  }
}

