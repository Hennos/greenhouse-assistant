using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GreenhouseUI {
  public class ChooseDeviceController : MonoBehaviour
  {
    private void OnEnable()
    {
      Messenger<IFoundDevice>.AddListener(UIEvent.PUSH_CHOOSE_DEVICE, OnChooseDevice);
    }

    private void OnDisable()
    {
      Messenger<IFoundDevice>.RemoveListener(UIEvent.PUSH_CHOOSE_DEVICE, OnChooseDevice);
    }

    private void OnChooseDevice(IFoundDevice choosed)
    {
      Messenger<IFoundDevice>.Broadcast(UIEvent.SET_CHOOSED_DEVICE, choosed);
    }
  }
}
