using System;

namespace GreenhouseUI {
  public interface IElementRole<TRole>
  {
    TRole Role { get; }
  }
}
