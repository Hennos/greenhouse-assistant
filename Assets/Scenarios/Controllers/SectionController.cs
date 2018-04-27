using System;
using System.Collections.Generic;
using UnityEngine;

// TODO: Перенести состояние из контроллера в отдельный компонент, близкий к ViewModel
namespace GreenhouseUI {
  public enum SectionState {
    MAIN_SECTION,
    ANALYTICS_SECTION,
    SETTING_SECTION,
  }

  internal class PassNotSelfAssignment : IStateConstraints<SectionState>
  {
    public bool Check(SectionState current, SectionState updated)
    {
      return current != updated;
    }
  }

  public class SectionController : MonoBehaviour
  {
    private StateContainer<SectionState, PassNotSelfAssignment> m_state = 
      StateContainer.Create(SectionState.MAIN_SECTION, new PassNotSelfAssignment());
    public SectionState State {
      get {
        return m_state.CurrentState;
      }
      //TODO Очередное грязноватое решение. Хотелось бы, чтобы суть имело само наличие изменения состояния, 
      //     а не внешнии проверки, поскольку логика изменения состояния должна быть сокрыта от пользователей
      private set {
        if (m_state.CurrentState != value) {
          m_state = m_state.UpdateState(value);
          NotifySectionChanged();
        }
      }
    }

    private void Awake()
    {
      Messenger<SectionState>.AddListener(UIEvent.SECTION_PUSH_CHOOSED, OnGetChoosedSection);
    }

    private void OnDestroy()
    {
      Messenger<SectionState>.RemoveListener(UIEvent.SECTION_PUSH_CHOOSED, OnGetChoosedSection);
    }

    private void NotifySectionChanged() 
    {
      Messenger.Broadcast(UIEvent.SECTION_STATE_CHANGED);
    }

    private void OnGetChoosedSection(SectionState section) {
      State = section;
    }
  }
}
