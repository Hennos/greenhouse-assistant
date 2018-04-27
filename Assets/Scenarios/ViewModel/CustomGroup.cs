using System;
using System.Collections.Generic;

namespace GreenhouseUI.ViewModel {
  public class CustomGroup : IDevice
  {
    private List<string> m_sensors;
    private List<string> m_regulators;
    
    public string Name { get; private set; }
    public List<string> Sensors { get; private set; }
    public List<string> Regulators { get; private set; }

    public CustomGroup(string name) 
    {
      Name = name;
      Sensors = new List<string>();
      Regulators = new List<string>();
    }
  }
}
