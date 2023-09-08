//PROJECT NAME: CSICustomer
//CLASS NAME: CanImportPmtDeletedFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class CanImportPmtDeletedFactory
    {
        public ICanImportPmtDeleted Create(IApplicationDB appDB)
        {
            var _CanImportPmtDeleted = new CanImportPmtDeleted(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCanImportPmtDeletedExt = timerfactory.Create<ICanImportPmtDeleted>(_CanImportPmtDeleted);

            return iCanImportPmtDeletedExt;
        }
    }
}
