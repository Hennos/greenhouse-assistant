using System;
using UnityEngine;

namespace GreenhouseUI {
  public class Element : MonoBehaviour
  {
    private string m_elementName;

    [SerializeField] private Header header;

    public void Render(IDeviceElementData data)
    {
      header.Title = data.Name + " (" + data.DeviceId + ")";
    }
  }
}
