using System;

namespace GreenhouseUI {
  public static class StateContainer
  {
    public static StateContainer<TValue, TConstraints> Create<TValue, TConstraints>(TValue initial, TConstraints constaints)
      where TConstraints: IStateConstraints<TValue>
    {
      return new StateContainer<TValue, TConstraints>(initial, constaints);
    }
  }

  public class StateContainer<TValue, TConstraints>
    where TConstraints: IStateConstraints<TValue>
  {
    private TConstraints m_constaints;

    public StateContainer(TValue initial, TConstraints constaints)
    {
      CurrentState = initial;
      m_constaints = constaints;
    }

    public TValue CurrentState { get; private set; }

    public StateContainer<TValue, TConstraints> UpdateState(TValue value)
    {
      return m_constaints.Check(CurrentState, value)
        ? StateContainer.Create(value, m_constaints)
        : this;
    }
  }
}
