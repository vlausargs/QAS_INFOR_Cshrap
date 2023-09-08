//PROJECT NAME: CSIProduct
//CLASS NAME: MO_LoadCojobQtyPerCycleFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class MO_LoadCojobQtyPerCycleFactory
    {
        public IMO_LoadCojobQtyPerCycle Create(IApplicationDB appDB)
        {
            var _MO_LoadCojobQtyPerCycle = new MO_LoadCojobQtyPerCycle(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iMO_LoadCojobQtyPerCycleExt = timerfactory.Create<IMO_LoadCojobQtyPerCycle>(_MO_LoadCojobQtyPerCycle);

            return iMO_LoadCojobQtyPerCycleExt;
        }
    }
}
