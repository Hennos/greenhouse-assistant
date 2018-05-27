using System;

namespace GreenhouseUI.Utils.Stream {
  public interface IStream<TState>
  {
    ITransition<TState> Current { get; }
    void Next(TState state);
  }

  public static class Stream
  {
    public static IStream<TState> Create<TState>(TState first, ITransitionPool<TState> pool)
    {
      return new Stream<TState>(first, pool);
    }
  }

  public class Stream<TState> : IStream<TState>
  {
    public ITransition<TState> Current { get; private set; }

    private ITransitionPool<TState> _pool;

    public Stream(TState first, ITransitionPool<TState> pool)
    {
      _pool = pool;
      Current = _pool.GetTransition(first);
    }

    public void Next(TState state)
    {
      Current = _pool.GetTransition(state).Resolve(Current);
    }
  }
}
