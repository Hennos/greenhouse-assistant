using System;
using System.Collections.Generic;

using GreenhouseUI.Utils.Stream;

namespace GreenhouseUI.Services.SearchDevice {
  public interface ISearchDeviceService
  {
    IEnumerable<IFoundDevice> Devices { get; }
    void RunService();
    void StartSearching();
    void StopSearching();
    void StopService();
  }

  public class SearchDeviceService : ISearchDeviceService
  {
    public IEnumerable<IFoundDevice> Devices { get; private set; }

    public SearchDeviceService()
    {
      Devices = new List<IFoundDevice>();
    }

    public void RunService()
    {
    }

    public void StartSearching() 
    { 
    }

    public void StopSearching()
    { 
    }

    public void StopService()
    {
    }
  }
}
