//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLGetProductionScheduleDetailsFactory.cs

using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
    public class FTSLGetProductionScheduleDetailsFactory
    {
        public IFTSLGetProductionScheduleDetails Create(IApplicationDB appDB)
        {
            var _FTSLGetProductionScheduleDetails = new FTSLGetProductionScheduleDetails(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iFTSLGetProductionScheduleDetailsExt = timerfactory.Create<IFTSLGetProductionScheduleDetails>(_FTSLGetProductionScheduleDetails);

            return iFTSLGetProductionScheduleDetailsExt;
        }
    }
}
