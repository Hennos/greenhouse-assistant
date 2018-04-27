using System;

namespace GreenhouseUI {
  public static class Tuple {
    public static Tuple<T1, T2> Create<T1, T2>(T1 first, T2 second)
    {
      return new Tuple<T1, T2> {
        First = first,
        Second = second,
      };
    }
  }

  public struct Tuple<T1, T2>
  {
    public T1 First { get; set; }
    public T2 Second { get; set; }
  }
}

