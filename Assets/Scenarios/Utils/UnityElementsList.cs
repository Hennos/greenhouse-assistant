using System;
using System.Collections.Generic;
using UnityEngine;

namespace GreenhouseUI {
  public class UnityElementsList : MonoBehaviour, IUnityElementsList
  {
    private Dictionary<string, GameObject> m_elements = new Dictionary<string, GameObject>();

    [SerializeField] Transform rootTransform;

    public IEnumerable<string> Elements 
    {
      get { return m_elements.Keys; } 
    }

    public bool Contains(string id)
    {
      return m_elements.ContainsKey(id);
    }
    public GameObject Get(string id)
    {
      return m_elements[id];
    }

    public void Add(string id, GameObject element) 
    {
      element.transform.SetParent(rootTransform, false);
      m_elements.Add(id, element);
    }

    public void Remove(string id)
    {
      var element = m_elements[id];
      m_elements.Remove(id);
      Destroy(element);
    }
  }
}

