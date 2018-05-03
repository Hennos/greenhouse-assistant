using System;
using System.Collections.Generic;
using UnityEngine;

namespace GreenhouseUI {
  [RequireComponent(typeof(ElementProducer))]
  public class SensorElementProducer : MonoBehaviour
  {
    public void Produce(GameObject element, ISensorElement data)
    {
      this.GetComponent<ElementProducer>().Produce(element, data);
      switch (data.Role) {
        case SensorElementRole.GROUND_TEMPERATURE:
          SetContent(
            element,
            "Ground temperature",
            "",
            data.Condition
          );
          break;
        case SensorElementRole.GROUND_GYDROMETERS:
          SetContent(
            element,
            "Ground gydrometers",
            "",
            data.Condition
          );
          break;
        case SensorElementRole.PRESSURE:
          SetContent(
            element,
            "Pressure",
            "",
            data.Condition
          );
          break;
        case SensorElementRole.HUMIDITY:
          SetContent(
            element,
            "Humidity",
            "",
            data.Condition
          );
          break;
        default: break;
      }
    }

    private void SetContent(GameObject element, string signature, string status, int? condition)
    {
      var sensorElement = element.GetComponent<Components.SensorElement>();
      sensorElement.Signature = signature;
      sensorElement.Condition = condition;
    }
  }
}
