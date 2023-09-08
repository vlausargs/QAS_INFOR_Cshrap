//PROJECT NAME: CSIFinance
//CLASS NAME: RemoveAccountUnitCodesFactory.cs

using CSI.MG;

namespace CSI.Finance
{
    public class RemoveAccountUnitCodesFactory
    {
        public IRemoveAccountUnitCodes Create(IApplicationDB appDB)
        {
            var _RemoveAccountUnitCodes = new RemoveAccountUnitCodes(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSLChartsExt = timerfactory.Create<IRemoveAccountUnitCodes>(_RemoveAccountUnitCodes);

            return iSLChartsExt;
        }
    }
}
