using System;
using System.Collections.Generic;
using UnityEngine;

namespace GreenhouseUI.ViewModel {
  public class Model : MonoBehaviour, IViewModel
  {
    [SerializeField] private MainDataModel m_dataModel;
    [SerializeField] private GlobalStateModel m_stateModel;
    [SerializeField] private FoundDeviceModel m_foundDevices;

    public Dictionary<string, ISensorElement> Sensors { 
      get { return m_dataModel.Sensors; }
    }
    public Dictionary<string, IRegulatorElement> Regulators { 
      get { return m_dataModel.Regulators; }
    }
    public Dictionary<string, IDevice> Devices { 
      get { return m_dataModel.Devices; }
    }
    public Dictionary<string, IGroup> Groups { 
      get { return m_dataModel.Groups; }
    }

    public GlobalState State { 
      get { return m_stateModel.State; }
    }

    public Dictionary<string, IFoundDevice> FoundDevices {
      get { return m_foundDevices.FoundDevices; }
    }
  }
}
