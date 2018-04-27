using System;
using UnityEngine;

namespace GreenhouseUI.Components {
  public class FoundDevice : MonoBehaviour
  {
    [SerializeField] private Header header;

    public string Name { get; private set; }

    private void OnEnable()
    {
    }

    public void Render(IFoundDevice data)
    {
      Name = data.Name;
      header.Title = Name;
    }
  }
}
