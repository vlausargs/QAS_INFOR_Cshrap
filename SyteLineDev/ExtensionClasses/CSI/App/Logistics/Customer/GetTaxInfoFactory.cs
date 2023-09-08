//PROJECT NAME: CSICustomer
//CLASS NAME: GetTaxInfoFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class GetTaxInfoFactory
    {
        public IGetTaxInfo Create(IApplicationDB appDB)
        {
            var _GetTaxInfo = new GetTaxInfo(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetTaxInfoExt = timerfactory.Create<IGetTaxInfo>(_GetTaxInfo);

            return iGetTaxInfoExt;
        }
    }
}
