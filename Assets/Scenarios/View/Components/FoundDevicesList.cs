using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GreenhouseUI.Components {
  [RequireComponent(typeof(UnityElementsList))]
  [RequireComponent(typeof(FoundDeviceProducer))]
  public class FoundDevicesList : MonoBehaviour
  {
    private IUnityElementsList m_list;

    [SerializeField] private GameObject prefabElement;

    public IUnityElementsList List {
      get {
        if (m_list == null) {
          m_list = this.GetComponent<UnityElementsList>();
        }
        return m_list;
      }
    }

    public void UpdateList(Dictionary<string, IFoundDevice> elements)
    {
      IEnumerable<string> oldElementsNames = List.Elements;
      IEnumerable<string> currentElementsNames = elements.Keys;

      var added = currentElementsNames.Except(oldElementsNames);
      foreach (string id in added) {
        var gameObject = Instantiate(prefabElement) as GameObject;
        var data = elements[id];
        List.Add(id, gameObject);
        this.GetComponent<FoundDeviceProducer>().Produce(gameObject, data);
      }

      var updated = oldElementsNames.Intersect(currentElementsNames);
      foreach (string id in updated) {
        var gameObject = List.Get(id);
        this.GetComponent<FoundDeviceProducer>().Produce(gameObject, elements[id]);
      }

      var deleted = oldElementsNames.Except(currentElementsNames);
      foreach (string id in deleted) {
        List.Remove(id);
      }
    }
  }
}
