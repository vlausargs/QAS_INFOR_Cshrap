//PROJECT NAME: Data
//CLASS NAME: GetSalesPeriodFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Data.Functions
{
    public class GetSalesPeriodFactory
    {
        public IGetSalesPeriod Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var _GetSalesPeriod = new Functions.GetSalesPeriod(appDB);


            return _GetSalesPeriod;
        }
    }
}
