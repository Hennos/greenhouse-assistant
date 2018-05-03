using System;
using UnityEngine;

namespace GreenhouseUI {
  public class ElementsAreaButtons : MonoBehaviour
  {
    [SerializeField] private ButtonsList list;

    private void Start()
    {
      CreateButtons();
    }

    private void CreateButtons() {
      CreateButton("Sensors", ElementsAreaState.SENSORS);
      CreateButton("Regulators", ElementsAreaState.REGULATORS);
      CreateButton("Devices", ElementsAreaState.DEVICES);
      CreateButton("Groups", ElementsAreaState.CUSTOM_GROUPS);
    }

    private void CreateButton(string buttonTitle, ElementsAreaState areaType) {
      list.AddButton(buttonTitle, () => OnChooseArea(areaType));
    }

    private void OnChooseArea(ElementsAreaState areaType)
    {
      Messenger<ElementsAreaState>.Broadcast(UIEvent.ELEMENTS_SET_PUSH_CHOOSED, areaType);
    }
  }
}
