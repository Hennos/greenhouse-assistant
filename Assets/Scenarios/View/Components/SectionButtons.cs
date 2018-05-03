using System;
using UnityEngine;

namespace GreenhouseUI {
  public class SectionButtons : MonoBehaviour
  {
    [SerializeField] private ButtonsList list;

    private void Start()
    {
      CreateButtons();
    }

    private void CreateButtons() {
      CreateButton("Controlls", SectionState.MAIN_SECTION);
      CreateButton("Analytics", SectionState.ANALYTICS_SECTION);
      CreateButton("Settings", SectionState.SETTING_SECTION);
    }

    private void CreateButton(string buttonTitle, SectionState sectionType) {
      list.AddButton(buttonTitle, () => OnChooseSection(sectionType));
    }

    private void OnChooseSection(SectionState sectionArea)
    {
      Messenger<SectionState>.Broadcast(UIEvent.SECTION_PUSH_CHOOSED, sectionArea);
    }
  }
}
