//PROJECT NAME: CSIFinance
//CLASS NAME: ArPostRemIsReadyTTFactory.cs

using CSI.MG;

namespace CSI.Finance.AR
{
    public class ArPostRemIsReadyTTFactory
    {
        public IArPostRemIsReadyTT Create(IApplicationDB appDB)
        {
            var _ArPostRemIsReadyTT = new ArPostRemIsReadyTT(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSLCustdrftsExt = timerfactory.Create<IArPostRemIsReadyTT>(_ArPostRemIsReadyTT);

            return iSLCustdrftsExt;
        }
    }
}

