using System;
using System.Collections.Generic;
using UnityEngine;

namespace GreenhouseUI.Components {
  [RequireComponent(typeof(Element))]
  public class SensorElement : MonoBehaviour
  {
    private int? m_condition;

    [SerializeField] private Status status;
    [SerializeField] private Signature signature;
    [SerializeField] private Condition condition;

    public string Signature {
      get { return signature.Title; }
      set { signature.Title = value; }
    }
    public int? Condition {
      get { return m_condition; }
      set { 
        m_condition = value;
        condition.Value = value.ToString();
      }
    }
  }
}
