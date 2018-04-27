using System;
using UnityEngine;

namespace GreenhouseUI.Components {
  public class Group : MonoBehaviour
  {
    [SerializeField] private Header header;

    public string Name { get; private set; }

    public void Render(ViewModel.IGroup data)
    {
      Name = data.Name;
      header.Title = Name;
    }
  }
}

