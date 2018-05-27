using System;

namespace GreenhouseUI.Utils.Stream {
  public interface ITransition<TState>
  {
    TState State { get; }
    ITransition<TState> Resolve(ITransition<TState> previous);
  }

  public static class Transition
  {
    public static ITransition<TState> Create<TState>(TState state, ITask task, IResolver<TState> resolver)
    {
      return new Transition<TState>(state, task, resolver);
    }
  }

  public class Transition<TState> : ITransition<TState>
  {
    public TState State { get; private set; }

    protected ITask _task;
    protected IResolver<TState> _resolver;

    public Transition(TState state, ITask task, IResolver<TState> resolver)
    {
      State = state;
      _resolver = resolver;
      _task = task;
    }

    public ITransition<TState> Resolve(ITransition<TState> previous)
    {
      return _resolver.Examine(previous.State) ? Eval() : previous;
    }

    private ITransition<TState> Eval()
    {
      _task.Execute();

      return this;
    }
  }
}
