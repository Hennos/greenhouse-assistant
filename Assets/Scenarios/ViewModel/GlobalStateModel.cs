using System;
using UnityEngine;

namespace GreenhouseUI.ViewModel {
  public class GlobalStateModel : MonoBehaviour, IGlobalStateModel
  {
    private StateContainer<GlobalState, GlobalStateConstraints> m_state = 
      StateContainer.Create(GlobalState.CHOOSE_DEVICE, new GlobalStateConstraints(GlobalStateMap.Map));

    public GlobalState State {
      get {
        return m_state.CurrentState;
      }
      private set {
        m_state = m_state.UpdateState(value);
        NotifyAppStateChanged();
      }
    }

    private void OnEnable()
    {
      Messenger<GlobalState>.AddListener(UIEvent.SET_APP_STATE, OnSetAppState);
    }

    private void OnDisable()
    {
      Messenger<GlobalState>.RemoveListener(UIEvent.SET_APP_STATE, OnSetAppState);
    }

    private void OnSetAppState(GlobalState state)
    {
      State = state;
    }
    private void NotifyAppStateChanged() 
    {
      Messenger.Broadcast(UIEvent.APP_STATE_CHANGED);
    }
  }
}
