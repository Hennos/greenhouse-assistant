using System;
using UnityEngine;

namespace GreenhouseUI {
  [RequireComponent(typeof(GroupProducer))]
  public class DeviceGroupProducer : MonoBehaviour
  {
    public void Produce(GameObject element, ViewModel.IDevice data)
    {
      this.GetComponent<GroupProducer>().Produce(element, data);
      element.GetComponent<Components.DeviceGroup>().Render();
    }
  }
}
