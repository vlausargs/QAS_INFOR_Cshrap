//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLValidateRestrictedTransFactory.cs

using CSI.MG;


namespace CSI.Logistics.WarehouseMobility
{
    public class FTSLValidateRestrictedTransFactory
    {
        public IFTSLValidateRestrictedTrans Create(IApplicationDB appDB)
        {
            var _FTSLValidateRestrictedTrans = new Logistics.WarehouseMobility.FTSLValidateRestrictedTrans(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iFTSLValidateRestrictedTransExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLValidateRestrictedTrans>(_FTSLValidateRestrictedTrans);

            return iFTSLValidateRestrictedTransExt;
        }

    }
}
