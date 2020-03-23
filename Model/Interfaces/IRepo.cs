namespace planthydra_api.Model.Interfaces
{
    public interface IRepo
    {
        IUserRepository User { get; }
        IDeviceRepository Device { get; }
        ISensorDataRepository SensorData { get; }
        IScheduleRepository Schedule { get; }
        ICommentRepository Comment { get; }
        IImageRepository Image { get; }
    }
}