using System;
using System.Collections.Generic;
using UnityEngine;

namespace GreenhouseUI.Components {
  [RequireComponent(typeof(Group))]
  [RequireComponent(typeof(ViewModel.ModelReference))]
  public class DeviceGroup : MonoBehaviour
  {
    private ViewModel.IMainDataModel m_data;

    [SerializeField] private Components.SensorElementsList m_sensors;
    [SerializeField] private Components.RegulatorElementsList m_regulators;

    private void OnEnable()
    {
      m_data = this.GetComponent<ViewModel.ModelReference>().Model;
    }

    public void Render()
    {
      var name = this.GetComponent<Group>().Name;
      var sensors = m_data.Devices[name].Sensors;
      UpdateSensors(sensors);
      var regulators = m_data.Devices[name].Regulators;
      UpdateRegulators(regulators);
    }

    private void UpdateSensors(List<string> sensorsNames)
    {
      var sensors = new Dictionary<string, ISensorElement>();
      sensorsNames.ForEach(id => sensors.Add(id, m_data.Sensors[id]));
      m_sensors.UpdateList(sensors);
    }
    private void UpdateRegulators(List<string> regulatorsNames)
    {
      var regulators = new Dictionary<string, IRegulatorElement>();
      regulatorsNames.ForEach(id => regulators.Add(id, m_data.Regulators[id]));
      m_regulators.UpdateList(regulators);
    }
  }
}
