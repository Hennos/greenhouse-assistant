using System;
using System.Collections.Generic;

namespace GreenhouseUI.ViewModel {
  public class GlobalStateConstraints : IStateConstraints<GlobalState>
  {
    Dictionary<Tuple<GlobalState, GlobalState>, bool> m_map;

    public GlobalStateConstraints(Dictionary<Tuple<GlobalState, GlobalState>, bool> map) {
      m_map = map;
    }

    public bool Check(GlobalState current, GlobalState updated)
    {
      return m_map[Tuple.Create(current, updated)];
    }
  }
}
