//PROJECT NAME: CSICustomer
//CLASS NAME: GetArParmInfoFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class GetArParmInfoFactory
    {
        public IGetArParmInfo Create(IApplicationDB appDB)
        {
            var _GetArParmInfo = new GetArParmInfo(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetArParmInfoExt = timerfactory.Create<IGetArParmInfo>(_GetArParmInfo);

            return iGetArParmInfoExt;
        }
    }
}
