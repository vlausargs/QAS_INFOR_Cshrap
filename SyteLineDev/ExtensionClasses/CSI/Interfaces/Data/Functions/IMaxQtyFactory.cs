//PROJECT NAME: Data
//CLASS NAME: MaxQtyFactory.cs

using CSI.Data.SQL;
using CSI.MG;

namespace CSI.Data.Functions
{
    public interface IMaxQtyFactory
    {
        IMaxQty Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}