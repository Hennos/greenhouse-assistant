using System;
using UnityEngine;

namespace GreenhouseUI {
  public class DeviceGroupProducer : MonoBehaviour
  {
    public void Produce(GameObject element)
    {
      element.GetComponent<Components.DeviceGroup>().Render();
    }
  }
}
