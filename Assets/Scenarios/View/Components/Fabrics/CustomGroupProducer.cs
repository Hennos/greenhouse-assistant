using System;
using UnityEngine;

namespace GreenhouseUI {
  public class CustomGroupProducer : MonoBehaviour
  {
    public void Produce(GameObject element)
    {
      element.GetComponent<Components.CustomGroup>().Render();
    }
  }
}
