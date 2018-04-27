using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

//TODO Решение для схлопывания компонента по-прежнему остаётся несколько грязноватым
//TODO Перенести на нативную реализацию List
namespace GreenhouseUI {
  [RequireComponent(typeof(ElementProducer))]
  public class ElementsList : MonoBehaviour
  {
    private Dictionary<string, GameObject> m_elements = new Dictionary<string, GameObject>();

    [SerializeField] private Transform rootTransform;

    private void Start()
    {
      if (Elements.Count == 0) {
        this.gameObject.SetActive(false);
      }
    }

    public List<string> Elements
    {
      get { return m_elements.Keys.ToList(); }
    }

    public bool Contains(string id)
    {
      return m_elements.ContainsKey(id);
    }

    public void Add<TElementData>(GameObject element, TElementData data)
      where TElementData: IDeviceElementData
    {
      element.transform.SetParent(rootTransform, false);
      this.GetComponent<ElementProducer>().Produce(element, data);
      m_elements.Add(data.GetId(), element);

      if (Elements.Count > 0 && this.gameObject.activeSelf != true) {
        this.gameObject.SetActive(true);
      }
    }

    public GameObject Get(string id)
    {
      return m_elements[id];
    }

    public void Remove(string id)
    {
      var element = m_elements[id];
      m_elements.Remove(id);
      Destroy(element);

      if (Elements.Count == 0) {
        this.gameObject.SetActive(false);
      }
    }
  }
}
