using System;
using System.Collections.Generic;
using UnityEngine;

namespace GreenhouseUI {
  [RequireComponent(typeof(ButtonsGroup))]
  public class ElementsSetButtons : MonoBehaviour
  {
    private Dictionary<ElementsAreaState, string> m_sets = new Dictionary<ElementsAreaState, string> 
    {
      { ElementsAreaState.SENSORS, "Sensors" },
      { ElementsAreaState.REGULATORS, "Regulators" },
      { ElementsAreaState.DEVICES, "Devices" },
      { ElementsAreaState.CUSTOM_GROUPS, "Groups" },
    };

    private void Start()
    {
      CreateButton(ElementsAreaState.SENSORS);
      CreateButton(ElementsAreaState.REGULATORS);
      CreateButton(ElementsAreaState.DEVICES);
      CreateButton(ElementsAreaState.CUSTOM_GROUPS);
    }

    private void CreateButton(ElementsAreaState buttonType) {
      this.GetComponent<ButtonsGroup>().AddButton(m_sets[buttonType], () => OnChooseSection(buttonType));
    }

    private void OnChooseSection(ElementsAreaState choosed)
    {
      Messenger<ElementsAreaState>.Broadcast(UIEvent.ELEMENTS_SET_PUSH_CHOOSED, choosed);
    }
  }
}
