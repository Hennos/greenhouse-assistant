using System;
using System.Collections.Generic;
using UnityEngine;

namespace GreenhouseUI {
  public class MainController : MonoBehaviour
  {
    private Model<ObservableDataStrategy> model;

    private void Awake()
    {
      model = Model.Create(ObservableDataStrategy.Instance);
    }

    private void OnEnable()
    {
      Messenger.AddListener(UIEvent.REQUEST_MODEL_DATA, OnRequestModelData);
      Messenger<List<IFoundDevice>>.AddListener(UIEvent.PUSH_FOUND_DEVICES, OnPushFoundDevices);
    }

    private void OnDisable()
    {
      Messenger.RemoveListener(UIEvent.REQUEST_MODEL_DATA, OnRequestModelData);
      Messenger<List<IFoundDevice>>.RemoveListener(UIEvent.PUSH_FOUND_DEVICES, OnPushFoundDevices);
    }

    private void OnRequestModelData()
    {
      RequestRemoteData();
    }

    private void OnPushFoundDevices(List<IFoundDevice> devices)
    {
      model.FoundDevices = devices;
    }

    private void RequestRemoteData()
    {
      #region prepare test sensors and regulators data
      var sensors = new List<ISensorElement>();
      sensors.Add(new SensorElement {
        Name = "Test1Sensor",
        DeviceId = "Device1",
        Role = SensorElementRole.PRESSURE,
        Active = true,
        Condition = 15,
      });
      sensors.Add(new SensorElement {
        Name = "Test2Sensor",
        DeviceId = "Device1",
        Role = SensorElementRole.GROUND_GYDROMETERS,
        Active = true,
        Condition = 20,
      });
      sensors.Add(new SensorElement {
        Name = "Test3Sensor",
        DeviceId = "Device2",
        Role = SensorElementRole.GROUND_GYDROMETERS,
        Active = true,
        Condition = 53,
      });
      sensors.Add(new SensorElement {
        Name = "Test4Sensor",
        DeviceId = "Device2",
        Role = SensorElementRole.HUMIDITY,
        Active = true,
        Condition = 14,
      });
      sensors.Add(new SensorElement {
        Name = "Test5Sensor",
        DeviceId = "Device2",
        Role = SensorElementRole.GROUND_TEMPERATURE,
        Active = true,
        Condition = 30,
      });
      var regulators = new List<IRegulatorElement> {
        {
          new RegulatorElement {
            Name = "Test1Regulator",
            DeviceId = "Device1",
            Role = RegulatorElementRole.Light,
            Active = true,
          }
        },
        {
          new RegulatorElement {
            Name = "Test2Regulator",
            DeviceId = "Device1",
            Role = RegulatorElementRole.Light,
            Active = true,
          }
        }
      };
      #endregion
      model.Sensors = sensors;
      model.Regulators = regulators;
    }

  }
}