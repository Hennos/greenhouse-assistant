using System;
using UnityEngine;

namespace GreenhouseUI {
  public enum ElementsAreaState
  {
    SENSORS,
    REGULATORS,
    CUSTOM_GROUPS,
    DEVICES
  }

  public class ElementsController : MonoBehaviour
  {
    private StateContainer<ElementsAreaState, FreePassConstraints<ElementsAreaState>> m_state = 
      StateContainer.Create(ElementsAreaState.SENSORS, new FreePassConstraints<ElementsAreaState>());
    public ElementsAreaState State {
      get {
        return m_state.CurrentState;
      }
      private set {
        m_state = m_state.UpdateState(value);
        NotifySectionChanged();
      }
    }

    private void Awake()
    {
      Messenger<ElementsAreaState>.AddListener(UIEvent.ELEMENTS_SET_PUSH_CHOOSED, OnGetChoosedSection);
    }

    private void OnDestroy()
    {
      Messenger<ElementsAreaState>.RemoveListener(UIEvent.ELEMENTS_SET_PUSH_CHOOSED, OnGetChoosedSection);
    }

    private void NotifySectionChanged() 
    {
      Messenger.Broadcast(UIEvent.ELEMENTS_SET_STATE_CHANGED);
    }

    private void OnGetChoosedSection(ElementsAreaState section) {
      State = section;
    }
  }
}
