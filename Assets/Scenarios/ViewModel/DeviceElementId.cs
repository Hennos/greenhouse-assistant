using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GreenhouseUI {
  public static class DeviceElementId
  {
    public static string GetId<TElement>(this TElement element)
      where TElement: IDeviceElementData
    {
      return element.Name + ":" + element.DeviceId;
    }
  }
}
