using System;
using System.Collections.Generic;
using UnityEngine;

namespace GreenhouseUI.Utils.Stream {
  public interface ITransitionPool<TState>
  {
    ITransition<TState> GetTransition(TState state);
  }

  public static class TransitionPool
  {
    public static ITransitionPool<TState> Create<TState>(IDictionary<TState, ITransition<TState>> container)
    {
      return new TransitionPool<TState>(container);
    }
  }

  public class TransitionPool<TState> : ITransitionPool<TState>
  {
    private IDictionary<TState, ITransition<TState>> _container;

    public TransitionPool(IDictionary<TState, ITransition<TState>> container)
    {
      _container = container;
    }

    public ITransition<TState> GetTransition(TState state)
    {
      return _container[state];
    }
  }
}
