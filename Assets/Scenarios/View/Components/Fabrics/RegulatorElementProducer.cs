using System;
using UnityEngine;

namespace GreenhouseUI {
  [RequireComponent(typeof(ElementProducer))]
  public class RegulatorElementProducer : MonoBehaviour
  {
    public void Produce(GameObject element, IRegulatorElement data)
    {
      this.GetComponent<ElementProducer>().Produce(element, data);
    }
  }
}
