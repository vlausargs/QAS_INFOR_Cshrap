//PROJECT NAME: Finance.AR
//CLASS NAME: ARAgingBucketsFactory.cs

using CSI.Data.SQL;
using CSI.MG;

namespace CSI.Finance.AR
{
    public interface IARAgingBucketsFactory
    {
        IARAgingBuckets Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}