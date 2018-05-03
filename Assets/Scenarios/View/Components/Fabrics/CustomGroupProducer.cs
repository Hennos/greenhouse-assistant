using System;
using UnityEngine;

namespace GreenhouseUI {
  [RequireComponent(typeof(GroupProducer))]
  public class CustomGroupProducer : MonoBehaviour
  {
    public void Produce(GameObject element, ViewModel.IGroup data)
    {
      this.GetComponent<GroupProducer>().Produce(element, data);
      element.GetComponent<Components.CustomGroup>().Render();
    }
  }
}
