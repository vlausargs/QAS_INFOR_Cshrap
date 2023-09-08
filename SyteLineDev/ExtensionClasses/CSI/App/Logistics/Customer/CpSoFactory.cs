//PROJECT NAME: Logistics
//CLASS NAME: CpSoFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class CpSoFactory
    {
        public ICpSo Create(IApplicationDB appDB)
        {
            var _CpSo = new Logistics.Customer.CpSo(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCpSoExt = timerfactory.Create<Logistics.Customer.ICpSo>(_CpSo);

            return iCpSoExt;
        }
    }
}
