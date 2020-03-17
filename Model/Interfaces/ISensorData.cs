using System;

namespace planthydra_api.Model.Interfaces
{
    public enum SensorDataType
    {
        TEMPERATURE = 1,
        HUMIDITY = 2,
        LIGHT = 3
    }

    public interface ISensorData
    {
        int Id { get; }

        SensorDataType Type { get; set; }

        int Value { get; set; }

        DateTime Time { get; set; }
    }
}