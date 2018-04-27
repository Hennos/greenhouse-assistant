using System;

namespace GreenhouseUI {
  public interface IConstructedModel<DataControlStrategy>
    where DataControlStrategy: IDataControlStrategy
  {}
}
