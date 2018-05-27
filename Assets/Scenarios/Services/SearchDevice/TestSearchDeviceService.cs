using System;
using System.Collections.Generic;
using UnityEngine;

namespace GreenhouseUI.Services.SearchDevice {
  public class TestSearchDeviceService : ISearchDeviceService
  {
    public IEnumerable<IFoundDevice> Devices { get; private set; }

    public TestSearchDeviceService()
    {
      Devices = new List<IFoundDevice> {
        { new FoundDevice { Name = "468008a0-5ffb-11e8-9c2d-fa7ae01bbebc"} }
      };
    }

    public void RunService()
    {
      Debug.Log("Run search device service");
    }

    public void StartSearching() 
    { 
      Debug.Log("Start searching");
    }

    public void StopSearching()
    { 
      Debug.Log("Stop searching");
    }

    public void StopService()
    {
      Debug.Log("Stop search device service");
    }
  }
}

