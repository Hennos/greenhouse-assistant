using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GreenhouseUI {
  public class ChooseDeviceController : MonoBehaviour
  {
    [SerializeField] MainController mainController;

    private void OnEnable()
    {
      Messenger<IFoundDevice>.AddListener(UIEvent.PUSH_CHOOSED_DEVICE, OnChooseDevice);
    }

    private void OnDisable()
    {
      Messenger<IFoundDevice>.RemoveListener(UIEvent.PUSH_CHOOSED_DEVICE, OnChooseDevice);
    }

    private void OnChooseDevice(IFoundDevice choosed)
    {
      mainController.RequestDeviceData(choosed);
    }
  }
}
