using System;
using System.Collections.Generic;
using UnityEngine;

// TODO: Сообщение об изменении отсылается до того, как данные будут установлены в модель
namespace GreenhouseUI {
  public static class Model
  {
    static public Model<DataControlStrategy> Create<DataControlStrategy>(DataControlStrategy manager)
      where DataControlStrategy: IDataControlStrategy
    {
      return new Model<DataControlStrategy>(manager);
    }
  }

  public class Model<DataControlStrategy> : IConstructedModel<DataControlStrategy>
    where DataControlStrategy: IDataControlStrategy
  {
    private DataControlStrategy m_manager;

    public Model(DataControlStrategy manager) {
      m_manager = manager;
    }

    private List<ISensorElement> m_sensors;
    public List<ISensorElement> Sensors {
      get {
        return m_sensors;
      }
      set {
        m_sensors = m_manager.Set(value);
      }
    }
    private List<IRegulatorElement> m_regulators;
    public List<IRegulatorElement> Regulators {
      get {
        return m_regulators;
      }
      set {
        m_regulators = m_manager.Set(value);
      }
    }
    private List<IFoundDevice> m_foundDevices;
    public List<IFoundDevice> FoundDevices {
      get {
        return m_foundDevices;
      }
      set {
        m_foundDevices = m_manager.Set(value);
      }
    }
  }
}
