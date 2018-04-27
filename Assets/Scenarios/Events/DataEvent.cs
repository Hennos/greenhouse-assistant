using System;

namespace GreenhouseUI {
  public static class DataEvent<TData>
  {
    public static string SET_MODEL_DATA = "SET_MODEL_DATA<" + typeof(TData) + ">";
  }
}
