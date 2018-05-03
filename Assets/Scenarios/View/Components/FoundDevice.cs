using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace GreenhouseUI.Components {
  [RequireComponent(typeof(Button))]
  public class FoundDevice : MonoBehaviour
  {
    private bool choosed = false;

    [SerializeField] private Text title;
    [SerializeField] private Image status;
    [SerializeField] private Button button;

    public bool Choosed { 
      get { return choosed; }
      private set {
        choosed = value;
        UpdateStatus(value);
      }
    }

    public void Render(IFoundDevice data)
    {
      title.text = data.Name;
      UpdateStatus(Choosed);
    }

    private void HandleClick()
    {
      Choosed = !Choosed;
    }

    private void UpdateStatus(bool value)
    {
      Color current = status.color;
      current.a = value ? 1f : 0f;
      status.color = current;
    }

    private void OnEnable()
    {
      button.onClick.AddListener(HandleClick);
    }

    private void OnDisable()
    {
      button.onClick.RemoveListener(HandleClick);
    }
  }
}
