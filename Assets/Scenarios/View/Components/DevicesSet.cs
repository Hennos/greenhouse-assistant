﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GreenhouseUI {
  [RequireComponent(typeof(ViewModel.ModelReference))]
  public class DevicesSet : MonoBehaviour
  {
    private ViewModel.IMainDataModel m_data;

    [SerializeField] private Components.DeviceGroupsList list;

    private void OnEnable()
    {
      m_data = this.GetComponent<ViewModel.ModelReference>().Model;
      Messenger.AddListener(UIEvent.APP_DATA_CHANGED, OnUpdateState);
    }

    private void OnDisable()
    {
      Messenger.RemoveListener(UIEvent.APP_DATA_CHANGED, OnUpdateState);
    }

    private void Start()
    {
      list.UpdateList(m_data.Devices);
    }

    private void OnUpdateState()
    {
      list.UpdateList(m_data.Devices);
    }
  }
}
