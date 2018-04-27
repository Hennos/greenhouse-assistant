using System;
using UnityEngine;

namespace GreenhouseUI {
  public class ElementProducer : MonoBehaviour
  {
    public void Produce(GameObject element, IDeviceElementData data)
    {
      element.name = data.Name + "Element";
      element.GetComponent<Element>().Render(data);
    }
  }
}
