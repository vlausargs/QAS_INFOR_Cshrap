//PROJECT NAME: Data
//CLASS NAME: CurrCnvtSingleAmt2Factory.cs

using CSI.Data.SQL;
using CSI.MG;

namespace CSI.Finance
{
    public interface ICurrCnvtSingleAmt2Factory
    {
        ICurrCnvtSingleAmt2 Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}