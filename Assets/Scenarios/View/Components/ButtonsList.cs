using System;
using UnityEngine;
using UnityEngine.Events;

namespace GreenhouseUI {
  [RequireComponent(typeof(UnityElementsList))]
  [RequireComponent(typeof(ButtonProducer))]
  public class ButtonsList : MonoBehaviour
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

    public void AddButton(string title, UnityAction action)
    {
      var button = Instantiate(prefabElement) as GameObject;
      this.GetComponent<ButtonProducer>().Produce(button, title, action);
      List.Add(title, button);
    }
  }
}
