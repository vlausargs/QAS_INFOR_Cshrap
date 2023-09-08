//PROJECT NAME: CSIProduct
//CLASS NAME: JustInTimeGenerateTransNumFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class JustInTimeGenerateTransNumFactory
    {
        public IJustInTimeGenerateTransNum Create(IApplicationDB appDB)
        {
            var _JustInTimeGenerateTransNum = new JustInTimeGenerateTransNum(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iJustInTimeGenerateTransNumExt = timerfactory.Create<IJustInTimeGenerateTransNum>(_JustInTimeGenerateTransNum);

            return iJustInTimeGenerateTransNumExt;
        }
    }
}
