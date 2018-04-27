using System;
using System.Collections.Generic;

namespace GreenhouseUI.ViewModel {
  public static class GlobalStateMap
  {
    private static Dictionary<Tuple<GlobalState, GlobalState>, bool> m_map;
    public static Dictionary<Tuple<GlobalState, GlobalState>, bool> Map {
      get {
        if (m_map != null) {
          return m_map;
        }

        m_map = new Dictionary<Tuple<GlobalState, GlobalState>, bool> {
          {Tuple.Create(GlobalState.AUTHORIZE, GlobalState.LOADING), true},
          {Tuple.Create(GlobalState.LOADING, GlobalState.CHOOSE_DEVICE), true},
          {Tuple.Create(GlobalState.LOADING, GlobalState.READY), true},
          {Tuple.Create(GlobalState.LOADING, GlobalState.AUTHORIZE), true},
          {Tuple.Create(GlobalState.CHOOSE_DEVICE, GlobalState.LOADING), true},
          {Tuple.Create(GlobalState.CHOOSE_DEVICE, GlobalState.READY), true},
          {Tuple.Create(GlobalState.READY, GlobalState.LOADING), true},
        };

        return m_map;
      }
    }
  }
}

