using System;

namespace GreenhouseUI {
  public enum SensorElementRole {
    GROUND_TEMPERATURE,
    HUMIDITY,
    PRESSURE,
    GROUND_GYDROMETERS,
  }

  public interface ISensorElement : IDeviceElementData, IElementRole<SensorElementRole> {}

  public class SensorElement : ISensorElement
  {
    public string Name { get; set; }
    public string DeviceId { get; set; }
    public SensorElementRole Role { get; set; }
    public bool? Active { get; set; }
    public int? Condition { get; set; }
  }
}
