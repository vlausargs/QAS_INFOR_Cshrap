//PROJECT NAME: CSICustomer
//CLASS NAME: ChkXrefWarningFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class ChkXrefWarningFactory
    {
        public IChkXrefWarning Create(IApplicationDB appDB)
        {
            var _ChkXrefWarning = new ChkXrefWarning(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iChkXrefWarningExt = timerfactory.Create<IChkXrefWarning>(_ChkXrefWarning);

            return iChkXrefWarningExt;
        }
    }
}
