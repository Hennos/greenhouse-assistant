using System;
using UnityEngine;

namespace GreenhouseUI {
  public class Content : MonoBehaviour
  {
    private GameObject m_rendered;

    [SerializeField] private Transform rootTransform;

    public void Render(GameObject prefab) 
    {
      if (m_rendered != null) { Destroy(m_rendered); }
      m_rendered = Instantiate(prefab) as GameObject;
      m_rendered.transform.SetParent(rootTransform, false);
      m_rendered.name = "Rendered" + prefab.name; 
    }
  }
}
