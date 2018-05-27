using System;
using UnityEngine;

namespace GreenhouseUI {
  [RequireComponent(typeof(ViewModel.ModelReference))]
  public class FoundDevicesArea : MonoBehaviour
  {
    private ViewModel.IFoundDeviceModel m_data;

    [SerializeField] private Components.FoundDevicesList list;

    private void OnEnable()
    {
      m_data = this.GetComponent<ViewModel.ModelReference>().Model;
      Messenger.AddListener(UIEvent.FOUND_DEVICE_CHANGED, OnUpdateState);
    }

    private void OnDisable()
    {
      Messenger.RemoveListener(UIEvent.FOUND_DEVICE_CHANGED, OnUpdateState);
    }

    private void Start()
    {
      Messenger.Broadcast(UIEvent.START_SEARCH_DEVICES);
    }

    private void OnUpdateState()
    {
      list.UpdateList(m_data.FoundDevices);
    }
  }
}
