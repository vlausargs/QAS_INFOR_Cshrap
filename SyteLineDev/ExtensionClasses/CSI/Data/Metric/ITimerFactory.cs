namespace CSI.Data.Metric
{
    public interface ITimerFactory
    {
        T Create<T>(T decorated);
        T CreateForEntryPointMethod<T>(T decorated);
    }
}