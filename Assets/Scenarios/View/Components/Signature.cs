using System;
using UnityEngine;
using UnityEngine.UI;

namespace GreenhouseUI.Components {
  public class Signature : MonoBehaviour
  {
    [SerializeField] private Text field;

    public string Title {
      get { return field.text; }
      set { field.text = value; }
    }
  }
}
