using System;
using System.Collections.Generic;

namespace GreenhouseUI.Services.RequestDeviceData {
  public interface IRequestDeviceDataService {
    List<ISensorElement> Sensors { get; }
    List<IRegulatorElement> Regulators { get; }
  }

  public class RequestDeviceDataService
  {
  }
}
