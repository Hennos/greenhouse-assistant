using System;

namespace GreenhouseUI.Utils.Stream {
  public interface IResolver<TState>
  {
    bool Examine(TState previous);
  }

  public static class Resolver
  {
    public static IResolver<TState> Create<TState>(Func<TState, bool> func)
    {
      return new Resolver<TState>(func);
    }
  }

  public class Resolver<TState> : IResolver<TState>
  {
    private Func<TState, bool> _func;

    public Resolver(Func<TState, bool> func)
    {
      _func = func;
    }

    public bool Examine(TState previous)
    {
      return _func(previous);
    }
  }
}
