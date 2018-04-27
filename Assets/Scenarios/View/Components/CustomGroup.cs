using System;
using System.Collections.Generic;
using UnityEngine;

namespace GreenhouseUI.Components {
  [RequireComponent(typeof(Group))]
  [RequireComponent(typeof(ViewModel.ModelReference))]
  public class CustomGroup : MonoBehaviour
  {
    private ViewModel.IMainDataModel m_data;

    [SerializeField] private Components.SensorElementsList sensors;
    [SerializeField] private Components.RegulatorElementsList regulators;

    private void OnEnable()
    {
      m_data = this.GetComponent<ViewModel.ModelReference>().Model;
    }

    public void Render()
    {
      var name = this.GetComponent<Group>().Name;
      var sensors = m_data.Groups[name].Sensors;
      UpdateSensors(sensors);
      var regulators = m_data.Groups[name].Regulators;
      UpdateRegulators(regulators);
    }

    private void UpdateSensors(List<string> sensorsNames)
    {
      var currentSensors = new Dictionary<string, ISensorElement>();
      sensorsNames.ForEach(id => currentSensors.Add(id, m_data.Sensors[id]));
      sensors.UpdateList(currentSensors);
    }
    private void UpdateRegulators(List<string> regulatorsNames)
    {
      var currentRegulators = new Dictionary<string, IRegulatorElement>();
      regulatorsNames.ForEach(id => currentRegulators.Add(id, m_data.Regulators[id]));
      regulators.UpdateList(currentRegulators);
    }
  }
}
