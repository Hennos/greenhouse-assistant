using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ButtonProducer : MonoBehaviour
{
  public void Produce(GameObject button, string title, UnityAction callback)
  {
    button.name = title + "Button";
    button.GetComponentInChildren<Text>().text = title;
    button.GetComponent<Button>().onClick.AddListener(callback);
  }
}
