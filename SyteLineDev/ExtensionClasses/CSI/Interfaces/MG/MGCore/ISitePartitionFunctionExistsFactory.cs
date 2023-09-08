using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface ISitePartitionFunctionExistsFactory
    {
        ISitePartitionFunctionExists Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}