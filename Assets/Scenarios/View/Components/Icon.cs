using System;
using UnityEngine;
using UnityEngine.UI;

namespace GreenhouseUI.Components {
  [RequireComponent(typeof(Image))]
  public class Icon : MonoBehaviour
  {
    private string m_source = "";

    [SerializeField] private Image image;
    [SerializeField] private Sprite notAvailableIcon;

    public string Source {
      get {
        return m_source;
      }
      set {
        m_source = value;
        SetIcon(value);
      }
    }

    private void Awake()
    {
      image.sprite = notAvailableIcon;
    }

    private void SetIcon(string source)
    {
      var icon = Resources.Load(source) as Sprite;
      image.sprite = icon ?? notAvailableIcon;
    }
  }
}

