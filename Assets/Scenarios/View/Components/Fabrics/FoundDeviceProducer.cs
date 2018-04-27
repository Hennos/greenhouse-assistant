using System;
using UnityEngine;

namespace GreenhouseUI {
  public class FoundDeviceProducer : MonoBehaviour
  {
    public void Produce(GameObject element, IFoundDevice data)
    {
      element.name = "Device" + data.Name;
      element.GetComponent<Components.FoundDevice>().Render(data);
    }
  }
}
