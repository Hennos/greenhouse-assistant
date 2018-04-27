using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GreenhouseUI.ViewModel {
  public class MainDataModel : MonoBehaviour, IMainDataModel
  {
    private string SET_SENSORS_DATA = DataEvent<List<ISensorElement>>.SET_MODEL_DATA;
    private string SET_REGULATORS_DATA = DataEvent<List<IRegulatorElement>>.SET_MODEL_DATA;
    private string SET_GROUPS_DATA = DataEvent<List<IGroup>>.SET_MODEL_DATA;

    private Dictionary<string, ISensorElement> m_sensors = new Dictionary<string, ISensorElement>();
    private Dictionary<string, IRegulatorElement> m_regulators = new Dictionary<string, IRegulatorElement>();
    private Dictionary<string, IGroup> m_groups = new Dictionary<string, IGroup>();

    public Dictionary<string, ISensorElement> Sensors
    {
      get {
        return m_sensors ?? new Dictionary<string, ISensorElement>();
      }
      private set {
        m_sensors = value;
        NotifyDataChanged();
      }
    }
    public Dictionary<string, IRegulatorElement> Regulators
    {
      get {
        return m_regulators ?? new Dictionary<string, IRegulatorElement>();
      }
      private set {
        m_regulators = value;
        NotifyDataChanged();
      }
    }
    public Dictionary<string, IDevice> Devices {
      get {
        var devices = new Dictionary<string, IDevice>();

        if (m_sensors == null && m_regulators == null) {
          return devices;
        }

        if (m_sensors != null) {
          m_sensors.Values.ToList().ForEach(
            sensor => {
              string deviceName = sensor.DeviceId;
              if (!devices.ContainsKey(deviceName)) {
                devices.Add(deviceName, new Device(deviceName));
              };
              devices[deviceName].Sensors.Add(sensor.GetId());
            }
          );
        }
        if (m_regulators != null) {
          m_regulators.Values.ToList().ForEach(
            regulator => {
              string deviceName = regulator.DeviceId;
              if (!devices.ContainsKey(deviceName)) {
                devices.Add(deviceName, new Device(deviceName));
              };
              devices[deviceName].Regulators.Add(regulator.GetId());
            }
          );
        }

        return devices;
      }
    }
    public Dictionary<string, IGroup> Groups {
      get {
        return m_groups;
      }
      private set {
        m_groups = value;
        NotifyDataChanged();
      }
    }

    private void OnEnable()
    {
      Messenger<List<ISensorElement>>.AddListener(SET_SENSORS_DATA, OnSetSensorsState);
      Messenger<List<IRegulatorElement>>.AddListener(SET_REGULATORS_DATA, OnSetRegulatorsState);
      Messenger<List<IGroup>>.AddListener(SET_GROUPS_DATA, OnSetGroupsState);
    }

    private void OnDisable()
    {
      Messenger<List<ISensorElement>>.RemoveListener(SET_SENSORS_DATA, OnSetSensorsState);
      Messenger<List<IRegulatorElement>>.RemoveListener(SET_REGULATORS_DATA, OnSetRegulatorsState);
      Messenger<List<IGroup>>.RemoveListener(SET_GROUPS_DATA, OnSetGroupsState);
    }

    private void OnSetSensorsState(List<ISensorElement> sensors) 
    {
      var configurated = new Dictionary<string, ISensorElement>();
      sensors.ForEach(
        sensor => {
          string id = sensor.GetId();
          configurated.Add(id, sensor);
        }
      );
      Sensors = configurated;
    }
    private void OnSetRegulatorsState(List<IRegulatorElement> regulators) 
    {
      var configurated = new Dictionary<string, IRegulatorElement>();
      regulators.ForEach(
        regulator => {
          string id = regulator.GetId();
          configurated.Add(id, regulator);
        }
      );
      Regulators = configurated;
    }
    private void OnSetGroupsState(List<IGroup> groups)
    {
      var configurated = new Dictionary<string, IGroup>();
      groups.ForEach(group => configurated.Add(group.Name, group));
      Groups = configurated;
    }

    private void NotifyDataChanged() 
    {
      Messenger.Broadcast(UIEvent.APP_DATA_CHANGED);
    }
  }
}
