using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GreenhouseUI.Components {
  [RequireComponent(typeof(GroupsList))]
  [RequireComponent(typeof(DeviceGroupProducer))]
  public class DeviceGroupsList : MonoBehaviour
  {
    [SerializeField] private GameObject prefabDevice;

    public GroupsList List
    {
      get {
        return this.GetComponent<GroupsList>();
      }
    }

    public void UpdateList(Dictionary<string, ViewModel.IDevice> devices)
    {
      List<string> oldDevicesNames = List.Groups;
      List<string> currentDevicesNames = devices.Keys.ToList();

      var updated = oldDevicesNames.Intersect(currentDevicesNames).ToList();
      updated.ForEach(
        id => {
          var gameObject = List.Get(id);
          this.GetComponent<DeviceGroupProducer>().Produce(gameObject);
        }
      );

      var deleted = oldDevicesNames.Except(currentDevicesNames).ToList();
      deleted.ForEach(name => List.Remove(name));

      var added = currentDevicesNames.Except(oldDevicesNames).ToList();
      added.ForEach(
        name => {
          var gameObject = Instantiate(prefabDevice) as GameObject;
          var data = devices[name];
          List.Add(gameObject, data);
          this.GetComponent<DeviceGroupProducer>().Produce(gameObject);
        }
      );
    }
  }
}
