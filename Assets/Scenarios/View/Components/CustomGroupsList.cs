using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GreenhouseUI.Components {
  [RequireComponent(typeof(GroupsList))]
  [RequireComponent(typeof(CustomGroupProducer))]
  public class CustomGroupsList : MonoBehaviour
  {
    [SerializeField] private GameObject prefabCustomGroup;

    public GroupsList List
    {
      get {
        return this.GetComponent<GroupsList>();
      }
    }

    public void UpdateList(Dictionary<string, ViewModel.IGroup> groups)
    {
      List<string> oldGroupsNames = List.Groups;
      List<string> currentGroupsNames = groups.Keys.ToList();

      var updated = oldGroupsNames.Intersect(currentGroupsNames).ToList();
      updated.ForEach(
        id => {
          var gameObject = List.Get(id);
          this.GetComponent<CustomGroupProducer>().Produce(gameObject);
        }
      );

      var deleted = oldGroupsNames.Except(currentGroupsNames).ToList();
      deleted.ForEach(name => List.Remove(name));

      var added = currentGroupsNames.Except(oldGroupsNames).ToList();
      added.ForEach(
        name => {
          var gameObject = Instantiate(prefabCustomGroup) as GameObject;
          var data = groups[name];
          List.Add(gameObject, data);
          this.GetComponent<CustomGroupProducer>().Produce(gameObject);
        }
      );
    }
  }
}
