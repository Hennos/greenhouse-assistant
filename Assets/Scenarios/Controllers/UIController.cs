using System;
using System.Collections.Generic;
using UnityEngine;

namespace GreenhouseUI {
  public class UIController : MonoBehaviour
  {
     private void Start()
    {
      SetApplicationData();
    }

    private void SetApplicationData()
    {
      #region prepare test saved groups data
      var sensorsList = new List<ISensorElement> {
        { 
          new SensorElement {
            Name = "Test1Sensor",
            DeviceId = "Device1",
            Role = SensorElementRole.PRESSURE,
            Active = true,
            Condition = 15,
          }
        },
        { 
          new SensorElement {
            Name = "Test2Sensor",
            DeviceId = "Device1",
            Role = SensorElementRole.GROUND_GYDROMETERS,
            Active = true,
            Condition = 20,
          }
        },
        {
          new SensorElement {
            Name = "Test3Sensor",
            DeviceId = "Device2",
            Role = SensorElementRole.GROUND_GYDROMETERS,
            Active = true,
            Condition = 53,
          }
        }
      };

      var group1 = new ViewModel.CustomGroup("Group1");
      group1.Sensors.Add(sensorsList[0].GetId());
      group1.Sensors.Add(sensorsList[1].GetId());
      group1.Sensors.Add(sensorsList[2].GetId());
      var group2 = new ViewModel.CustomGroup("Group2");
      group2.Sensors.Add(sensorsList[0].GetId());
      group2.Sensors.Add(sensorsList[1].GetId());

      var groups = new List<ViewModel.IGroup> {
        group1,
        group2,
      };
      #endregion

      SetGroups(groups);
    }

    private void SetGroups(List<ViewModel.IGroup> groups)
    {
      Messenger<List<ViewModel.IGroup>>.Broadcast(DataEvent<List<ViewModel.IGroup>>.SET_MODEL_DATA, groups);
    }
  }
}

