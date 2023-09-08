//PROJECT NAME: CSICustomer
//CLASS NAME: CoReleaseValidQtyOrderedFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class CoReleaseValidQtyOrderedFactory
    {
        public ICoReleaseValidQtyOrdered Create(IApplicationDB appDB)
        {
            var _CoReleaseValidQtyOrdered = new CoReleaseValidQtyOrdered(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCoReleaseValidQtyOrderedExt = timerfactory.Create<ICoReleaseValidQtyOrdered>(_CoReleaseValidQtyOrdered);

            return iCoReleaseValidQtyOrderedExt;
        }
    }
}
