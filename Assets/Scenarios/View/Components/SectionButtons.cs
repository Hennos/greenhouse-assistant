using System;
using System.Collections.Generic;
using UnityEngine;

namespace GreenhouseUI {
  [RequireComponent(typeof(ButtonsGroup))]
  public class SectionButtons : MonoBehaviour
  {
    private Dictionary<SectionState, string> m_sections = new Dictionary<SectionState, string> 
    {
      { SectionState.MAIN_SECTION, "Controlls" },
      { SectionState.ANALYTICS_SECTION, "Analytics" },
      { SectionState.SETTING_SECTION, "Settings" },
    };

    private void Start()
    {
      CreateButton(SectionState.MAIN_SECTION);
      CreateButton(SectionState.ANALYTICS_SECTION);
      CreateButton(SectionState.SETTING_SECTION);
    }

    private void CreateButton(SectionState buttonType) {
      this.GetComponent<ButtonsGroup>().AddButton(m_sections[buttonType], () => OnChooseSection(buttonType));
    }

    private void OnChooseSection(SectionState section)
    {
      Messenger<SectionState>.Broadcast(UIEvent.SECTION_PUSH_CHOOSED, section);
    }
  }
}
