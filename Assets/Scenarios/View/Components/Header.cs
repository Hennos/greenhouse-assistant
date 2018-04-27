using System;
using UnityEngine;
using UnityEngine.UI;

namespace GreenhouseUI {
  public class Header : MonoBehaviour
  {
    public string Title {
      get { return this.GetComponentInChildren<Text>().text; }
      set { this.GetComponentInChildren<Text>().text = value; }
    }
  }
}

