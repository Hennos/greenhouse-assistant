using System;
using System.Collections.Generic;
using UnityEngine;

namespace GreenhouseUI.ViewModel {
  public class FoundDeviceModel : MonoBehaviour, IFoundDeviceModel
  {
    private string SET_DATA = DataEvent<List<IFoundDevice>>.SET_MODEL_DATA;

    private Dictionary<string, IFoundDevice> m_foundDevices = new Dictionary<string, IFoundDevice>();

    public Dictionary<string, IFoundDevice> FoundDevices {
      get {
        return m_foundDevices;
      }
      private set {
        m_foundDevices = value;
        NotifyDataChanged();
      }
    }

    private void OnEnable()
    {
      Messenger<List<IFoundDevice>>.AddListener(SET_DATA, OnSetData);
    }

    private void OnDisable()
    {
      Messenger<List<IFoundDevice>>.RemoveListener(SET_DATA, OnSetData);
    }

    private void OnSetData(List<IFoundDevice> devices)
    {
      var configurated = new Dictionary<string, IFoundDevice>();
      devices.ForEach(device => configurated.Add(device.Name, device));
      FoundDevices = configurated;
    }

    private void NotifyDataChanged() 
    {
      Messenger.Broadcast(UIEvent.FOUND_DEVICE_CHANGED);
    }
  }
}

