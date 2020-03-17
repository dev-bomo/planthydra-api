using System;
using planthydra_api.Model.Interfaces;

namespace planthydra_api.Model.Models
{
    class SensorData : ISensorData
    {
        public int Id { get; private set; }
        public SensorDataType Type { get; set; }
        public int Value { get; set; }
        public DateTime Time { get; set; }

        public SensorData(int id, SensorDataType sensorDataType, int value, DateTime time)
        {
            this.Id = id;
            this.Type = sensorDataType;
            this.Value = value;
            this.Time = time;
        }
    }
}