using System;

namespace GreenhouseUI {
  public enum RegulatorElementRole {
    Light
  }

  public interface IRegulatorElement : IDeviceElementData, IElementRole<RegulatorElementRole> {}

  public class RegulatorElement : IRegulatorElement
  {
    public string Name { get; set; }
    public string DeviceId { get; set; }
    public RegulatorElementRole Role { get; set; }
    public bool? Active { get; set; }
    public int? Condition { get; set; }
  }
}

