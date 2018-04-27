using System;
using UnityEngine;

namespace GreenhouseUI {
  public class GroupProducer : MonoBehaviour
  {
    public void Produce(GameObject element, ViewModel.IGroup data)
    {
      element.name = data.Name + "Group";
      element.GetComponent<Components.Group>().Render(data);
    }
  }
}
