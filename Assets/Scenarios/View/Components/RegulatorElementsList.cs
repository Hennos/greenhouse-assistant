using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GreenhouseUI.Components {
  [RequireComponent(typeof(ElementsList))]
  [RequireComponent(typeof(RegulatorElementProducer))]
  public class RegulatorElementsList : MonoBehaviour
  {
    [SerializeField] private GameObject prefabRegulatorElement;

    public ElementsList List { 
      get {
        return this.GetComponent<ElementsList>();
      }
    }

    public void UpdateList(Dictionary<string, IRegulatorElement> elements) 
    {
      List<string> oldElementsNames = List.Elements;
      List<string> currentElementsNames = elements.Keys.ToList();

      var updated = oldElementsNames.Intersect(currentElementsNames).ToList();
      updated.ForEach(
        id => {
          var gameObject = List.Get(id);
          this.GetComponent<RegulatorElementProducer>().Produce(gameObject, elements[id]);
        }
      );

      var deleted = oldElementsNames.Except(currentElementsNames).ToList();
      deleted.ForEach(id => List.Remove(id));

      var added = currentElementsNames.Except(oldElementsNames).ToList();
      added.ForEach(
        id => {
          var gameObject = Instantiate(prefabRegulatorElement) as GameObject;
          var data = elements[id];
          List.Add(gameObject, data);
          this.GetComponent<RegulatorElementProducer>().Produce(gameObject, data);
        }
      );
    }
  }
}

