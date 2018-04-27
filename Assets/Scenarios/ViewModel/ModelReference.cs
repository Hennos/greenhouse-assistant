using System;
using UnityEngine;

using GreenhouseUI.ViewModel;

namespace GreenhouseUI.ViewModel {
  public class ModelReference : MonoBehaviour
  {
    private IViewModel m_model;

    public IViewModel Model {
      get {
        if (m_model == null) {
          m_model = GameObject.Find("ViewModel").GetComponent<ViewModel.Model>();
        }
        return m_model;
      }
    }
  }
}
