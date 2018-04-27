using System;
using UnityEngine;
using UnityEngine.UI;

namespace GreenhouseUI.Components {
  public class Condition : MonoBehaviour
  {
    [SerializeField] private Text field;

    public string Value {
      get { return field.text; }
      set { field.text = value; }
    }
  }
}
