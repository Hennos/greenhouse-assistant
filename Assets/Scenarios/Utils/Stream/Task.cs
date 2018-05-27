using System;

namespace GreenhouseUI.Utils.Stream {
  public interface ITask
  {
    void Execute();
  }

  public class Task : ITask
  {
    private Action _func;

    public static ITask Create(Action func)
    {
      return new Task(func);
    }

    public Task(Action func)
    {
      _func = func;
    }

    public void Execute()
    {
      _func();
    }
  }
}

