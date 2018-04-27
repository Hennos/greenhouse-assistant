using System;
using System.Collections.Generic;

namespace GreenhouseUI.ViewModel {
  public interface IFoundDeviceModel
  {
    Dictionary<string, IFoundDevice> FoundDevices { get; }
  }
}
