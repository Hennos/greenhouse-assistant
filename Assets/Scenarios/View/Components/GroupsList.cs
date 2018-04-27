using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GreenhouseUI {
  [RequireComponent(typeof(GroupProducer))]
  public class GroupsList : MonoBehaviour
  {
    private Dictionary<string, GameObject> m_groups = new Dictionary<string, GameObject>();

    [SerializeField] Transform rootTransform;

    public List<string> Groups
    {
      get { return m_groups.Keys.ToList(); }
    }

    public bool Contains(string name)
    {
      return m_groups.ContainsKey(name);
    }

    public void Add<TGroupData>(GameObject element, TGroupData data)
      where TGroupData: ViewModel.IGroup
    {
      element.transform.SetParent(rootTransform, false);
      this.GetComponent<GroupProducer>().Produce(element, data);
      m_groups.Add(data.Name, element);
    }

    public GameObject Get(string name)
    {
      return m_groups[name];
    }

    public void Remove(string name)
    {
      var element = m_groups[name];
      m_groups.Remove(name);
      Destroy(element);
    }
  }
}

