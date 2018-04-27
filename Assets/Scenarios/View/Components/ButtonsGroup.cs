using System;
using UnityEngine;
using UnityEngine.Events;

namespace GreenhouseUI {
  [RequireComponent(typeof(ButtonProducer))]
  public class ButtonsGroup : MonoBehaviour
  {
    [SerializeField] private Transform rootTransform;
    [SerializeField] private GameObject prefabButton;

    public void AddButton(string title, UnityAction action)
    {
      var button = Instantiate(prefabButton) as GameObject;
      this.GetComponent<ButtonProducer>().Produce(button, title, action);
      button.transform.SetParent(rootTransform, false);
    }
  }
}
