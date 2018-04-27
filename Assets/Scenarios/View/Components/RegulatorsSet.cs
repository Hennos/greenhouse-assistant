using System;
using System.Linq;
using UnityEngine;

namespace GreenhouseUI {
  [RequireComponent(typeof(ViewModel.ModelReference))]
  public class RegulatorsSet : MonoBehaviour
  {
    private ViewModel.IMainDataModel m_data;

    [SerializeField] Components.RegulatorElementsList list;

    private void Awake()
    {
      m_data = this.GetComponent<ViewModel.ModelReference>().Model;
      Messenger.AddListener(UIEvent.APP_DATA_CHANGED, OnUpdateState);
    }

    private void OnDestroy()
    {
      Messenger.RemoveListener(UIEvent.APP_DATA_CHANGED, OnUpdateState);
    }

    private void Start()
    {
      list.UpdateList(m_data.Regulators);
    }

    private void OnUpdateState()
    {
      list.UpdateList(m_data.Regulators);
    }
  }
}
