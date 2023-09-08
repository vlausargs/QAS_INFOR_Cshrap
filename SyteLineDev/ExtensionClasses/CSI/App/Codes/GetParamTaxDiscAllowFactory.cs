//PROJECT NAME: CSICodes
//CLASS NAME: GetParamTaxDiscAllowFactory.cs

using CSI.MG;

namespace CSI.Codes
{
    public class GetParamTaxDiscAllowFactory
    {
        public IGetParamTaxDiscAllow Create(IApplicationDB appDB)
        {
            var _GetParamTaxDiscAllow = new GetParamTaxDiscAllow(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetParamTaxDiscAllowExt = timerfactory.Create<IGetParamTaxDiscAllow>(_GetParamTaxDiscAllow);

            return iGetParamTaxDiscAllowExt;
        }
    }
}
